using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Danielle_Mathieu_Josia_Orevil_UA2.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommandeProduits_Commandes_IdCommande",
                table: "CommandeProduits");

            migrationBuilder.DropForeignKey(
                name: "FK_CommandeProduits_Produits_IdProduit",
                table: "CommandeProduits");

            migrationBuilder.DropForeignKey(
                name: "FK_Commandes_Clients_ClientIdClient",
                table: "Commandes");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_IdRole",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserPassword",
                table: "Users",
                newName: "userPassword");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "userName");

            migrationBuilder.RenameColumn(
                name: "Prenom",
                table: "Users",
                newName: "prenom");

            migrationBuilder.RenameColumn(
                name: "Nom",
                table: "Users",
                newName: "nom");

            migrationBuilder.RenameColumn(
                name: "IdRole",
                table: "Users",
                newName: "idRole");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Users",
                newName: "idUser");

            migrationBuilder.RenameIndex(
                name: "IX_Users_IdRole",
                table: "Users",
                newName: "IX_Users_idRole");

            migrationBuilder.RenameColumn(
                name: "IdRole",
                table: "Roles",
                newName: "idRole");

            migrationBuilder.RenameColumn(
                name: "QuantiteStock",
                table: "Produits",
                newName: "quantiteStock");

            migrationBuilder.RenameColumn(
                name: "Prix",
                table: "Produits",
                newName: "prix");

            migrationBuilder.RenameColumn(
                name: "NomProduit",
                table: "Produits",
                newName: "nomProduit");

            migrationBuilder.RenameColumn(
                name: "EstDisponible",
                table: "Produits",
                newName: "estDisponible");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Produits",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Categorie",
                table: "Produits",
                newName: "categorie");

            migrationBuilder.RenameColumn(
                name: "IdProduit",
                table: "Produits",
                newName: "idProduit");

            migrationBuilder.RenameColumn(
                name: "ClientIdClient",
                table: "Commandes",
                newName: "ClientidClient");

            migrationBuilder.RenameColumn(
                name: "IdCommande",
                table: "Commandes",
                newName: "idCommande");

            migrationBuilder.RenameIndex(
                name: "IX_Commandes_ClientIdClient",
                table: "Commandes",
                newName: "IX_Commandes_ClientidClient");

            migrationBuilder.RenameColumn(
                name: "Quantite",
                table: "CommandeProduits",
                newName: "quantite");

            migrationBuilder.RenameColumn(
                name: "PrixUnitaire",
                table: "CommandeProduits",
                newName: "prixUnitaire");

            migrationBuilder.RenameColumn(
                name: "IdProduit",
                table: "CommandeProduits",
                newName: "idProduit");

            migrationBuilder.RenameColumn(
                name: "IdCommande",
                table: "CommandeProduits",
                newName: "idCommande");

            migrationBuilder.RenameIndex(
                name: "IX_CommandeProduits_IdProduit",
                table: "CommandeProduits",
                newName: "IX_CommandeProduits_idProduit");

            migrationBuilder.RenameColumn(
                name: "IdClient",
                table: "Clients",
                newName: "idClient");

            migrationBuilder.AddForeignKey(
                name: "FK_CommandeProduits_Commandes_idCommande",
                table: "CommandeProduits",
                column: "idCommande",
                principalTable: "Commandes",
                principalColumn: "idCommande",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommandeProduits_Produits_idProduit",
                table: "CommandeProduits",
                column: "idProduit",
                principalTable: "Produits",
                principalColumn: "idProduit",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Commandes_Clients_ClientidClient",
                table: "Commandes",
                column: "ClientidClient",
                principalTable: "Clients",
                principalColumn: "idClient",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_idRole",
                table: "Users",
                column: "idRole",
                principalTable: "Roles",
                principalColumn: "idRole",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommandeProduits_Commandes_idCommande",
                table: "CommandeProduits");

            migrationBuilder.DropForeignKey(
                name: "FK_CommandeProduits_Produits_idProduit",
                table: "CommandeProduits");

            migrationBuilder.DropForeignKey(
                name: "FK_Commandes_Clients_ClientidClient",
                table: "Commandes");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_idRole",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "userPassword",
                table: "Users",
                newName: "UserPassword");

            migrationBuilder.RenameColumn(
                name: "userName",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "prenom",
                table: "Users",
                newName: "Prenom");

            migrationBuilder.RenameColumn(
                name: "nom",
                table: "Users",
                newName: "Nom");

            migrationBuilder.RenameColumn(
                name: "idRole",
                table: "Users",
                newName: "IdRole");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "idUser",
                table: "Users",
                newName: "IdUser");

            migrationBuilder.RenameIndex(
                name: "IX_Users_idRole",
                table: "Users",
                newName: "IX_Users_IdRole");

            migrationBuilder.RenameColumn(
                name: "idRole",
                table: "Roles",
                newName: "IdRole");

            migrationBuilder.RenameColumn(
                name: "quantiteStock",
                table: "Produits",
                newName: "QuantiteStock");

            migrationBuilder.RenameColumn(
                name: "prix",
                table: "Produits",
                newName: "Prix");

            migrationBuilder.RenameColumn(
                name: "nomProduit",
                table: "Produits",
                newName: "NomProduit");

            migrationBuilder.RenameColumn(
                name: "estDisponible",
                table: "Produits",
                newName: "EstDisponible");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Produits",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "categorie",
                table: "Produits",
                newName: "Categorie");

            migrationBuilder.RenameColumn(
                name: "idProduit",
                table: "Produits",
                newName: "IdProduit");

            migrationBuilder.RenameColumn(
                name: "ClientidClient",
                table: "Commandes",
                newName: "ClientIdClient");

            migrationBuilder.RenameColumn(
                name: "idCommande",
                table: "Commandes",
                newName: "IdCommande");

            migrationBuilder.RenameIndex(
                name: "IX_Commandes_ClientidClient",
                table: "Commandes",
                newName: "IX_Commandes_ClientIdClient");

            migrationBuilder.RenameColumn(
                name: "quantite",
                table: "CommandeProduits",
                newName: "Quantite");

            migrationBuilder.RenameColumn(
                name: "prixUnitaire",
                table: "CommandeProduits",
                newName: "PrixUnitaire");

            migrationBuilder.RenameColumn(
                name: "idProduit",
                table: "CommandeProduits",
                newName: "IdProduit");

            migrationBuilder.RenameColumn(
                name: "idCommande",
                table: "CommandeProduits",
                newName: "IdCommande");

            migrationBuilder.RenameIndex(
                name: "IX_CommandeProduits_idProduit",
                table: "CommandeProduits",
                newName: "IX_CommandeProduits_IdProduit");

            migrationBuilder.RenameColumn(
                name: "idClient",
                table: "Clients",
                newName: "IdClient");

            migrationBuilder.AddForeignKey(
                name: "FK_CommandeProduits_Commandes_IdCommande",
                table: "CommandeProduits",
                column: "IdCommande",
                principalTable: "Commandes",
                principalColumn: "IdCommande",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommandeProduits_Produits_IdProduit",
                table: "CommandeProduits",
                column: "IdProduit",
                principalTable: "Produits",
                principalColumn: "IdProduit",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Commandes_Clients_ClientIdClient",
                table: "Commandes",
                column: "ClientIdClient",
                principalTable: "Clients",
                principalColumn: "IdClient",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_IdRole",
                table: "Users",
                column: "IdRole",
                principalTable: "Roles",
                principalColumn: "IdRole",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
