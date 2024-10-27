using Microsoft.AspNetCore.Mvc;

namespace csproj_one.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

    }
}
