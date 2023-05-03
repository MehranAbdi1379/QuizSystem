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
                    Id = "06f26b14-1ecf-47fc-99ff-dad62252d4df",
                    ConcurrencyStamp = "c7f7e407-3aa1-4790-8297-d622af0a9c1b",
                    Name = "Student",
                    NormalizedName = "STUDENT"
                },
            new IdentityRole
            {
                Id= "95f68c57-1f7e-468d-bbf1-edf388ef327f",
                ConcurrencyStamp = "07b5d456-81a5-41b8-9fd3-3a57c58c7635",
                Name = "Professor",
                NormalizedName = "PROFESSOR"
            }
            ,
            new IdentityRole
            {
                Id = "35eb57e7-cb71-4310-9956-1a01c5fb46af",    
                ConcurrencyStamp = "ea8e860a-6f3c-4003-aa18-618050f0ba01",
                Name = "Admin",
                NormalizedName = "ADMIN"
            }
            ); 
        }
    }
}
