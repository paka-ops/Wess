using FlotteApplication.Models;
using Microsoft.Identity.Client;

namespace FlotteApplication.Repositories.Interface
{
    public interface IProprietaire
    {
        public Task<Boolean> createProprietaire(Proprietaire proprietaire);
        public Proprietaire updateProprietaire(Proprietaire proprietaire);
        public Task<Boolean> deleteProprietaire(int proprietaireId);
        public Proprietaire getProprietaireById(int proprietaireId);
        public List<Engin>  getProprietaireEngin(int proprietaireId);
        public List<Facture> getProprietaireFacture(int proprietaireId);
        public List<Proprietaire> getAllProprietaire();

        public String setEnginToProprietaire(Proprietaire proprietaire, Engin engin);
        
    }
}
