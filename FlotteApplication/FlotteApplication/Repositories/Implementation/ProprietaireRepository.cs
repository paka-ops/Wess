using System.Security.Principal;
using FlotteApplication.Data;
using FlotteApplication.Models;
using FlotteApplication.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace FlotteApplication.Repositories.Implementation
{
    public class ProprietaireRepository : IProprietaire
    {
        public Boolean IsProprietaireExist(int proprietaireId)
        {
            var proprietaireContext = new DataSource();
            var existProprietaire = proprietaireContext.Proprietaire.Where(e => e.proprietaireId == proprietaireId);
            if (existProprietaire.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public async Task<Boolean> createProprietaire(Proprietaire proprietaire)
        {
            var IsExist = IsProprietaireExist(proprietaire.proprietaireId);
            if (IsExist == true)
            {
                return false;
            }
            else
            {
                try
                {
                    using (var proprietaireContext = new DataSource())
                    {
                        proprietaireContext.Add(proprietaire);
                        await proprietaireContext.SaveChangesAsync();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public async Task<bool> deleteProprietaire(int proprietaireId)
        {
            using (var proprietaireContext = new DataSource())
            {
                if (IsProprietaireExist(proprietaireId))
                {
                    var proprietaire = await proprietaireContext.Proprietaire
                        .FirstOrDefaultAsync(e => e.proprietaireId == proprietaireId);

                    if (proprietaire != null)
                    {
                        proprietaireContext.Proprietaire.Remove(proprietaire);
                        await proprietaireContext.SaveChangesAsync();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }


        public Proprietaire getProprietaireById(int proprietaireId)
        {
            using (var proprietaireContext = new DataSource())
            {
                var proprietaire = proprietaireContext.Proprietaire
                .FirstOrDefault(e => e.proprietaireId == proprietaireId);

                if (proprietaire != null)
                {
                    return proprietaire;
                }
                else
                {
                    return null;
                }
            }
        }

        public List<Facture> getProprietaireFacture(int proprietaireId)
        {
            throw new NotImplementedException();
        }

        public Proprietaire updateProprietaire(Proprietaire proprietaire)
        {
            using (var proprietaireContext = new DataSource())
            {
                var isExist = IsProprietaireExist(proprietaire.proprietaireId);
                if (isExist == true)
                {
                    var updateProprietaire = proprietaireContext.Proprietaire.FirstOrDefault(e => e.proprietaireId == proprietaire.proprietaireId);
                    updateProprietaire.name = proprietaire.name;
                    updateProprietaire.type = proprietaire.type;

                    proprietaireContext.SaveChanges();
                    return updateProprietaire;
                }
                else
                {
                    return null;
                }
            }
        }

        public List<Engin> getProprietaireEngin(int proprietaireId)
        {
            return null;
        }



        public List<Proprietaire> getAllProprietaire()
        {
            using (var proprietaireContext = new DataSource())
            {
                return proprietaireContext.Proprietaire.ToList();

            }

        }
        public String setEnginToProprietaire(Proprietaire proprietaire, Engin engin)
        {
            using (var proprietaireContext = new DataSource())
            {
                try
                {
                    if (IsProprietaireExist(proprietaire.proprietaireId) == false)
                    {
                        proprietaire.ListEngins = new List<Engin>();
                    }
                    else
                    {
                        var proprietaireEngin = proprietaireContext.Proprietaire.Include(p => p.ListEngins)
                                                                                .FirstOrDefault(p => p.proprietaireId == proprietaire.proprietaireId);
                        proprietaire.ListEngins = proprietaireEngin.ListEngins;
                    }

                    proprietaire.ListEngins.Add(engin);
                    var isAdd = proprietaireContext.Proprietaire.Add(proprietaire);

                    proprietaireContext.SaveChanges();
                    if (isAdd.GetDatabaseValues() == null)
                    {
                        return "erreur";
                    }
                    else
                    {
                        return "ça a marché";
                    }


                }
                catch (Exception ex)
                {
                    return "erreur" + ex.InnerException;
                }
            }
        }



    }
    }
