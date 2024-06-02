using DevInterview.Students.Domain.Entities;
using DevInterview.Students.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DevInterview.Students.Infrastructure.DataAccess.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentsContext _context;

        public StudentRepository(StudentsContext context)
        {
            _context = context;
        }

        public async Task<Student> GetAsync(int id)
        {
            return await _context.Students.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Student> CreateAsync(Student student)
        {
            await _context.AddAsync(student);
            await _context.SaveChangesAsync();
            return student;
        }
    }
}