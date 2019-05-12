using Microsoft.AspNetCore.Mvc;

namespace MirumDDD.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
