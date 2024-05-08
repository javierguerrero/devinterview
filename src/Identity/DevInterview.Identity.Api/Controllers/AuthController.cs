using DevInterview.Identity.Api.Data;
using DevInterview.Identity.Api.Data.Entities;
using DevInterview.Identity.Api.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DevInterview.Identity.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IdentityContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IdentityContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _context = context;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var jwt = GenerateAccessToken(authClaims);

                var newAccessToken = new RefreshToken
                {
                    Active = true,
                    Expiration = DateTime.UtcNow.AddDays(7),
                    RefreshTokenValue = Guid.NewGuid().ToString("N"),
                    Used = false,
                    UserId = user.Id
                };

                _context.Add(newAccessToken);
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    user = new { email = "demo@acme.com", name = "demo" },
                    accessToken = new JwtSecurityTokenHandler().WriteToken(jwt),
                    refreshToken = newAccessToken.RefreshTokenValue
                });
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            var refreshToken = await _context.RefreshTokens.FirstOrDefaultAsync(q => q.RefreshTokenValue == request.RefreshToken);

            // Refresh jwt no existe, expiró o fue revocado manualmente
            // (Pensando que el usuario puede dar click en "Cerrar Sesión en todos lados" o similar)
            if (refreshToken is null || refreshToken.Active == false || refreshToken.Expiration <= DateTime.UtcNow)
            {
                return Unauthorized();
            }

            // Se está intentando usar un Refresh Token que ya fue usado anteriormente,
            // puede significar que este refresh jwt fue robado.
            if (refreshToken.Used)
            {
                //_logger.LogWarning("El refresh jwt del {UserId} ya fue usado. RT={RefreshToken}", refreshToken.UserId, refreshToken.RefreshTokenValue);

                var refreshTokens = await _context.RefreshTokens
                    .Where(q => q.Active && q.Used == false && q.UserId == refreshToken.UserId)
                    .ToListAsync();

                foreach (var rt in refreshTokens)
                {
                    rt.Used = true;
                    rt.Active = false;
                }

                await _context.SaveChangesAsync();

                return Unauthorized();
            }

            // TODO: Podríamos validar que el Access Token sí corresponde al mismo usuario

            refreshToken.Used = true;

            var user = await _context.Users.FindAsync(refreshToken.UserId);

            if (user is null)
            {
                return Unauthorized();
            }

            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }


            var jwt = GenerateAccessToken(authClaims);

            var newRefreshToken = new RefreshToken
            {
                Active = true,
                Expiration = DateTime.UtcNow.AddDays(7),
                RefreshTokenValue = Guid.NewGuid().ToString("N"),
                Used = false,
                UserId = user.Id
            };

            _context.Add(newRefreshToken);

            await _context.SaveChangesAsync();

            return Ok(new
            {
                user = new { email = "demo@acme.com", name = "demo" },
                accessToken = new JwtSecurityTokenHandler().WriteToken(jwt),
                refreshToken = newRefreshToken.RefreshTokenValue
            });
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var userExists = await _userManager.FindByNameAsync(request.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new ResgisterResponse { Status = "Error", Message = "User already exists!" });

            IdentityUser user = new()
            {
                Email = request.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = request.Username
            };
            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError, 
                    new ResgisterResponse { 
                        Status = "Error", 
                        Message = "User creation failed! Please check user details and try again." 
                    }
                );
            }

            return Ok(new ResgisterResponse { 
                Status = "Success", 
                Message = "User created successfully!" 
            });
        }

        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterRequest request)
        {
            var userExists = await _userManager.FindByNameAsync(request.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new ResgisterResponse { Status = "Error", Message = "User already exists!" });

            IdentityUser user = new()
            {
                Email = request.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = request.Username
            };
            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new ResgisterResponse { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            }
            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.User);
            }
            return Ok(new ResgisterResponse { Status = "Success", Message = "User created successfully!" });
        }

        private JwtSecurityToken GenerateAccessToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(60),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return token;
        }
    }
}