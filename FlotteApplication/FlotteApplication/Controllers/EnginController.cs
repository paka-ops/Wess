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
            return View();
        }
        public Task<String> addEngin()
        {
            var engin = new Engin
            {

                immatriculation = "AA-123-BB",
                marque = "Toyota",
                couleur = "Blanc",
                categorie = Categorie.Voiture, // Exemple d'une catégorie possible
                factures = new List<Facture>
                {

                },
            };
            try
            {
                Task<String> result = _repository.createEngin(engin);
                return result;
            }
            catch (Exception ex)
            {

                return null;
            }

        }
        [HttpGet("getEngin/{enginId}")]
        public Task<Engin> GetEnginById(int enginId)
        {
            try
            {
                var result = _repository.getEngineById(enginId);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
