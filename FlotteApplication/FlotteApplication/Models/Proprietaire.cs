using System.Text.Json.Serialization;
using FlotteApplication.Enum;

namespace FlotteApplication.Models
{
    public class Proprietaire
    {
        public int proprietaireId { get; set; }
        public String name { get; set; }
        public ProprietaireType  type { get; set; }
        [JsonIgnore]
        public List<Engin> ListEngins { get; set; }
        


    }
}
