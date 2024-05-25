using DevInterview.Students.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevInterview.Students.Infrastructure.DataAccess
{
    public class StudentsContext : DbContext
    {
        public StudentsContext(DbContextOptions<StudentsContext> options) : base(options)
        {
        }

        public DbSet<Student> Subjects { get; set; }
    }
}