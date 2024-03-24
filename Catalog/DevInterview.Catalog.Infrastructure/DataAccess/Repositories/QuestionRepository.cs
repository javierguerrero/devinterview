using DevInterview.Catalog.Domain.Entities;
using DevInterview.Catalog.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInterview.Catalog.Infrastructure.DataAccess.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        public Task<int> CreateQuestion(Question question)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteQuestion(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Question>> GetAllQuestions()
        {
            throw new NotImplementedException();
        }

        public Task<Question> GetQuestion(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Question>> GetQuestionsByTopic(int topicId)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateQuestion(Question question)
        {
            throw new NotImplementedException();
        }
    }
}
