using Microsoft.AspNetCore.Mvc;

namespace csproj_one.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasicMathController : ControllerBase
    {
       
        public struct APIResponse {
            public int Result {get; set;}
        }
        public struct APIRequest
        {
            public int Value1 {get; set;}
            public int Value2 {get;set;}
        }

        [HttpPost("add",Name ="Add")]
        public ActionResult<APIResponse> Add(APIRequest req)
        {
            return Ok(new {
                Result = req.Value1 + req.Value2
            });
        }

        [HttpPost("subtract",Name ="Subtract")]
        public ActionResult<APIResponse> Sub(APIRequest req)
        {
            return Ok(new {
                Result = req.Value1 - req.Value2
            });
        }

        [HttpPost("multiply",Name ="Multiply")]
        public ActionResult<APIResponse> Mul(APIRequest req)
        {
            return Ok(new {
                Result = req.Value1 * req.Value2
            });
        }

        [HttpPost("divide",Name ="Divide")]
        public ActionResult<APIResponse> Div(APIRequest req)
        {
            return Ok(new {
                Result = req.Value1 / req.Value2
            });
        }

    }
}
