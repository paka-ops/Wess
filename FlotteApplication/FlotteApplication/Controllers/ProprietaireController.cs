using System.Reflection.Metadata.Ecma335;
using FlotteApplication.Enum;
using FlotteApplication.Models;
using FlotteApplication.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

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
            var proprietaires =  _repository.getAllProprietaire();
            return View("Index",proprietaires);
        }
        public ViewResult addProprietaire(Proprietaire proprietaire)
        {

            try
            {
                Task<Boolean> result = _repository.createProprietaire(proprietaire);
                if (result.Result == true)
                {
                    return View("Index");
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
        public IActionResult Edit(Proprietaire proprietaire)
        {
            /*f (ModelState.IsValid)
            {
                _r.Proprietaires.Update(proprietaire);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }*/
            return PartialView("_EditProprietairePartial");
        }
        // [HttpDelete("deleteProprietaire/{proprietaireId}")]
        /* public ViewResult deleteProprietaire(int proprietaireId)
         {
             try
             {
                 var proprietaire = _repository.deleteProprietaire(proprietaireId);
                 return (Task<Proprietaire>)proprietaire;
             }
             catch (Exception ex)
             {
                 return (Task<Proprietaire>)null;
             }
         }
         [HttpGet("getProprietaire/{proprietaireId}")]
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


         [HttpGet("createProprietareEngin")]
         public ViewResult createProprietaireAndEngin()
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

             }catch(Exception e)
             {

                 return "erreur" + e .InnerException;
             }
         }*/
    }
}