using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartDigitalPsico.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class SmartDigitalPsicoDBMig_Update_002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Login",
                schema: "dbo",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AddressCep",
                schema: "dbo",
                table: "Patient",
                type: "varchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressCity",
                schema: "dbo",
                table: "Patient",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressNeighborhood",
                schema: "dbo",
                table: "Patient",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressState",
                schema: "dbo",
                table: "Patient",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressStreet",
                schema: "dbo",
                table: "Patient",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                schema: "dbo",
                table: "Patient",
                type: "varchar(15)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Education",
                schema: "dbo",
                table: "Patient",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                schema: "dbo",
                table: "Patient",
                type: "varchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rg",
                schema: "dbo",
                table: "Patient",
                type: "varchar(15)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Login",
                schema: "dbo",
                table: "User");

            migrationBuilder.DropColumn(
                name: "AddressCep",
                schema: "dbo",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "AddressCity",
                schema: "dbo",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "AddressNeighborhood",
                schema: "dbo",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "AddressState",
                schema: "dbo",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "AddressStreet",
                schema: "dbo",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "Cpf",
                schema: "dbo",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "Education",
                schema: "dbo",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                schema: "dbo",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "Rg",
                schema: "dbo",
                table: "Patient");
        }
    }
}
