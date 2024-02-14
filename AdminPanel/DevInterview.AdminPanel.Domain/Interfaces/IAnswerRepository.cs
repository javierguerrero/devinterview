using DevInterview.AdminPanel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInterview.AdminPanel.Domain.Interfaces
{
    public interface IAnswerRepository
    {
        Task<Answer> GetAnswer(string id);

        Task<string> CreateAnswer(Answer answer);

        Task<string> UpdateAnswer(Answer answer);

        Task<bool> DeleteAnswer(string id);
    }
}
