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
    public class ClientViewModel : ObservableObject
    {
        private readonly AppDbContext _context;
        private ObservableCollection<Client> _clients;

        public ObservableCollection<Client> Clients
        {
            get => _clients;
            set => SetProperty(ref _clients, value);
        }

        private Client _selectedClient;
        public Client SelectedClient
        {
            get => _selectedClient;
            set => SetProperty(ref _selectedClient, value);
        }

        public ICommand AddClientCommand { get; }
        public ICommand UpdateClientCommand { get; }
        public ICommand DeleteClientCommand { get; }

        public ClientViewModel()
        {
            _context = new AppDbContext();

            AddClientCommand = new RelayCommand(AddClient);
            UpdateClientCommand = new RelayCommand(UpdateClient);
            DeleteClientCommand = new RelayCommand(DeleteClient);

            LoadClients();
            SelectedClient = new Client(); 
        }

        private void LoadClients()
        {
            var allclients = _context.Clients.ToList();
            Clients = new ObservableCollection<Client>(allclients);
        }

        private void AddClient()
        {
            if (SelectedClient == null)
                return;

            if (!SelectedClient.IsValid(out var errors))
            {
                ShowValidationErrors(errors);
                return;
            }

            try
            {
                _context.Clients.Add(SelectedClient);
                _context.SaveChanges();

                Clients.Add(SelectedClient); 
                MessageBox.Show("Client ajouté avec succès !");
                SelectedClient = new Client(); 
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ajout : " + ex.Message);
            }
        }

        private void UpdateClient()
        {
            if (SelectedClient == null)
            {
                MessageBox.Show("Veuillez sélectionner un client à modifier.");
                return;
            }

            if (!SelectedClient.IsValid(out var errors))
            {
                ShowValidationErrors(errors);
                return;
            }

            try
            {
                _context.Clients.Update(SelectedClient);
                _context.SaveChanges();
                MessageBox.Show("Client modifié avec succès !");
                LoadClients(); 
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Erreur lors de la modification : " + ex.Message);
            }
        }

        private void DeleteClient()
        {
            if (SelectedClient == null)
            {
                MessageBox.Show("Veuillez sélectionner un client à supprimer.");
                return;
            }

            var confirm = MessageBox.Show("Voulez-vous supprimer ce client ?", "Confirmation", MessageBoxButton.YesNo);
            if (confirm == MessageBoxResult.Yes)
            {
                try
                {
                    _context.Clients.Remove(SelectedClient);
                    _context.SaveChanges();
                    Clients.Remove(SelectedClient);
                    MessageBox.Show("Client supprimé !");
                    SelectedClient = new Client();
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
