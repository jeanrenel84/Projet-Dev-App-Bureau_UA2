using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danielle_Mathieu_Josia_Orevil_UA2.Model
{
    public class Client
    {
        [Key]
        public int IdClient { get; set; }
        public string nom {  get; set; }
        public string prenom { get; set; }
        public string adresse { get; set; }
        public string email { get; set; }
        public string telephone { get; set; }

        //Relation 1-N avec Commande
        public ICollection<Commande> commandes { get; set; } = new List<Commande>();
    }
}
