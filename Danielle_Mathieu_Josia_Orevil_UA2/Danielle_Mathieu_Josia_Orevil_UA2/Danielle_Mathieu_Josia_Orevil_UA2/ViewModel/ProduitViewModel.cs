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
    public class ProduitViewModel : ObservableObject
    {
        private readonly AppDbContext _context;
        private ObservableCollection<Produit> _produits;
        public ObservableCollection<Produit> Produits
        {
            get => _produits;
            set => SetProperty(ref _produits, value);
        }

        private Produit _selectedProduit;
        public Produit SelectedProduit
        {
            get => _selectedProduit;
            set => SetProperty(ref _selectedProduit, value);
        }

        public ICommand AddProduitCommand { get; }
        public ICommand UpdateProduitCommand { get; }
        public ICommand DeleteProduitCommand { get; }

        public ProduitViewModel()
        {
            _context = new AppDbContext();

            AddProduitCommand = new RelayCommand(AddProduit);
            UpdateProduitCommand = new RelayCommand(UpdateProduit);
            DeleteProduitCommand = new RelayCommand(DeleteProduit);

            LoadProduits();
            SelectedProduit = new Produit();
        }

        private void LoadProduits()
        {
            Produits = new ObservableCollection<Produit>(_context.Produits.ToList());
        }

        private void AddProduit()
        {
            if (SelectedProduit == null)
                return;

            try
            {
                _context.Produits.Add(SelectedProduit);
                _context.SaveChanges();

                Produits.Add(SelectedProduit);
                MessageBox.Show("Produit ajouté avec succès !");
                SelectedProduit = new Produit();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ajout : " + ex.Message);
            }
        }

        private void UpdateProduit()
        {
            if (SelectedProduit == null)
            {
                MessageBox.Show("Veuillez sélectionner un produit à modifier.");
                return;
            }

            try
            {
                _context.Produits.Update(SelectedProduit);
                _context.SaveChanges();
                MessageBox.Show("Produit modifié avec succès !");
                LoadProduits();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Erreur lors de la modification : " + ex.Message);
            }
        }

        private void DeleteProduit()
        {
            if (SelectedProduit == null)
            {
                MessageBox.Show("Veuillez sélectionner un produit à supprimer.");
                return;
            }

            var confirm = MessageBox.Show("Voulez-vous supprimer ce produit ?", "Confirmation", MessageBoxButton.YesNo);
            if (confirm == MessageBoxResult.Yes)
            {
                try
                {
                    _context.Produits.Remove(SelectedProduit);
                    _context.SaveChanges();
                    Produits.Remove(SelectedProduit);
                    MessageBox.Show("Produit supprimé !");
                    SelectedProduit = new Produit();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Erreur lors de la suppression : " + ex.Message);
                }
            }
        }
    }
}
