using System.Reflection.Metadata.Ecma335;
using FlotteApplication.Enum;
using FlotteApplication.Models;
using FlotteApplication.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlotteApplication.Controllers
{
    public class ProprietaireController : Controller
    {
        IProprietaire _repository;
        public ProprietaireController(IProprietaire repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var proprietaires = _repository.getAllProprietaire();
            if (proprietaires != null)
            {
                return View("Index", proprietaires);
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
        public IActionResult Add(Proprietaire proprietaire)
        {

            try
            {
                Task<Boolean> result = _repository.createProprietaire(proprietaire);
                if (result.Result == true)
                {
                    var proprietaires = _repository.getAllProprietaire();

                    return RedirectToAction("Index");  

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
            var proprietaire = _repository.getProprietaireById(id);
            if (proprietaire == null)
            {
                return NotFound();
            }
            return PartialView("_EditProprietairePartial", proprietaire);
        }
        public ViewResult Update(Proprietaire proprietaire)
        {
            var existProprietaire = _repository.getProprietaireById(proprietaire.proprietaireId);
            if (existProprietaire != null)
            {
                _repository.updateProprietaire(proprietaire);
                ViewBag.Etat = "la mise a jour efectuer avec succes ";
                var proprietaires = _repository.getAllProprietaire();
                return View("Index", proprietaires);
            }
            else
            {
                ViewBag.Etat = "La mise a jour a echouer";
                return View("_EditProprietairePartial");
            }
        }
        
             public IActionResult Delete(int Id)
             {
                 try
                 {
                 Task<Boolean> deletedProprietaire = _repository.deleteProprietaire(Id);
                if (deletedProprietaire.Result == true)
                {
                    ViewBag.Message = "L' utilisateur a été suprimé avec success";
                    var proprietaires = _repository.getAllProprietaire();
                    return RedirectToAction("Index", proprietaires);
                }
                else {
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
            /* [HttpGet("getProprietaire/{proprietaireId}")]
             public Task<Proprietaire> getProprietaireById(int proprietaireId)
             {
                 try
                 {

                     var proprietaire = _repository.getProprietaireById(proprietaireId);
                     return proprietaire;
                 }catch(Exception e)
                 {
                     return (Task<Proprietaire>)null;
                 }

             }
            
        */

             [HttpPost]
             public JsonResult AddEngin(Proprietaire proprietaire,Engin engin)
             {
               
                 
                     var result = _repository.setEnginToProprietaire(proprietaire, engin);
               
                

                    return Json("engin");
                
               

             }
        [HttpGet("createProprietareEngin")]
        public String createProprietaireAndEngin()
        {
            var engin = new Engin
            {

                immatriculation = "AB-123-CDE",
                marque = "Toyota",
                couleur = "Bleu",
                categorie = Categorie.Voiture
            };
            var proprietaire = new Proprietaire
            {

                name = "Jean Dup",
                type = ProprietaireType.Soeur
            };
            try
            {
                String result = _repository.setEnginToProprietaire(proprietaire, engin);
                return result;

            }
            catch (Exception e)
            {

                return "erreur" + e.InnerException;
            }
        }

    }
}
