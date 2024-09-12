using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingAppWebApi.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedBankMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BankName",
                table: "BankAccounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "BankAccounts",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankName",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "BankAccounts");
        }
    }
}
