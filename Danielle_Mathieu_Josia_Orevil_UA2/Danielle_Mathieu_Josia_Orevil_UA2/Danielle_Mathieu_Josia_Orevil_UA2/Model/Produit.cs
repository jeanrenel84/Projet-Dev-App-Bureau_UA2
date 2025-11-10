using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danielle_Mathieu_Josia_Orevil_UA2.Model
{
    public partial class Produit : ObservableObject
    {
        [Key]
        public int idProduit { get; set; }

        [ObservableProperty]
        private string nomProduit;

        [ObservableProperty]
        private string description;

        [ObservableProperty]
        private string categorie;

        [ObservableProperty]
        private decimal prix;

        [ObservableProperty]
        private int quantiteStock;

        [ObservableProperty]
        private bool estDisponible;

        //Relation 1-N avec CommandeProduit
        public ICollection<CommandeProduit> CommandeProduits { get; set; }=new List<CommandeProduit>();

        public bool IsValid(out List<string> errors)
        {
            errors = new List<string>();
            if (string.IsNullOrWhiteSpace(NomProduit))
                errors.Add("Le nom du produit est obligatoire.");
            if (Prix <= 0)
                errors.Add("Le prix doit être supérieur à 0.");
            if (QuantiteStock < 0)
                errors.Add("La quantité ne peut pas être négative.");
            return errors.Count == 0;
            
        }
    }
}
