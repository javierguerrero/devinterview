using DevInterview.Students.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevInterview.Students.Infrastructure.DataAccess
{
    public class StudentsContext : DbContext
    {
        public StudentsContext(DbContextOptions<StudentsContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                        .HasData(
                            new Student()
                            {
                                Id = 1,
                                UserName = "jguerrero",
                                FirstName = "Javier",
                                LastName = "Guerrero"
                            }
                        );
        }
    }
}