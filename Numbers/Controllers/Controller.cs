using Microsoft.AspNetCore.Mvc;
using Numbers.Helper;


namespace Numbers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Controller : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public Controller(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

       


        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()//
        {
            string[] data = GetData();
            return data;
        }

        // GET api/values/5
        [HttpGet("{index}")]   //Get [FromRoute]
        public ActionResult<string> Get([FromRoute] int id)
        {
            var user = Repository.GetData(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public ActionResult Post([FromBody] User user)//([FromBody] AddElementContract contract)
        {

            Repository.Add(user);
            return Ok();
        }

        [HttpPut]
        public ActionResult Update([FromBody] User user, int id)//([FromBody] AddElementContract contract)
        {
              Repository.Update(user, id);
              return Ok();
          }


        // GET api/values/5
        [HttpDelete("{index}")]   //Get [FromRoute]
          public ActionResult Delete([FromRoute] int id)
          {
             Repository.Delete(id);
              return Ok();
          }
    }
}