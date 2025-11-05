using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danielle_Mathieu_Josia_Orevil_UA2.Model
{
   public class User
    {
        [Key]
        public int IdUser { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string Email { get; set; }


        //Cle etrangere vers la classe Role
        [ForeignKey("Roles")]
        public int IdRole { get; set; }
        public Role Roles { get; set; }
      
       

    }
}
