using AutoMapper;
using Microsoft.AspNetCore.Identity;
using QuizSystem.API.Extensions;
using QuizSystem.Domain.Models;
using QuizSystem.Domain.Repository;
using QuizSystem.Repository;
using QuizSystem.Service.Contracts.DTO;

namespace QuizSystem.Service
{
    public class UserService : IUserService
    {
        private readonly UserRepository userRepository;
        private readonly IStudentService studentService;
        private readonly IProfessorService professorService;
        public UserService(UserManager<ApiUser> userManager, IStudentService studentService , IProfessorService professorService)
        {
            userRepository = new UserRepository(userManager);
            this.studentService = studentService;
            this.professorService= professorService;
        }

        public List<UserSearchResultDTO> SearchForUser(StudentProfessorSearchDTO dto)
        {
            var userList = userRepository.Filter(dto.FirstName, dto.LastName, dto.NationalCode, dto.Role).Result;
            var result = new List<UserSearchResultDTO>();
            foreach (var item in userList)
            {
                result.Add(new UserSearchResultDTO { NationalCode = item.NationalCode , Role = userRepository.GetUserRole(item.NationalCode)});
            }
            return result;
        }

        public async Task<IdentityResult> SignUp(UserCreateDTO dto , UserManager<ApiUser> userManager)
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<UserCreateDTO, ApiUser>()).CreateMapper();
            var user = mapper.Map<ApiUser>(dto);
            user.UserName = dto.NationalCode;

            var result = await userManager.CreateAsync(user, dto.Password.ToString());

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, dto.Role);
                if (dto.Role.ToLower() == "student")
                {
                    studentService.CreateStudent(Guid.Parse(user.Id));
                }
                if(dto.Role.ToLower() == "professor")
                {
                    professorService.CreateProfessor(Guid.Parse(user.Id));
                }
            }

            return result;
        }
    }
}