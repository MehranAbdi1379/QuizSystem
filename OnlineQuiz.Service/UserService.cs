using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using QuizSystem.API.Extensions;
using QuizSystem.Domain.Models;
using QuizSystem.Domain.Repository;
using QuizSystem.Repository;
using QuizSystem.Service.Contracts.DTO;
using System.Data;
using System.Runtime.CompilerServices;

namespace QuizSystem.Service
{
    public class UserService : IUserService
    {
        private readonly UserRepository userRepository;
        private readonly IStudentService studentService;
        private readonly IProfessorService professorService;
        private readonly UserManager<ApiUser> userManager;
        private readonly IStudentRepository studentRepository;
        private readonly IProfessorRepository professorRepository;
        public UserService(UserManager<ApiUser> userManager,
            IStudentService studentService,
            IProfessorService professorService,
            IStudentRepository studentRepository,
            IProfessorRepository professorRepository)
        {
            userRepository = new UserRepository(userManager);
            this.studentService = studentService;
            this.professorService = professorService;
            this.userManager = userManager;
            this.studentRepository = studentRepository;
            this.professorRepository = professorRepository;
        }

        public async Task<bool> SignIn(UserSignInDTO dto)
        {
            var user = await userManager.FindByNameAsync(dto.NationalCode);
            var role = await userManager.GetRolesAsync(user);
            var userRole = role[0];
            if (userRole.ToLower() == "student")
            {
                var student = studentRepository.GetWithId(Guid.Parse(user.Id));
                
                if(student.Accepted==true)
                {
                    return true;
                }
            }
            else if (userRole.ToLower() == "professor")
            {
                var professor = professorRepository.GetWithId(Guid.Parse(user.Id));

                if (professor.Accepted == true)
                {
                    return true;
                }
            }
            else if(userRole.ToLower() == "admin")
                return true;
            return false;
            
        }

        public async Task<List<UserSearchResultDTO>> SearchForUser(StudentProfessorSearchDTO dto)
        {
            var userList = await userRepository.Filter(dto.FirstName, dto.LastName, dto.MinBirthDate, dto.MaxBirthDate , dto.Role);
            var result = new List<UserSearchResultDTO>();
            foreach (var item in userList)
            {
                result.Add(new UserSearchResultDTO { Id = item.Id , Role = userRepository.GetUserRole(item.NationalCode)});
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

        public async Task<AdminGetDTO> GetAdminById(UserIdStringDTO dto)
        {
            var data = await userManager.FindByIdAsync(dto.Id);
            return new AdminGetDTO()
            {
                FirstName = data.FirstName,
                LastName = data.LastName,
                BirthDate = data.BirthDate,
                Id = Guid.Parse(data.Id),
                NationalCode = data.NationalCode,
            };
        }
    }
}