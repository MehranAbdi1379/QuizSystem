using QuizSystem.Domain.Exceptions;
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

        public void SetTitle(string title, IMultipleChoiceQuestionRepository repository, Guid courseId, Guid professorId)
        {
            if (repository.IsTitleExist(title, courseId, professorId))
                throw new QuestionTitleExistsException();
            else if (title.Length > 20)
                throw new QuestionTitleLengthLongException();
            Title = title;
        }
    }
}
