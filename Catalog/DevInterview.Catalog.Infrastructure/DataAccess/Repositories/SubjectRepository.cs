using DevInterview.Catalog.Domain.Entities;
using DevInterview.Catalog.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInterview.Catalog.Infrastructure.DataAccess.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly CatalogContext _context;

        public SubjectRepository(CatalogContext context)
        {
            _context = context;
        }

        public Task<int> CreateSubject(Subject subject)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteSubject(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Subject>> GetAllSubjects()
        {
            return await _context.Subjects.ToListAsync();
        }

        public Task<Subject> GetSubject(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateSubject(Subject subject)
        {
            throw new NotImplementedException();
        }
    }
}
