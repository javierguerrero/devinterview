using DevInterview.AdminPanel.Domain.Entities;

namespace DevInterview.AdminPanel.Domain.Interfaces
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAllRoles();

        Task<Role> GetRole(string id);

        Task<string> CreateRole(Role role);

        Task<string> UpdateRole(Role role);

        Task<bool> DeleteRole(string id);
    }
}