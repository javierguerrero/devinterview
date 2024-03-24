using DevInterview.Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInterview.Catalog.Infrastructure.DataAccess
{
    public class CatalogContext: DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        {
        }

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Subject>()
                        .HasData(
                            new Subject()
                            {
                                Id = 1,
                                Name = ".NET Developer",
                                Image = ""
                            },
                            new Subject()
                            {
                                Id = 2,
                                Name = "AZ-900: Azure Fundamentals",
                                Image = ""
                            }
                        );

            modelBuilder.Entity<Topic>()
                        .HasData(
                            new Topic()
                            { 
                                Id = 1,
                                Name = ".NET",
                                SubjectId = 1,
                                Description = "Lorem ipsum"
                            },
                            new Topic()
                            {
                                Id = 2,
                                Name = "C#",
                                SubjectId = 1,
                                Description = "Lorem ipsum"
                            }
                        );

            modelBuilder.Entity<Question>()
                        .HasData(
                            new Question()
                            {
                                Id = 1,
                                QuestionText = "What is an assembly?",
                                AnswerText = "Lorem ipsum",
                                TopicId = 1,
                            }
                        );

        }
    }
}
