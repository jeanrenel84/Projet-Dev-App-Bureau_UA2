using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danielle_Mathieu_Josia_Orevil_UA2.Model
{
    public partial class Client : ObservableObject
    {
        [Key]
        public int idClient { get; set; }
        [ObservableProperty]
        public string nom;
        [ObservableProperty]
        public string prenom;
        [ObservableProperty]
        public string adresse;
        [ObservableProperty]
        public string email;
        [ObservableProperty]
        public string telephone;

        //Relation 1-N avec Commande
        public ICollection<Commande> commandes { get; set; } = new List<Commande>();

        // Validation des champs
        public bool IsValid(out List<string> errors)
        {
            errors = new List<string>();
            if (string.IsNullOrWhiteSpace(nom)) errors.Add("Le nom est obligatoire.");
            if (string.IsNullOrWhiteSpace(prenom)) errors.Add("Le prénom est obligatoire.");
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@")) errors.Add("Format d'email invalide.");
            return errors.Count == 0;
        }
    }
}
