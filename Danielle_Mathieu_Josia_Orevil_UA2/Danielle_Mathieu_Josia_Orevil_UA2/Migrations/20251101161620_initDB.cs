using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Danielle_Mathieu_Josia_Orevil_UA2.Migrations
{
    /// <inheritdoc />
    public partial class initDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nom = table.Column<string>(type: "TEXT", nullable: false),
                    prenom = table.Column<string>(type: "TEXT", nullable: false),
                    adresse = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    telephone = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.IdClient);
                });

            migrationBuilder.CreateTable(
                name: "Produits",
                columns: table => new
                {
                    IdProduit = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomProduit = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Categorie = table.Column<string>(type: "TEXT", nullable: false),
                    Prix = table.Column<decimal>(type: "TEXT", nullable: false),
                    QuantiteStock = table.Column<int>(type: "INTEGER", nullable: false),
                    EstDisponible = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produits", x => x.IdProduit);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IdRole = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomRole = table.Column<string>(type: "TEXT", nullable: false),
                    tache = table.Column<string>(type: "TEXT", nullable: false),
                    RoleIdRole = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.IdRole);
                    table.ForeignKey(
                        name: "FK_Roles_Roles_RoleIdRole",
                        column: x => x.RoleIdRole,
                        principalTable: "Roles",
                        principalColumn: "IdRole");
                });

            migrationBuilder.CreateTable(
                name: "Commandes",
                columns: table => new
                {
                    IdCommande = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    dateCommande = table.Column<DateTime>(type: "TEXT", nullable: false),
                    idClient = table.Column<int>(type: "INTEGER", nullable: false),
                    ClientIdClient = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commandes", x => x.IdCommande);
                    table.ForeignKey(
                        name: "FK_Commandes_Clients_ClientIdClient",
                        column: x => x.ClientIdClient,
                        principalTable: "Clients",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: false),
                    Prenom = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    UserPassword = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    IdRole = table.Column<int>(type: "INTEGER", nullable: false),
                    RolesIdRole = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RolesIdRole",
                        column: x => x.RolesIdRole,
                        principalTable: "Roles",
                        principalColumn: "IdRole",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommandeProduits",
                columns: table => new
                {
                    IdProduit = table.Column<int>(type: "INTEGER", nullable: false),
                    IdCommande = table.Column<int>(type: "INTEGER", nullable: false),
                    PrixUnitaire = table.Column<decimal>(type: "TEXT", nullable: false),
                    Quantite = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandeProduits", x => new { x.IdCommande, x.IdProduit });
                    table.ForeignKey(
                        name: "FK_CommandeProduits_Commandes_IdCommande",
                        column: x => x.IdCommande,
                        principalTable: "Commandes",
                        principalColumn: "IdCommande",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommandeProduits_Produits_IdProduit",
                        column: x => x.IdProduit,
                        principalTable: "Produits",
                        principalColumn: "IdProduit",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommandeProduits_IdProduit",
                table: "CommandeProduits",
                column: "IdProduit");

            migrationBuilder.CreateIndex(
                name: "IX_Commandes_ClientIdClient",
                table: "Commandes",
                column: "ClientIdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleIdRole",
                table: "Roles",
                column: "RoleIdRole");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RolesIdRole",
                table: "Users",
                column: "RolesIdRole");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommandeProduits");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Commandes");

            migrationBuilder.DropTable(
                name: "Produits");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
