using FlotteApplication.Models;

namespace FlotteApplication.Repositories.Interface
{
    public interface IFacture
    {
        
        public Task<Facture> deleteFacture(int factureId);
        public Facture updateFacture(int factureId);
        public List<Facture> getAllFacture();
        public Task<Facture> getFactureById(int factureId);
  
        public String addFacture(Facture facture);
         
    }
}
