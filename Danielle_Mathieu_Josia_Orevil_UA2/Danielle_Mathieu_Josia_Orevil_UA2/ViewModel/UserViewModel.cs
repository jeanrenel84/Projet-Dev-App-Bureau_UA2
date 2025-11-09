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
        private readonly AppDbContext _context;

        [ObservableProperty]
        private ObservableCollection<User> users;
        /* public ObservableCollection<User> Users
         {
             get => _users;
             set => SetProperty(ref _users, value);
         }*/
        [ObservableProperty]
        private User _selectedUser;

        [ObservableProperty]
        private string nom;
        [ObservableProperty]
        private string prenom;
        [ObservableProperty]
        private string userName;
        [ObservableProperty]
        private string userPassword;
        [ObservableProperty]
        private string email;
        //[ObservableProperty]
        //private int idRole;




        /*  public User SelectedUser
          {
              get => _selectedUser;
              set => SetProperty(ref _selectedUser, value);
          }*/

        //definition du constructeur
      
        public ICommand AddUserCommand { get; }
        public ICommand UpdateUserCommand { get; }
        public ICommand DeleteUserCommand { get; }

        public UserViewModel()
        {
            _context = new AppDbContext();

            AddUserCommand = new RelayCommand(AddUser);
            //UpdateUserCommand = new RelayCommand(UpdateUser);
            //DeleteUserCommand = new RelayCommand(DeleteUser);

            LoadUsers();
            //SelectedUser = new User();
        }

        private void LoadUsers()
        {
            Users = new ObservableCollection<User>(_context.Users.ToList());
        }

        private void AddUser()
        {
            /*if (SelectedUser == null)
                return;*/

            try
            {
                var newUser = new User
                {
                    Nom = Nom,
                    Prenom = Prenom,
                    UserName = UserName,
                    UserPassword = UserPassword,
                    Email = Email,
                   // IdRole = IdRole
                };
                
                _context.Users.Add(newUser);
                _context.SaveChanges();
                Users.Add(newUser);
                MessageBox.Show("Utilisateur ajouté avec succès !");
                nom = string.Empty;
                prenom = string.Empty;
                userName = string.Empty;
                userPassword = string.Empty;
                email = string.Empty;
                //idRole = 0;

                /* _context.Users.Add(SelectedUser);
                 _context.SaveChanges();

                 Users.Add(SelectedUser);
                 MessageBox.Show("Utilisateur ajouté avec succès !");
                 SelectedUser = new User();*/
            }
            catch (System.Exception ex)
            {
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
