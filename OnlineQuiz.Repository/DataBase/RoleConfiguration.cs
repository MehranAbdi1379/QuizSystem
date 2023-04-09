using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Repository.DataBase
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Name = "Student",
                    NormalizedName = "STUDENT"
                },
            new IdentityRole
            {
                Name = "Professor",
                NormalizedName = "PROFESSOR"
            }
            ,
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            }
            ) ;
        }
    }
}
