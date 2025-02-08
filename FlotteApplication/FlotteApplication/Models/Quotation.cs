namespace FlotteApplication.Models
{
    public class Quotation
    {
        public int quotationId;
        public float valeurDuVehicule { get; set; }
        public float tarifDeBase { get; set; }
        public float reduction { get; set; }
        public float majoration { get; set; }
        public Facture Facture { get; set; }
      

    }
}
 