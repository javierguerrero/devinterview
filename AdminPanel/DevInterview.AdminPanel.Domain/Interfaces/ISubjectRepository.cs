using DevInterview.AdminPanel.Domain.Entities;

namespace DevInterview.AdminPanel.Domain.Interfaces
{
    public interface ISubjectRepository
    {
        Task<List<Subject>> GetAllSubjects();

        Task<Subject> GetSubject(string id);

        Task<string> CreateSubject(Subject role);

        Task<string> UpdateSubject(Subject role);

        Task<bool> DeleteSubject(string id);
    }
}