

using System.Data.SqlTypes;

namespace FlotteApplication.Models
{
    public class Facture
    {
        public int factureId {  get; set; }
        public string  dateFacture { get; set; }
        public float montatTotal { get; set; } 
        public int enginId { get; set; }
        public Engin Engin { get; set; }
        public int? quotationId {  get; set; }
        public Quotation Quotation {  get; set; }
        
        

    }
}
