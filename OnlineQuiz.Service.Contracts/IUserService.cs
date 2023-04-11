using Microsoft.AspNetCore.Identity;
using QuizSystem.Domain.Models;
using QuizSystem.Service.Contracts.DTO;

namespace QuizSystem.API.Extensions
{
    public interface IUserService
    {
        public Task<List<UserSearchResultDTO>> SearchForUser(StudentProfessorSearchDTO dto);
        public Task<IdentityResult> SignUp(UserCreateDTO dto, UserManager<ApiUser> userManager);
    }
}