using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danielle_Mathieu_Josia_Orevil_UA2.Model
{
    public partial class Role: ObservableObject
    {
        [Key]
        public int idRole { get; set; }

        [ObservableProperty]
        public string nomRole;

        [ObservableProperty]
        public string description;

        //Relation 1-N avec User
        public ICollection<User> Users { get; set; } 
    }
}
