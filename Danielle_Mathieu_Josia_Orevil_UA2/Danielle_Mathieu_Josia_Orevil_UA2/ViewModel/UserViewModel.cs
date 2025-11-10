using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Danielle_Mathieu_Josia_Orevil_UA2.Data;
using Danielle_Mathieu_Josia_Orevil_UA2.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Danielle_Mathieu_Josia_Orevil_UA2.ViewModel
{
    public partial class UserViewModel : ObservableObject
    {
        private readonly AppDbContext context;

        [ObservableProperty]
        private ObservableCollection<User> users;
        
        [ObservableProperty]
        private User selectedUser;

        [ObservableProperty]
        private string userNom;
        [ObservableProperty]
        private string userPrenom;
        [ObservableProperty]
        private string userUserName;
        [ObservableProperty]
        private string userUserPassword;
        [ObservableProperty]
        private string userEmail;
  
      

        //definition du constructeur
      
        public ICommand AddUserCommand { get; }
        public ICommand UpdateUserCommand { get; }
        public ICommand DeleteUserCommand { get; }

        public UserViewModel()
        {
            context = new AppDbContext();

            AddUserCommand = new RelayCommand(AddUser);
            //UpdateUserCommand = new RelayCommand(UpdateUser);
            //DeleteUserCommand = new RelayCommand(DeleteUser);

            LoadUsers();
            //SelectedUser = new User();
        }

        private void LoadUsers()
        {
            var allUsers = context.Users.ToList();
            Users = new ObservableCollection<User>(allUsers);
        }

        private void AddUser()
        {

            try
            {
                var newUser = new User
                {
                    Nom = UserNom,
                    Prenom = UserPrenom,
                    UserName = UserUserName,
                    UserPassword = UserUserPassword,
                    Email = UserEmail,
                    idRole = 1
                };

                context.Users.Add(newUser);
                context.SaveChanges();
                Users.Add(newUser);
                MessageBox.Show("Utilisateur ajouté avec succès !");

               /* UserNom = string.Empty;
                UserPrenom = string.Empty;
                UserUserName = string.Empty;
                UserUserPassword = string.Empty;
                UserEmail = string.Empty;*/
            }

            catch (System.Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null)
                    message += "\nInner exception: " + ex.InnerException.Message;
                MessageBox.Show("Erreur lors de l'ajout : " + ex.Message);
            }
        }

       /* private void UpdateUser()
        {
            if (SelectedUser == null)
            {
                MessageBox.Show("Veuillez sélectionner un utilisateur à modifier.");
                return;
            }

            try
            {
                _context.Users.Update(SelectedUser);
                _context.SaveChanges();
                MessageBox.Show("Utilisateur modifié avec succès !");
                LoadUsers();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Erreur lors de la modification : " + ex.Message);
            }
        }

        private void DeleteUser()
        {
            if (SelectedUser == null)
            {
                MessageBox.Show("Veuillez sélectionner un utilisateur à supprimer.");
                return;
            }

            var confirm = MessageBox.Show("Voulez-vous supprimer cet utilisateur ?", "Confirmation", MessageBoxButton.YesNo);
            if (confirm == MessageBoxResult.Yes)
            {
                try
                {
                    _context.Users.Remove(SelectedUser);
                    _context.SaveChanges();
                    Users.Remove(SelectedUser);
                    MessageBox.Show("Utilisateur supprimé !");
                    SelectedUser = new User();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Erreur lors de la suppression : " + ex.Message);
                }
            }
        }*/
    }
}
