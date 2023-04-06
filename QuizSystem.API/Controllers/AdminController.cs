using Microsoft.AspNetCore.Mvc;
using QuizSystem.Service.Contracts.DTO;
using QuizSystem.Service;

namespace QuizSystem.API.Controllers
{
    [ApiController]
    [Route("api/Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService service;

        public AdminController(IAdminService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult CreateStudent(UserCreateDTO dto)
        {
            return Ok(service.CreateAdmin(dto));
        }
        [HttpPut]
        [Route("Update")]
        public IActionResult UpdateStudent(UserUpdateDTO dto)
        {
            return Ok(service.UpdateAdmin(dto));
        }
        [HttpDelete]
        [Route("Delete")]
        public IActionResult DeleteStudent(UserIdDTO dto)
        {
            return Ok(service.RemoveAdmin(dto));
        }

    }
}
