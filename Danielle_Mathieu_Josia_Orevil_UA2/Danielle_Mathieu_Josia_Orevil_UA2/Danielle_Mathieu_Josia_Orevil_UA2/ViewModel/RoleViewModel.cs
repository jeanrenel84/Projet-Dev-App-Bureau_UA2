using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Danielle_Mathieu_Josia_Orevil_UA2.Data;
using Danielle_Mathieu_Josia_Orevil_UA2.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;

namespace Danielle_Mathieu_Josia_Orevil_UA2.ViewModel
{
    public partial class RoleViewModel : ObservableObject
    {
        private readonly AppDbContext context;
        [ObservableProperty]
        private ObservableCollection<Role> roles;

        [ObservableProperty]
        private Role selectedRole;
        [ObservableProperty]
        private string roleName;
        [ObservableProperty]
        private string roleDescription;



        public ICommand AddRoleCommand { get; } 
        public ICommand UpdateRoleCommand { get; } 
        public ICommand DeleteRoleCommand { get; } 

        public RoleViewModel()
        {
            context = new AppDbContext();

           AddRoleCommand = new RelayCommand(AddRole);
           UpdateRoleCommand = new RelayCommand(UpdateRole);
           DeleteRoleCommand = new RelayCommand(DeleteRole);

        LoadRoles();
         
        }

        private void LoadRoles()
        {
            var allroles = context.Roles.ToList(); 
            Roles = new ObservableCollection<Role>(allroles); 
        }

        private void AddRole()
        {
            try
            {
                var newRole = new Role
                {

                    Description=RoleDescription,
                    NomRole= RoleName

                };

                context.Roles.Add(newRole);
                context.SaveChanges();
                Roles.Add(newRole);
                MessageBox.Show("Rôle ajouté avec succès !");

            }
            catch (System.Exception ex)
            {
                  MessageBox.Show("Erreur lors de l'ajout : " + ex.Message);
            }

        }


        
        private void UpdateRole() 
        {
            if (SelectedRole == null)
                return;

            SelectedRole.Description = RoleDescription;
            SelectedRole.NomRole = RoleName;

            context.Roles.Update(SelectedRole);
            context.SaveChanges();
            MessageBox.Show("Rôle mis à jour avec succès !");

            // Optionnel : reset formulaire
            SelectedRole = null; 
            RoleDescription = string.Empty; 
            RoleName = string.Empty;
        }

        partial void OnSelectedRoleChanged(Role value)
        {
            if (value != null)
            {
                RoleName = value.NomRole;
                RoleDescription = value.Description;

            }
            else
            {
                RoleName = string.Empty;

                RoleDescription = string.Empty;
            }
        }

        private void DeleteRole()
        {
            if (SelectedRole == null)
            {
                MessageBox.Show("Veuillez sélectionner un rôle à supprimer."); // updated message
                return;
            }

            var confirm = MessageBox.Show("Voulez-vous supprimer ce rôle ?", "Confirmation", MessageBoxButton.YesNo); // updated message
            if (confirm == MessageBoxResult.Yes)
            {
                try
                {
                    context.Roles.Remove(SelectedRole); // updated from _context.Clients to _context.Roles
                    context.SaveChanges();
                    Roles.Remove(SelectedRole); // updated from Clients to Roles
                    MessageBox.Show("Rôle supprimé !"); // updated message
                    SelectedRole = new Role(); // updated from SelectedClient to SelectedRole
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Erreur lors de la suppression : " + ex.Message);
                }
            }
        }

       

        private void ShowValidationErrors(List<string> errors)
        {
            string errorMessage = string.Join("\n", errors);
            MessageBox.Show(errorMessage, "Erreur de validation", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
