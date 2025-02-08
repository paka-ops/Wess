using FlotteApplication.Data;
using FlotteApplication.Enum;
using FlotteApplication.Models;
using FlotteApplication.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlotteApplication.Controllers
{
    public class ProprietaireEnginController : Controller
    {
        IProprietaire _repository;
        public ProprietaireEnginController(IProprietaire repository)
        {
            _repository = repository;
        }
        //[HttpPost]
        //public JsonResult AddProprietaireEngin(ProprietaireEnginViewModel p)
        //{

        //       var dataSource = new DataSource(); 

        //       String  result = _repository.setEnginToProprietaire(p.Proprietaire, p.Engin);


        //            return Json(result + p.Proprietaire.proprietaireId + p.Engin.enginId);



        //    var checkProprietaire = dataSource.Proprietaire
        //        .Include(e => e.ListEngins)
        //        .FirstOrDefault(e=> e.proprietaireId == p.Proprietaire.proprietaireId);

        //    if (checkProprietaire != null && checkProprietaire.ListEngins.Any(e => e.enginId ==  p.Engin.enginId))
        //        {
        //            return Json(result);
        //        }
        //        else
        //        {
        //            return Json(result);
        //         }
        //    }
        [HttpPost]
        public JsonResult AddProprietaireEngin(ProprietaireEnginViewModel p)
        {
            // Test pour vérifier si la fonction est appelée
            Console.WriteLine("Entrée dans AddProprietaireEngin");

            var dataSource = new DataSource();
            string result = _repository.setEnginToProprietaire(p.Proprietaire, p.Engin);

            Console.WriteLine("Résultat après l'ajout : " + result);

            // Autres vérifications
            var checkProprietaire = dataSource.Proprietaire
                .Include(e => e.ListEngins)
                .FirstOrDefault(e => e.proprietaireId == p.Proprietaire.proprietaireId);

            if (checkProprietaire != null && checkProprietaire.ListEngins.Any(e => e.enginId == p.Engin.enginId))
            {
                Console.WriteLine("Engin déjà ajouté.");
                return Json(result);
            }
            else
            {
                Console.WriteLine("Nouvel ajout d'engin.");
                return Json(result);
            }
        }





    }
}
