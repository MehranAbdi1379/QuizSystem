using Framework.Repository;
using QuizSystem.Domain.Models;
using QuizSystem.Repository.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Repository
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(QuizSystemContext context) : base(context)
        {

        }
    }
}
