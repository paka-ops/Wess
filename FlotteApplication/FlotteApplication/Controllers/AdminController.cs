using FlotteApplication.Models;
using FlotteApplication.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FlotteApplication.Controllers
{
    public class AdminController : Controller
    {
        IAdmin _repository;
        public AdminController(IAdmin repository)
        {
            _repository = repository;
        }
        public IActionResult Index() { 
            return View();
        
        }
        [HttpPost]
        public ViewResult Login(Admin admin)
        {
            var result = _repository.LoginAdmin(admin);
            if(result == true)
            {
                return View("Index");
            }
            else
            {
                string message = "Mot de passe ou Utilisateur est invalide";
                ViewBag.Message = message;

                return View("../Home/Login");
            }
        }
    }
}
