using DevInterview.Students.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInterview.Students.Domain.Interfaces
{
    public interface IStudentRepository
    {
        Task<Student> CreateAsync(Student student);
    }
}
