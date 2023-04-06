using Framework.Core.Domain;
using Framework.Repository;
using QuizSystem.Domain.Models;
using QuizSystem.Domain.Repository;
using QuizSystem.Repository.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Repository
{
    public class UserRepository<TEntity> : BaseRepository<TEntity>, IUserRepository<TEntity> where TEntity : User
    {
        public UserRepository(QuizSystemContext context) : base(context)
        {

        }

        public bool NationalCodeExists(string nationalCode)
        {
            return context.Set<TEntity>().Any(s => s.NationalCode == nationalCode);
        }
    }
}
