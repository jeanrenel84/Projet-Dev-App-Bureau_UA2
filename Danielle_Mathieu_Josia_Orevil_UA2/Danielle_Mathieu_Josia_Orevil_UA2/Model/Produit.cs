using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danielle_Mathieu_Josia_Orevil_UA2.Model
{
    public class Produit
    {
        [Key]
        public int IdProduit { get; set; }
        public string NomProduit { get; set; }
        public string Description { get; set; }
        public string Categorie {  get; set; }
        public decimal Prix { get; set; }
        public int QuantiteStock { get; set; }
        public bool EstDisponible { get; set; }

        //Relation 1-N avec CommandeProduit
        public ICollection<CommandeProduit> CommandeProduits { get; set; }=new List<CommandeProduit>();
    }
}
