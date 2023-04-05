using Framework.Repository;
using QuizSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Domain.Repository
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        bool NationalCodeExists(string nationalCode);
        public List<Student> Filter(string firstName, string lastName, string nationalCode);
    }
}
