using DevInterview.MobileApp.Models;

namespace DevInterview.MobileApp.Services
{
    public interface IDataService
    {
        Task<List<Role>> GetRoles();

        Task<List<Topic>> GetTopicsByRole(string roleId);

        Task<List<QuestionAnswer>> GetQuestionsAnswersByTopic(string topicId);
    }
}