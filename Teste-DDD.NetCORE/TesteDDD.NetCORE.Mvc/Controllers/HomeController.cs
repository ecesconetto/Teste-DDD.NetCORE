using Microsoft.AspNetCore.Mvc;

namespace TesteDDD.NetCORE.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
