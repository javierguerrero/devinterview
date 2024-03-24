using DevInterview.Catalog.Domain.Entities;

namespace DevInterview.Catalog.Domain.Interfaces
{
    public interface ITopicRepository
    {
        Task<List<Topic>> GetAllTopics();

        Task<List<Topic>> GetTopicsBySubject(int subjectId);

        Task<Topic> GetTopic(int id);

        Task<int> CreateTopic(Topic topic);

        Task<int> UpdateTopic(Topic topic);

        Task<bool> DeleteTopic(int id);
    }
}