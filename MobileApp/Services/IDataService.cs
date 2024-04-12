using DevInterview.MobileApp.Models;

namespace DevInterview.MobileApp.Services
{
    public interface IDataService
    {
        Task<List<Subject>> GetSubjects();

        Task<List<Topic>> GetTopicsBySubject(int subjectId);

        Task<List<Question>> GetQuestionsByTopic(string topicId);
    }
}