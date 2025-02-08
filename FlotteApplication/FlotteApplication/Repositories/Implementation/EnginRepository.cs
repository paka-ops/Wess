using System.Reflection.Metadata.Ecma335;
using System.Transactions;
using FlotteApplication.Data;
using FlotteApplication.Models;
using FlotteApplication.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlotteApplication.Repositories.Implementation
{
    public class EnginRepository : IEngin
    {
         public Boolean IsEnginExist(int enginId) 
        {
            var enginContext = new DataSource();
            var existEngin = enginContext.Engin.Where(e => e.enginId == enginId);
            if(existEngin.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public async Task<Facture> addFacture(Facture facture)
        {
            using (var factureContext = new DataSource())
            {
                var enginExists = await factureContext.Engin.AnyAsync(e => e.enginId == facture.enginId);

                if (!enginExists)
                {
                    throw new InvalidOperationException("L'engin spécifié n'existe pas.");
                }

                // Associe la facture à l'ID de l'engin existant
                factureContext.Attach(facture);
                factureContext.Facture.Add(facture);

                try
                {
                    await factureContext.SaveChangesAsync();
                    return facture;
                }
                catch (DbUpdateException ex)
                {
                    throw new InvalidOperationException("Erreur lors de l'enregistrement : " + ex.InnerException?.Message, ex);
                }
            }
        }


        public Engin deleteEngin(int EnginId)
        {
            throw new NotImplementedException();
        }

        public Engin getAllEngin()
        {
            throw new NotImplementedException();
        }
        
        public async Task<Engin> getEngineById(int enginId)
        {
            using (var enginContext = new DataSource())
            {
                var engin = await enginContext.Engin.FirstOrDefaultAsync(e => e.enginId == enginId);


                if (engin != null)
                {
                    return engin;
                }
                else
                {
                    return null;
                }
            }
        }

        public Engin updateEngin(int EnginId)
        {
            throw new NotImplementedException();
        }

        public Task<string> createEngin(Engin engin)
        {
            throw new NotImplementedException();
        }
    }
}
