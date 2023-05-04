using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Service.Contracts.DTO
{
    public class MultipleChoiceAnswerCreateDTO
    {
        public Guid QuestionId {  get; set; }
        public string Title { get; set; }
        public bool RightAnswer { get; set; }
        
    }
}
