﻿using FlotteApplication.Models;
using FlotteApplication.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FlotteApplication.Controllers
{
    public class FactureController : Controller
    {
        IFacture _repository;
        public FactureController(IFacture repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public String addFacture()
        {

            Facture facture = new Facture
            {
                montatTotal = 500,
                enginId = 1
            };
            try
            {
                var result = _repository.addFacture(facture);
                return result;
            }
            catch(Exception ex) {
                return null;
        }
    }
        [HttpDelete("DeleteFacture/{id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                Task<Facture> deletedFacture = _repository.deleteFacture(Id);
                
                    ViewBag.Message = "L' utilisateur a été suprimé avec success";
                    var factures = _repository.getAllFacture();
                    return RedirectToAction("Index", factures);
                
            }
            catch (Exception ex)
            {
                ViewBag.Message = "L' utilisateur a été suprimé avec success";
                return RedirectToAction("Index");
            }
        }
        [HttpGet("Facture/{id}")]
        public async Task<Facture> getFacture(int id)
        {
            return await _repository.getFactureById(id);
        }
        [HttpGet("Facture")]
        public List<Facture> getAllFacture()
        {
            return _repository.getAllFacture();
        }

}
}
