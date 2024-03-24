using DevInterview.Catalog.Domain.Entities;
using DevInterview.Catalog.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInterview.Catalog.Infrastructure.DataAccess.Repositories
{
    public class TopicRepository : ITopicRepository
    {
        public Task<int> CreateTopic(Topic topic)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTopic(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Topic>> GetAllTopics()
        {
            throw new NotImplementedException();
        }

        public Task<Topic> GetTopic(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Topic>> GetTopicsBySubject(int subjectId)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateTopic(Topic topic)
        {
            throw new NotImplementedException();
        }
    }
}
