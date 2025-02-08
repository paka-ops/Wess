using System.Diagnostics.Eventing.Reader;
using FlotteApplication.Data;
using FlotteApplication.Models;
using FlotteApplication.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace FlotteApplication.Repositories.Implementation
{
    public class FactureRepository : IFacture

    {
        public Boolean IsFactureExist(int factureId)
        {
            var factureContext = new DataSource();
            var existFacture = factureContext.Facture.Where(e => e.factureId == factureId);
            if (existFacture.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private  Boolean IsEnginExist(int enginId)
        {
            using (var context = new DataSource())
            {
                return  context.Engin.Any(e => e.enginId == enginId);
            }
        }


        public async Task<Facture> deleteFacture(int factureId)
        {
            using (var factureContext = new DataSource())
            {
                var facture = await factureContext.Facture
                    .FirstOrDefaultAsync(e => e.factureId == factureId);

                if (facture != null)
                {
                    factureContext.Facture.Remove(facture);
                    await factureContext.SaveChangesAsync();
                    return facture;
                }

                return null;
            }
        }

        public async Task<Facture> getFactureById(int factureId)
        {
            using (var factureContext = new DataSource())
            {
                var facture = await factureContext.Facture
                    .FirstOrDefaultAsync(e => e.factureId == factureId);


                if (facture != null)
                {
                    return facture;
                }
                else
                {
                    return null;
                }
            }
        }


        public List<Facture> getAllFacture()
        {
            using (var factureContext = new DataSource())
            {
                return factureContext.Facture.ToList();

            }

        }



        public Facture updateFacture(int factureId)
        {
            throw new NotImplementedException();
        }

        public String addFacture(Facture facture)
        {
            var IsExist = IsFactureExist(facture.factureId);
            if (IsExist == true)
            {
                return "Il existe déjà";
            }
            else
            {
                if (IsEnginExist(facture.enginId) == true)
                {
                    try
                    {
                        using (var factureContext = new DataSource())
                        {
                            Engin engin = factureContext.Engin.FirstOrDefault(e => e.enginId == facture.enginId);
                            var enginFacture = factureContext.Engin.Include(e => e.factures)
                                           .FirstOrDefault(e => e.enginId == facture.enginId);
                            if (enginFacture == null)
                            {
                                engin.factures = new List<Facture>();

                            }
                            engin.factures.Add(facture);

                            factureContext.SaveChanges();
                        }
                        return "Enregistrement effectué avec succes";
                    }
                    catch (Exception ex)
                    {
                        return " erreur " + ex.InnerException;
                    }
                }
                else
                {
                    return "il n' existe pas";
                }



            }
        }
    }
 }
