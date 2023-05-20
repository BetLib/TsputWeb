using DataBase.Services.Users;
using DataBase;
using Microsoft.AspNetCore.Mvc;
using lab6.Contracts;
using lab6.Infrastructure;

namespace lab6.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : ControllerBase
    {

        private readonly IUserRepository userRepository;

        public RegistrationController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }


        [HttpPost]
        public ActionResult Post([FromBody] RegistrationContract contract)
        {

            if (string.IsNullOrEmpty(contract.Password?.Trim())
                || string.IsNullOrEmpty(contract.Login?.Trim())
                || string.IsNullOrEmpty(contract.UserName?.Trim())) 
            {
                return BadRequest();
            }

            var user = new DbUser()
            {
                Login = contract.Login.Trim().ToUpper(),
                Password = AuthHelper.GetPasswordHash(contract.Password.Trim()),
                UserName = contract.UserName
            };
            
            user = userRepository.Create(user);
            if (user == null)
            {
                return BadRequest("Пользователь уже существует");
            }

            return Ok(user);
        }

    }
}