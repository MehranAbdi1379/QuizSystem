using QuizSystem.Service.Contracts.DTO;

namespace QuizSystem.API.Extensions
{
    public interface IUserSearchService
    {
        public StudentAndProfessorSearchResultDTO SearchForUser(StudentProfessorSearchDTO dto);
    }
}