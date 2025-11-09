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
        private readonly AppDbContext _context;
        [ObservableProperty]
        private ObservableCollection<Role> _roles;

        [ObservableProperty]
        private Role selectedRole;
        [ObservableProperty]
        private string nomRole;
        [ObservableProperty]
        private string description;



        /* public ObservableCollection<Role> Roles
         {
             get => _roles; 
             set => SetProperty(ref _roles, value); 
         }*/

        /*private Role _selectedRole; 
        public Role SelectedRole 
        {
            get => _selectedRole;
            set => SetProperty(ref _selectedRole, value); 
        }*/

        public ICommand AddRoleCommand { get; } 
        public ICommand UpdateRoleCommand { get; } 
        public ICommand DeleteRoleCommand { get; } 

        public RoleViewModel()
        {
            _context = new AppDbContext();

           AddRoleCommand = new RelayCommand(AddRole);
           // UpdateRoleCommand = new RelayCommand(UpdateRole);
            //DeleteRoleCommand = new RelayCommand(DeleteRole);

        LoadRoles();
       // SelectedRole = new Role();          
    }

        private void LoadRoles()
        {
            var allroles = _context.Roles.ToList(); 
            Roles = new ObservableCollection<Role>(allroles); 
        }

        private void AddRole()
        {
            try
            {
                var newRole = new Role
                {
                    NomRole = NomRole,
                    Description = Description

                };

                _context.Roles.Add(newRole);
                _context.SaveChanges();
                Roles.Add(newRole);

            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ajout : " + ex.Message);
            }

        }


        /*
        private void UpdateRole() // update method name from UpdateClient to UpdateRole
        {
            if (SelectedRole == null) // updated variable from SelectedClient to SelectedRole
            {
                MessageBox.Show("Veuillez sélectionner un rôle à modifier."); // updated message
                return;
            }

            if (!SelectedRole.IsValid(out var errors)) // updated variable from SelectedClient to SelectedRole
            {
                ShowValidationErrors(errors);
                return;
            }

            try
            {
                _context.Roles.Update(SelectedRole); // updated from _context.Clients to _context.Roles         
                _context.SaveChanges();
                MessageBox.Show("Role modifié avec succès !"); // updated message
                LoadRoles(); // updated method call from LoadClients to LoadRoles
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Erreur lors de la modification : " + ex.Message);
            }
        }

        private void DeleteClient()
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
                    _context.Roles.Remove(SelectedRole); // updated from _context.Clients to _context.Roles
                    _context.SaveChanges();
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
        }*/
    }
}
