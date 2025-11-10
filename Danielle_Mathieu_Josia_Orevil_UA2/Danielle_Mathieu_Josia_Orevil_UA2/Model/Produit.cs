using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danielle_Mathieu_Josia_Orevil_UA2.Model
{
    public class Produit : ObservableObject
    {
        [Key]
        public int idProduit { get; set; }
        public string nomProduit { get; set; }
        public string description { get; set; }
        public string categorie {  get; set; }
        public decimal prix { get; set; }
        public int quantiteStock { get; set; }
        public bool estDisponible { get; set; }

        //Relation 1-N avec CommandeProduit
        public ICollection<CommandeProduit> CommandeProduits { get; set; }=new List<CommandeProduit>();
    }
}
