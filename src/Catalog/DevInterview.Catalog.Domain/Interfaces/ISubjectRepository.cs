using DevInterview.Catalog.Domain.Entities;

namespace DevInterview.Catalog.Domain.Interfaces
{
    public interface ISubjectRepository
    {
        Task<List<Subject>> GetAllAsync();

        Task<Subject> GetAsync(int id);

        Task<Subject> CreateAsync(Subject subject);

        Task<int> UpdateAsync(Subject subject);

        Task<bool> DeleteAsync(int id);
    }
}