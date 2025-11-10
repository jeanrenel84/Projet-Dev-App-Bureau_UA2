using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danielle_Mathieu_Josia_Orevil_UA2.Model
{
    public class CommandeProduit : ObservableObject
    {

        public decimal prixUnitaire {  get; set; }
        public int quantite {  get; set; }

        //Cle etrangere vers Produit 
         public int idProduit { get; set; }
        public Produit Produits { get; set; }

        //cle etrangere vers Commande
        public int idCommande { get; set; }
        public Commande Commandes { get; set; }
    }
}
