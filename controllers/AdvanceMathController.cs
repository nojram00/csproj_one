using Microsoft.AspNetCore.Mvc;

namespace csproj_one.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdvanceMathController : ControllerBase
    {
        public struct APIResponse {
            public int Result {get; set;}
        }

        public struct APIRequest
        {
            public int Value1 {get; set;}
            public int Value2 {get;set;}
        }
        public struct APIExpRequest
        {
            public int Base {get; set;}
            public int Exp {get;set;}
        }

        public struct APISQRTRequest
        {
            public int Value { get; set; }
        }

        [HttpPost("exponent", Name ="Exponent")]
        public ActionResult<APIResponse> Exp(APIExpRequest req)
        {   
            int result = 0;

            for(int i = 1; req.Exp > i; i++)
            {
                result *= req.Base;
            }

            return Ok(new {
                Result = result
            });
        }

        
        [HttpPost("square-root", Name ="SquareRoot")]
        public ActionResult<APIResponse> Sqrt(APISQRTRequest req)
        {
            double result = Math.Sqrt(req.Value);

            int res = Convert.ToInt32(result);

            return Ok(new {
                Result = res
            });
        }

        [HttpPost("modulo", Name ="Modulo")]
        public ActionResult<APIResponse> Mod(APIRequest res)
        {
            int result = res.Value1 % res.Value2;

            return Ok(new {
               Result = result 
            });
        }

    }
}
