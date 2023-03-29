using Framework.Repository;
using QuizSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Domain.Repository
{
    public interface IProfessorRepository : IBaseRepository<Professor>
    {
        bool NationalCodeExists(string nationalCode);

        Professor GetProfessorFromNationalCodeAndPassword(string nationalCode, string password);
    }
}
