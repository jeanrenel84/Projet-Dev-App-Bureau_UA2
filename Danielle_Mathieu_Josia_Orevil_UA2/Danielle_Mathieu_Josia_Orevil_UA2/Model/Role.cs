using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danielle_Mathieu_Josia_Orevil_UA2.Model
{
    public class Role
    {
        [Key]
        public int IdRole { get; set; }
        public string NomRole { get; set; }
        public string tache { get; set; }

        //Relation 1-N avec les utilisateurs
        public ICollection<Role> Roles { get; set; } = new List<Role>();
    }
}
