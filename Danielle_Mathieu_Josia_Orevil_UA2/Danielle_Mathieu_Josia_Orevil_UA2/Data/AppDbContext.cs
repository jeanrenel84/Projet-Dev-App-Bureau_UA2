using Danielle_Mathieu_Josia_Orevil_UA2.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danielle_Mathieu_Josia_Orevil_UA2.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<Model.User> Users { get; set; }
        public DbSet<Model.Role> Roles { get; set; }
        public DbSet<Model.Client> Clients { get; set; }
        public DbSet<Model.Commande> Commandes { get; set; }
        public DbSet<Model.Produit> Produits { get; set; }
        public DbSet<Model.CommandeProduit> CommandeProduits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=./Data/sysgestock.db");
        }


        // Code pour creation les relations entres les classes produit
        // Commande, et CommandeProduit
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            // Creation de la clé composee pour CommandeProduit
            modelBuilder.Entity<CommandeProduit>()
                .HasKey(cp => new { cp.IdCommande, cp.IdProduit });

            // Relation entre Commande  et CommandeProduit (1-N)
            modelBuilder.Entity<CommandeProduit>()
                .HasOne(cp => cp.Commandes)
                .WithMany(c => c.CommandeProduits)
                .HasForeignKey(cp => cp.IdCommande);

            // Relation entre Produit et CommandeProduit (1-N)
            modelBuilder.Entity<CommandeProduit>()
                .HasOne(cp => cp.Produits)
                .WithMany(p => p.CommandeProduits)
                .HasForeignKey(cp => cp.IdProduit);
           }

        }
}
