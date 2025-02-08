using System.Diagnostics.Eventing.Reader;
using FlotteApplication.Enum;
using FlotteApplication.Models;
using FlotteApplication.Repositories.Implementation;
using FlotteApplication.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FlotteApplication.Controllers
{
    public class EnginController : Controller
    {
        IEngin _repository;
        public EnginController(IEngin repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var engins = _repository.getAllEngin();
            if (engins != null)
            {
                return View("Index", engins);
            }
            else
            {
                return View("Index");
            }
        }
        public ViewResult Add()
        {
            return View("AddView");
        }
        [HttpPost]
        public IActionResult Add(Engin engin)
        {

            try
            {
                Task<Boolean> result = _repository.createEngin(engin);
                if (result.Result == true)
                {
                    var engins = _repository.getAllEngin();

                    return RedirectToAction("Index");  // Redirige vers l'action "Index"

                }
                else
                {
                    return View("Error");
                }
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }
        public IActionResult Edit(int id)
        {
            var engin = _repository.getEngineById(id);
            if (engin == null)
            {
                return NotFound();
            }
            return PartialView("_EditEnginPartial", engin);
        }
        public ViewResult Update(Engin engin)
        {
            var existEngin = _repository.getEngineById(engin.enginId);
            if (existEngin != null)
            {
                _repository.updateEngin(engin);
                ViewBag.Etat = "la mise a jour efectuer avec succes ";
                var engins = _repository.getAllEngin();
                return View("Index", engins);
            }
            else
            {
                ViewBag.Etat = "La mise a jour a echouer";
                return View("_EditEnginPartial");
            }
        }

       
        public IActionResult Delete(int Id)
        {
            try
            {
                Task<Boolean> deletedEngin = _repository.deleteEngin(Id);
                if (deletedEngin.Result == true)
                {
                    ViewBag.Message = "L' utilisateur a été suprimé avec success";
                    var engins = _repository.getAllEngin();
                    return RedirectToAction("Index", engins);
                }
                else
                {
                    ViewBag.Message = "L' utilisateur a été suprimé avec success";
                    return RedirectToAction("Index");
                }
                ViewBag.Message = "L' utilisateur a été suprimé avec success";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message = "L' utilisateur a été suprimé avec success";
                return RedirectToAction("Index");
            }
        }
        /* [HttpGet("getEngin/{enginId}")]
         public Task<Engin> getEnginById(int enginId)
         {
             try
             {

                 var engin = _repository.getEnginById(enginId);
                 return engin;
             }catch(Exception e)
             {
                 return (Task<Engin>)null;
             }

         }

    */




    }
}
