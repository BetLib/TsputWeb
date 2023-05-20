using DataBase.Services.Users;
using DataBase;
using Microsoft.AspNetCore.Mvc;

namespace lab6.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpGet("{id}"]
        public ActionResult<DbUser> Get([FromRoute] int id)
        {


        }





    }
}
