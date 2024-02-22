using DevInterview.AdminPanel.Domain.Entities;

namespace DevInterview.AdminPanel.Domain.Interfaces
{
    public interface IQuestionRepository
    {
        Task<List<Question>> GetAllQuestions();

        Task<List<Question>> GetAllQuestions(string topicId);

        Task<Question> GetQuestion(string id);

        Task<string> CreateQuestion(Question question);

        Task<string> UpdateQuestion(Question question);

        Task<bool> DeleteQuestion(string id);
    }
}
