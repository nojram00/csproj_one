using Microsoft.AspNetCore.Mvc;

namespace csproj_one.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Hello World!";
        }

        [HttpPost]
        public ActionResult<string> Post()
        {
            return "Hi world!";
        }

    }
}
