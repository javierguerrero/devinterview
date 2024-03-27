using DevInterview.Catalog.Domain.Entities;
using DevInterview.Catalog.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DevInterview.Catalog.Infrastructure.DataAccess.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly CatalogContext _context;

        public SubjectRepository(CatalogContext context)
        {
            _context = context;
        }

        public async Task<List<Subject>> GetAllAsync()
        {
            return await _context.Subjects.ToListAsync();
        }

        public async Task<Subject> GetAsync(int id)
        {
            return await _context.Subjects.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var subject = await _context.Subjects.SingleOrDefaultAsync(s => s.Id == id);

            if (subject is not null)
            {
                _context.Subjects.Remove(subject);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<Subject> CreateAsync(Subject subject)
        {
            await _context.AddAsync(subject);
            await _context.SaveChangesAsync();
            return subject;
        }

        public async Task<int> UpdateAsync(Subject subject)
        {
            var entity = await _context.Subjects.SingleAsync(s => s.Id == subject.Id);
            _context.Entry(entity).CurrentValues.SetValues(subject);
            await _context.SaveChangesAsync();
            return subject.Id;
        }
    }
}