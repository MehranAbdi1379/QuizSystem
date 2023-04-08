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
        public List<TEntity> Filter(string firstName, string lastName, string nationalCode)
        {
            return context.Set<TEntity>().Where(s => s.FirstName.ToLower().Contains(firstName.ToLower()) &&
            s.LastName.ToLower().Contains(lastName.ToLower()) && s.NationalCode.Contains(nationalCode)).ToList();
        }
        public TEntity GetWithNationalCodeAndPassword(string nationalCode , string password)
        {
            return context.Set<TEntity>().Where(t => t.NationalCode == nationalCode && t.Password==password).First();
        }
    }
}
