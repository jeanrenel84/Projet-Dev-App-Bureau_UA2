using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danielle_Mathieu_Josia_Orevil_UA2.Model
{
   public partial class User: ObservableObject
    {
        [Key]
        public int idUser { get; set; }

        [ObservableProperty]
        public string nom;
        [ObservableProperty]
        public string prenom;
        [ObservableProperty]
        public string userName;
        [ObservableProperty]
        public string userPassword;
        [ObservableProperty]
        public string email;

        //Cle etrangere vers la classe Role
        [ForeignKey("Roles")]
        public int idRole { get; set; }
        public Role Roles { get; set; }
      
       

    }
}
