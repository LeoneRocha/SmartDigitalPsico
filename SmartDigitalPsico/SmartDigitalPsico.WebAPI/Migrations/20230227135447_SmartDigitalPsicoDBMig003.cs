using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartDigitalPsico.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class SmartDigitalPsicoDBMig003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PatientFile",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientFile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClinicFile",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enable = table.Column<bool>(type: "bit", nullable: true),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true),
                    ModifyUserId = table.Column<long>(type: "bigint", nullable: true),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    FilePath = table.Column<string>(type: "varchar(2083)", maxLength: 2083, nullable: false),
                    PatientFileId = table.Column<long>(type: "bigint", nullable: true),
                    PatientFileId1 = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastAccessDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClinicFile_PatientFile_PatientFileId",
                        column: x => x.PatientFileId,
                        principalSchema: "dbo",
                        principalTable: "PatientFile",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClinicFile_PatientFile_PatientFileId1",
                        column: x => x.PatientFileId1,
                        principalSchema: "dbo",
                        principalTable: "PatientFile",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClinicFile_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClinicFile_Users_ModifyUserId",
                        column: x => x.ModifyUserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClinicFile_CreatedUserId",
                schema: "dbo",
                table: "ClinicFile",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicFile_ModifyUserId",
                schema: "dbo",
                table: "ClinicFile",
                column: "ModifyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicFile_PatientFileId",
                schema: "dbo",
                table: "ClinicFile",
                column: "PatientFileId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicFile_PatientFileId1",
                schema: "dbo",
                table: "ClinicFile",
                column: "PatientFileId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClinicFile",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PatientFile",
                schema: "dbo");
        }
    }
}
