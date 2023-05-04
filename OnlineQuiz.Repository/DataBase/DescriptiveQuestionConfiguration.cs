using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Repository.DataBase
{
    public class DescriptiveQuestionConfiguration : IEntityTypeConfiguration<DescriptiveQuestion>
    {
        public void Configure(EntityTypeBuilder<DescriptiveQuestion> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(20);
            builder.Property(x=>x.CourseId).IsRequired();
            builder.Property(x => x.ProfessorId).IsRequired();
            builder.Property(x => x.Description).IsRequired();
        }
    }
}
