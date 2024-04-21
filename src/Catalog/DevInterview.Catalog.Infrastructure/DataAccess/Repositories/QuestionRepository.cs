using DevInterview.Catalog.Domain.Entities;
using DevInterview.Catalog.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DevInterview.Catalog.Infrastructure.DataAccess.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly CatalogContext _context;

        public QuestionRepository(CatalogContext context)
        {
            _context = context;
        }

        public async Task<List<Question>> GetAllQuestions()
        {
            var questionsWithSubjectInfo = await (from q in _context.Questions
                                                  join t in _context.Topics on q.TopicId equals t.Id
                                                  join s in _context.Subjects on t.SubjectId equals s.Id
                                                  select new
                                                  {
                                                      Question = q,
                                                      Topic = t,
                                                      Subject = s
                                                  }).ToListAsync();

            var questions = questionsWithSubjectInfo.Select(qs =>
            {
                qs.Question.Topic = qs.Topic;
                return qs.Question;
            }).ToList();

            return questions;
        }

        public async Task<Question> GetQuestion(int id)
        {
            var questionWithSubjectInfo = await (from q in _context.Questions
                                                 where q.Id == id
                                                 join t in _context.Topics on q.TopicId equals t.Id
                                                 join s in _context.Subjects on t.SubjectId equals s.Id
                                                 select new
                                                 {
                                                     Question = q,
                                                     Topic = t,
                                                     Subject = s
                                                 }).FirstOrDefaultAsync();

            if (questionWithSubjectInfo is null)
                return null;

            questionWithSubjectInfo.Question.Topic = questionWithSubjectInfo.Topic;
            return questionWithSubjectInfo.Question;
        }

        public async Task<Question> CreateQuestion(Question question)
        {
            await _context.AddAsync(question);
            await _context.SaveChangesAsync();
            return question;
        }

        public async Task<int> UpdateQuestion(Question question)
        {
            var entity = await _context.Questions.SingleAsync(q => q.Id == question.Id);
            _context.Entry(entity).CurrentValues.SetValues(question);
            await _context.SaveChangesAsync();
            return question.Id;
        }

        public async Task<bool> DeleteQuestion(int id)
        {
            var question = await _context.Questions.SingleOrDefaultAsync(q => q.Id == id);

            if (question is not null)
            {
                _context.Questions.Remove(question);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<List<Question>> GetQuestionsByTopic(int topicId)
        {
            return await _context.Questions.Where(t => t.TopicId == topicId).ToListAsync();
        }
    }
}