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
    public class CommandeViewModel : ObservableObject
    {
        private readonly AppDbContext _context;
        private ObservableCollection<Commande> _commandes;
        public ObservableCollection<Commande> Commandes
        {
            get => _commandes;
            set => SetProperty(ref _commandes, value);
        }

        private Commande _selectedCommande;
        public Commande SelectedCommande
        {
            get => _selectedCommande;
            set => SetProperty(ref _selectedCommande, value);
        }

        public ICommand AddCommandeCommand { get; }
        public ICommand UpdateCommandeCommand { get; }
        public ICommand DeleteCommandeCommand { get; }

        public CommandeViewModel()
        {
            _context = new AppDbContext();

            AddCommandeCommand = new RelayCommand(AddCommande);
            UpdateCommandeCommand = new RelayCommand(UpdateCommande);
            DeleteCommandeCommand = new RelayCommand(DeleteCommande);

            LoadCommandes();
            SelectedCommande = new Commande();
        }

        private void LoadCommandes()
        {
            Commandes = new ObservableCollection<Commande>(_context.Commandes.ToList());
        }

        private void AddCommande()
        {
            if (SelectedCommande == null)
                return;

            try
            {
                _context.Commandes.Add(SelectedCommande);
                _context.SaveChanges();

                Commandes.Add(SelectedCommande);
                MessageBox.Show("Commande ajoutée avec succès !");
                SelectedCommande = new Commande();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ajout : " + ex.Message);
            }
        }

        private void UpdateCommande()
        {
            if (SelectedCommande == null)
            {
                MessageBox.Show("Veuillez sélectionner une commande à modifier.");
                return;
            }

            try
            {
                _context.Commandes.Update(SelectedCommande);
                _context.SaveChanges();
                MessageBox.Show("Commande modifiée avec succès !");
                LoadCommandes();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Erreur lors de la modification : " + ex.Message);
            }
        }

        private void DeleteCommande()
        {
            if (SelectedCommande == null)
            {
                MessageBox.Show("Veuillez sélectionner une commande à supprimer.");
                return;
            }

            var confirm = MessageBox.Show("Voulez-vous supprimer cette commande ?", "Confirmation", MessageBoxButton.YesNo);
            if (confirm == MessageBoxResult.Yes)
            {
                try
                {
                    _context.Commandes.Remove(SelectedCommande);
                    _context.SaveChanges();
                    Commandes.Remove(SelectedCommande);
                    MessageBox.Show("Commande supprimée !");
                    SelectedCommande = new Commande();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Erreur lors de la suppression : " + ex.Message);
                }
            }
        }
    }
}
