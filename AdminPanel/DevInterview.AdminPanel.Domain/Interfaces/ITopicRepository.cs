﻿using DevInterview.AdminPanel.Domain.Entities;

namespace DevInterview.AdminPanel.Domain.Interfaces
{
    public interface ITopicRepository
    {
        Task<List<Topic>> GetAllTopics(string roleId);

        Task<Topic> GetTopic(string id);

        Task<string> CreateTopic(Topic topic);

        Task<string> UpdateTopic(Topic topic);

        Task<bool> DeleteTopic(string id);
    }
}
