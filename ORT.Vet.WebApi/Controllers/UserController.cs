using Microsoft.AspNetCore.Mvc;
using ORT.Vet.Domain;
using ORT.Vet.IBusinessLogic;
using ORT.Vet.WebApi.DTOs.In;

namespace ORT.Vet.WebApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserCreateModel userCreateModel)
        {
            var user = new User
            {
                Name = userCreateModel.Name,
                Password = userCreateModel.Password
            };

            _userService.CreateUser(user);

            return Ok(new { message = "User created successfully." });
        }
    }
}
