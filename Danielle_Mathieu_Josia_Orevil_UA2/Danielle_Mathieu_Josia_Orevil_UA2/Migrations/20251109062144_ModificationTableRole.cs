using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Danielle_Mathieu_Josia_Orevil_UA2.Migrations
{
    /// <inheritdoc />
    public partial class ModificationTableRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Roles_RoleIdRole",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RolesIdRole",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RolesIdRole",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Roles_RoleIdRole",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "RolesIdRole",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoleIdRole",
                table: "Roles");

            migrationBuilder.RenameColumn(
                name: "tache",
                table: "Roles",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "dateCommande",
                table: "Commandes",
                newName: "DateCommande");

            migrationBuilder.RenameColumn(
                name: "telephone",
                table: "Clients",
                newName: "Telephone");

            migrationBuilder.RenameColumn(
                name: "prenom",
                table: "Clients",
                newName: "Prenom");

            migrationBuilder.RenameColumn(
                name: "nom",
                table: "Clients",
                newName: "Nom");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Clients",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "adresse",
                table: "Clients",
                newName: "Adresse");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdRole",
                table: "Users",
                column: "IdRole");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_IdRole",
                table: "Users",
                column: "IdRole",
                principalTable: "Roles",
                principalColumn: "IdRole",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_IdRole",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_IdRole",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Roles",
                newName: "tache");

            migrationBuilder.RenameColumn(
                name: "DateCommande",
                table: "Commandes",
                newName: "dateCommande");

            migrationBuilder.RenameColumn(
                name: "Telephone",
                table: "Clients",
                newName: "telephone");

            migrationBuilder.RenameColumn(
                name: "Prenom",
                table: "Clients",
                newName: "prenom");

            migrationBuilder.RenameColumn(
                name: "Nom",
                table: "Clients",
                newName: "nom");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Clients",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Adresse",
                table: "Clients",
                newName: "adresse");

            migrationBuilder.AddColumn<int>(
                name: "RolesIdRole",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoleIdRole",
                table: "Roles",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RolesIdRole",
                table: "Users",
                column: "RolesIdRole");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleIdRole",
                table: "Roles",
                column: "RoleIdRole");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Roles_RoleIdRole",
                table: "Roles",
                column: "RoleIdRole",
                principalTable: "Roles",
                principalColumn: "IdRole");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RolesIdRole",
                table: "Users",
                column: "RolesIdRole",
                principalTable: "Roles",
                principalColumn: "IdRole",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
