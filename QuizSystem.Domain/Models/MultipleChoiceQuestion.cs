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
    public class MultipleChoiceQuestion: Question
    {
        public MultipleChoiceQuestion()
        {

        }

        public MultipleChoiceQuestion(string description ,IMultipleChoiceQuestionRepository repository , string title
            , Guid professorId , Guid courseId , ICourseRepository courseRepository , IProfessorRepository professorRepository)
            : base(description,professorId,courseId,professorRepository,courseRepository)
        {
            SetTitle(title, repository , professorId , courseId);
        }
        public string Title { get; private set; }

        public void SetTitle(string title , IMultipleChoiceQuestionRepository repository, Guid professorId , Guid courseId)
        {
            if (repository.TitleExist(title , professorId , courseId))
                throw new QuestionTitleExistsException();
            Title = title;
        }
    }
}
