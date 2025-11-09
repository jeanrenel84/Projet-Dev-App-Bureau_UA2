using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Danielle_Mathieu_Josia_Orevil_UA2.View;
using Danielle_Mathieu_Josia_Orevil_UA2.Data;

namespace Danielle_Mathieu_Josia_Orevil_UA2.ViewModel
{
    public partial class LoginViewModel : ObservableObject
    {
        //creation du contexte de la base de donnees
        private readonly Data.AppDbContext _context;

        [ObservableProperty]
        private string username;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string errorMessage = string.Empty;

        //creation de la commande de login
        public ICommand LoginCommand { get; }

        //definition du constructeur
        public LoginViewModel()
        {
            _context = new Data.AppDbContext();
            LoginCommand = new RelayCommand(Login);
        }

        //definition de la methode de login
        public void Login()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrWhiteSpace(Password))
            {
                ErrorMessage=("Veuillez entrer un nom d'utilisateur et un mot de passe.");
                return;
            }

            try
            {
                var user = _context.Users.FirstOrDefault(u => u.UserName == Username && u.UserPassword == Password);

                if (user != null)
                {
                    ErrorMessage=("Connexion réussie !");
                    
                    MainView mainView = new MainView();
                    Application.Current.MainWindow.Content = mainView;
                }
                else
                {
                    ErrorMessage=("Nom d'utilisateur ou mot de passe incorrect.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                ErrorMessage =("Erreur lors de la connexion : " + ex.Message);
            }
        }
    }
}
