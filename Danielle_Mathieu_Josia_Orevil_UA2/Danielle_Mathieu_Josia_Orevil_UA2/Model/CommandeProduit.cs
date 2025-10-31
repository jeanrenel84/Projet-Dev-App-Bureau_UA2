using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danielle_Mathieu_Josia_Orevil_UA2.Model
{
    public class CommandeProduit
    {
        public decimal PrixUnitaire {  get; set; }
        public int Quantite {  get; set; }

        //Cle etrangere vers Produit 
        public int IdProduit { get; set; }
        public Produit Produits { get; set; }

        //cle etrangere vers Commande
        public int IdCommande { get; set; }
        public Commande Commandes { get; set; }
    }
}
