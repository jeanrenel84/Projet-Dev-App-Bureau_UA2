using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Danielle_Mathieu_Josia_Orevil_UA2.Migrations
{
    /// <inheritdoc />
    public partial class ChangementUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "email",
                table: "Users",
                newName: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Email",
                table: "Users",
                newName: "email");
        }
    }
}
