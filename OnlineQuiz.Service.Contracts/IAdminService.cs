using QuizSystem.Domain.Models;
using QuizSystem.Service.Contracts.DTO;

namespace QuizSystem.Service
{
    public interface IAdminService
    {
        Admin CreateAdmin(UserCreateDTO dto);
        Admin RemoveAdmin(UserIdDTO dto);
        Admin UpdateAdmin(UserUpdateDTO dto);
        public AdminSignedInDTO AdminSignIn(UserSignInDTO dto);
    }
}