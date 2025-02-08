using Microsoft.AspNetCore.Mvc;

namespace FlotteApplication.Controllers
{
    public class QuotationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
