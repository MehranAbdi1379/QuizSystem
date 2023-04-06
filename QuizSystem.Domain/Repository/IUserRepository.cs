using Framework.Repository;
using QuizSystem.Domain.Models;

namespace QuizSystem.Domain.Repository
{
    public interface IUserRepository<TEntity> : IBaseRepository<TEntity> where TEntity : User
    {
        bool NationalCodeExists(string nationalCode);
    }
}