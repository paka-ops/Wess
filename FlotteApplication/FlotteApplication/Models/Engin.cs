
using System.Text.Json.Serialization;
using FlotteApplication.Enum;

namespace FlotteApplication.Models
{
    public class Engin
    {
        public int enginId { get; set; }
        public String immatriculation {  get; set; }
        public string marque { get; set; }
        public string couleur { get; set; }
        public Categorie categorie { get; set; }
        [JsonIgnore]
        public List<Facture> factures { get; set; } 
        
        public int ProprietaireId { set; get; }
        public Proprietaire Proprietaire {  get; set; }
        
    }
}
