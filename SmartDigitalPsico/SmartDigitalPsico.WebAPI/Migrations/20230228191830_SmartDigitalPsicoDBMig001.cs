using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartDigitalPsico.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class SmartDigitalPsicoDBMig001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                schema: "dbo",
                table: "PatientFile",
                type: "varchar(2083)",
                maxLength: 2083,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(2083)",
                oldMaxLength: 2083);

            migrationBuilder.AddColumn<byte[]>(
                name: "FileData",
                schema: "dbo",
                table: "PatientFile",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                schema: "dbo",
                table: "MedicalFile",
                type: "varchar(2083)",
                maxLength: 2083,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(2083)",
                oldMaxLength: 2083);

            migrationBuilder.AddColumn<byte[]>(
                name: "FileData",
                schema: "dbo",
                table: "MedicalFile",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileData",
                schema: "dbo",
                table: "PatientFile");

            migrationBuilder.DropColumn(
                name: "FileData",
                schema: "dbo",
                table: "MedicalFile");

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                schema: "dbo",
                table: "PatientFile",
                type: "varchar(2083)",
                maxLength: 2083,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(2083)",
                oldMaxLength: 2083,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                schema: "dbo",
                table: "MedicalFile",
                type: "varchar(2083)",
                maxLength: 2083,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(2083)",
                oldMaxLength: 2083,
                oldNullable: true);
        }
    }
}
