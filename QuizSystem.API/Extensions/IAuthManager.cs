using QuizSystem.Service.Contracts.DTO;

namespace QuizSystem.API.Extensions
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(UserSignInDTO dto);
        Task<string> CreateToken();
    }
}
