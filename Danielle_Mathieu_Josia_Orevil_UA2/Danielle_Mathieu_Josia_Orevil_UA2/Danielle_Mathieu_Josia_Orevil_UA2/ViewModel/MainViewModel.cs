using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Danielle_Mathieu_Josia_Orevil_UA2.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Danielle_Mathieu_Josia_Orevil_UA2.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        private object _currentView;
        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        public ICommand NavigateToProduitsCommand { get; }
        public ICommand NavigateToClientsCommand { get; }
        public ICommand NavigateToCommandesCommand { get; }
        public ICommand NavigateToUsers { get; }
        public ICommand NavigateToRoles { get; }

        public ICommand LogoutCommand { get; }

        public MainViewModel()
        {
            NavigateToProduitsCommand = new RelayCommand(() => CurrentView = new ProduitView());
            NavigateToClientsCommand = new RelayCommand(() => CurrentView = new ClientView());
            NavigateToCommandesCommand = new RelayCommand(() => CurrentView = new CommandeView());
            NavigateToUsers = new RelayCommand(() => CurrentView = new UserView());
            NavigateToRoles = new RelayCommand(() => CurrentView = new RoleView());
            LogoutCommand = new RelayCommand(Logout);

            // Vue par défaut
             CurrentView = new ClientView(); // ou une vue d'accueil
        }


        private void Logout()
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
