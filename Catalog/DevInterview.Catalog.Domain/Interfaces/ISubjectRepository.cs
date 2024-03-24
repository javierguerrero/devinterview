using DevInterview.Catalog.Domain.Entities;

namespace DevInterview.Catalog.Domain.Interfaces
{
    public interface ISubjectRepository
    {
        Task<List<Subject>> GetAllSubjects();

        Task<Subject> GetSubject(int id);

        Task<int> CreateSubject(Subject subject);

        Task<int> UpdateSubject(Subject subject);

        Task<bool> DeleteSubject(int id);
    }
}