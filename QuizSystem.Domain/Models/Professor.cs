using Framework.Core.Domain;
using QuizSystem.Domain.Exceptions;
using QuizSystem.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuizSystem.Domain.Models
{
    public class Professor : BaseEntity
    {
        public Professor()
        {
            
        }

        public Professor(bool accepted = false) 
        {
            SetAccepted(accepted);
        }

        public Professor(Guid id) : base(id)
        {

        }

        public bool Accepted { get; private set; } = false;
        public List<Course> Courses { get; private set; }

        public void SetAccepted(bool accepted)
        {
            Accepted = accepted;
        }
    }
}