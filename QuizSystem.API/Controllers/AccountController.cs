using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuizSystem.Domain.Models;
using QuizSystem.Service.Contracts.DTO;

namespace QuizSystem.API.Controllers
{
    [ApiController]
    [Route("api/Account-Controller")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApiUser> userManager;

        public AccountController(UserManager<ApiUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost]
        [Route("Sign-Up")]
        public async Task<IActionResult> SignUp(UserCreateDTO dto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mappercongif = new MapperConfiguration(config => config.CreateMap<UserCreateDTO,ApiUser>());
            var mapper = mappercongif.CreateMapper();
            var user = mapper.Map<ApiUser>(dto);
            user.UserName = dto.NationalCode;

            var result = await userManager.CreateAsync(user , dto.Password);

            return Ok(result);
        }

        //[HttpPost]
        //[Route("Sign-In")]
        //public IActionResult SignIn(UserSignInDTO dto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var result = signInManager.PasswordSignInAsync(dto.NationalCode, dto.Password , false , false);

        //    if (result.IsCompletedSuccessfully)
        //    {
        //        return Unauthorized(dto);
        //    }
        //    return BadRequest(result);
            
        //}
    }
}
