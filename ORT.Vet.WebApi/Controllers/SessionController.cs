using System.Security.Authentication;
using Microsoft.AspNetCore.Mvc;
using ORT.Vet.IBusinessLogic;
using ORT.Vet.WebApi.DTOs.In;

namespace ORT.Vet.WebApi.Controllers
{
    [Route("api/sessions")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ISessionLogic _sessionService;

        public SessionController(ISessionLogic sessionService)
        {
            _sessionService = sessionService;
        }
        
        [HttpPost]
        public IActionResult Login([FromBody] UserLoginModel userLoginModel)
        {
            var token = _sessionService.Authenticate(userLoginModel.Name, userLoginModel.Password);
            return Ok(new { token = token });
        }

    }
}