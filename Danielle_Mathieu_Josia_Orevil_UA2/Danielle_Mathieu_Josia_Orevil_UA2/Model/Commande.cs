using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danielle_Mathieu_Josia_Orevil_UA2.Model
{
   public partial class Commande : ObservableObject
    {
        [Key]
        public int IdCommande { get; set; }
        [ObservableProperty]
        public DateTime dateCommande= DateTime.Now;

        //Cle etrangere vers client
        public int idClient { get; set; }   
        public Client Client { get; set; }

        //Relation 1-N vers CommandeProduit
        public ICollection<CommandeProduit> CommandeProduits { get; set; }= new List<CommandeProduit>();

    }
}
