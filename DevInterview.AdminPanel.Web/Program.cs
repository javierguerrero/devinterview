using AutoMapper;
using DevInterview.AdminPanel.Application;
using DevInterview.AdminPanel.Application.Mapper;
using DevInterview.AdminPanel.Infrastructure;
using DevInterview.AdminPanel.Infrastructure.DataAccess.Mappers;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services
    .AddApplicationServices(configuration)
    .AddInfrastructure(configuration);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Automapper
var automapperConfig = new MapperConfiguration(mapperConfig =>
{
    mapperConfig.AddMaps(typeof(AdminPanelProfile).Assembly);
    mapperConfig.AddMaps(typeof(FirebaseProfile).Assembly);
});
IMapper mapper = automapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


//Add sessions
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();
