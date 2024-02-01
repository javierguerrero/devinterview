using DevInterview.MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInterview.MobileApp.Services
{
    public interface IDataService
    {
        Task<List<Role>> GetRoles();
    }
}
