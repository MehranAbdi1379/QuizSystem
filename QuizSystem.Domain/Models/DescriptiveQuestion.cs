using QuizSystem.Domain.Repository;
using QuizSystem.Domain.Test.Models;
using QuizSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizSystem.Domain.Models
{
    public class DescriptiveQuestion: Question
    {
        public DescriptiveQuestion()
        {

        }

        public DescriptiveQuestion(string title, IDescriptiveQuestionRepository repository , string description 
            , IProfessorRepository professorRepository , ICourseRepository courseRepository , Guid professorId , Guid courseId) : 
            base(description,professorId,courseId,professorRepository,courseRepository)
        {
            SetTitle(title, repository , courseId , professorId);
        }

        public string Title { get; private set; }

        public void SetTitle(string title, IDescriptiveQuestionRepository repository , Guid courseId , Guid professorId)
        {
            if (repository.TitleExists(title , courseId , professorId))
                throw new QuestionTitleExistsException();
            Title = title;
        }
    }
}
