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
    public class GradedQuestionConfiguration : IEntityTypeConfiguration<GradedQuestion>
    {
        public void Configure(EntityTypeBuilder<GradedQuestion> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.QuestionId).IsRequired();
            builder.Property(x => x.Grade).IsRequired();
        }
    }
}
