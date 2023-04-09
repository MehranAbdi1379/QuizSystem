using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Repository
{
    public class DataBaseContext<TEntity> : IdentityDbContext<TEntity> where TEntity : IdentityUser
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {

        }
    }
}
