using Microsoft.AspNetCore.Mvc;

namespace FlotteApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ViewResult Login()
        {
            return View();
        }
    }

}
