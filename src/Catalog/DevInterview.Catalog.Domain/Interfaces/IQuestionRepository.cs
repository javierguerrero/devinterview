using DevInterview.Catalog.Domain.Entities;

namespace DevInterview.Catalog.Domain.Interfaces
{
    public interface IQuestionRepository
    {
        Task<List<Question>> GetAllQuestions();

        Task<List<Question>> GetQuestionsByTopic(int topicId);

        Task<Question> GetQuestion(int id);

        Task<Question> CreateQuestion(Question question);

        Task<int> UpdateQuestion(Question question);

        Task<bool> DeleteQuestion(int id);
    }
}