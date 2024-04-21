using DevInterview.Catalog.Domain.Entities;
using DevInterview.Catalog.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DevInterview.Catalog.Infrastructure.DataAccess.Repositories
{
    public class TopicRepository : ITopicRepository
    {
        private readonly CatalogContext _context;

        public TopicRepository(CatalogContext context)
        {
            _context = context;
        }

        public async Task<List<Topic>> GetAllTopics()
        {
            var topicsWithSubject = await (from t in _context.Topics
                                           join s in _context.Subjects on t.SubjectId equals s.Id
                                           select new Topic
                                           {
                                               Id = t.Id,
                                               Name = t.Name,
                                               Description = t.Description,
                                               SubjectId = t.SubjectId,
                                               Subject = s
                                           }).ToListAsync();
            return topicsWithSubject;
        }

        public async Task<Topic> GetTopic(int id)
        {
            return await _context.Topics.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Topic> CreateTopic(Topic topic)
        {
            await _context.AddAsync(topic);
            await _context.SaveChangesAsync();
            return topic;
        }

        public async Task<int> UpdateTopic(Topic topic)
        {
            var entity = await _context.Topics.SingleAsync(t => t.Id == topic.Id);
            _context.Entry(entity).CurrentValues.SetValues(topic);
            await _context.SaveChangesAsync();
            return topic.Id;
        }

        public async Task<bool> DeleteTopic(int id)
        {
            var topic = await _context.Topics.SingleOrDefaultAsync(t => t.Id == id);

            if (topic is not null)
            {
                _context.Topics.Remove(topic);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<List<Topic>> GetTopicsBySubject(int subjectId)
        {
            return await _context.Topics.Where(t => t.SubjectId == subjectId).ToListAsync();
        }
    }
}