using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartDigitalPsico.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class SmartDigitalPsicoDBMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Genders",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(255)", nullable: false),
                    Language = table.Column<string>(type: "char(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Officies",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(255)", nullable: false),
                    Language = table.Column<string>(type: "char(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Officies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleGroups",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(255)", nullable: false),
                    Language = table.Column<string>(type: "char(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Admin"),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", nullable: false),
                    Enable = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModify = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateLastAcess = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenderId = table.Column<long>(type: "bigint", nullable: false),
                    Profession = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", nullable: false),
                    Enable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patient_Genders_GenderId",
                        column: x => x.GenderId,
                        principalSchema: "dbo",
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medical",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfficeId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Accreditation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeAccreditation = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", nullable: false),
                    Enable = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModify = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateLastAcess = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medical", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medical_Officies_OfficeId",
                        column: x => x.OfficeId,
                        principalSchema: "dbo",
                        principalTable: "Officies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medical_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleGroupUser",
                schema: "dbo",
                columns: table => new
                {
                    RoleGroupsId = table.Column<long>(type: "bigint", nullable: false),
                    UsersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleGroupUser", x => new { x.RoleGroupsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_RoleGroupUser_RoleGroups_RoleGroupsId",
                        column: x => x.RoleGroupsId,
                        principalSchema: "dbo",
                        principalTable: "RoleGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleGroupUser_User_UsersId",
                        column: x => x.UsersId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Specialties",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalId = table.Column<long>(type: "bigint", nullable: true),
                    Description = table.Column<string>(type: "varchar(255)", nullable: false),
                    Language = table.Column<string>(type: "char(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specialties_Medical_MedicalId",
                        column: x => x.MedicalId,
                        principalSchema: "dbo",
                        principalTable: "Medical",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Genders",
                columns: new[] { "Id", "Description", "Language" },
                values: new object[,]
                {
                    { 1L, "Masculino", "pt-BR" },
                    { 2L, "Feminino", "pt-BR" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Officies",
                columns: new[] { "Id", "Description", "Language" },
                values: new object[,]
                {
                    { 1L, "Psicólogo", "pt-BR" },
                    { 2L, "Psicóloga", "pt-BR" },
                    { 3L, "Clínico", "pt-BR" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Specialties",
                columns: new[] { "Id", "Description", "Language", "MedicalId" },
                values: new object[,]
                {
                    { 1L, "Psicologia Clínica", "pt-BR", null },
                    { 2L, "Psicologia Social", "pt-BR", null },
                    { 3L, "Psicologia educacional", "pt-BR", null },
                    { 4L, "Psicologia Esportiva ", "pt-BR", null },
                    { 5L, "Psicologia organizacional", "pt-BR", null },
                    { 6L, "Psicologia hospitalar", "pt-BR", null },
                    { 7L, "Psicologia do trânsito", "pt-BR", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medical_OfficeId",
                schema: "dbo",
                table: "Medical",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Medical_UserId",
                schema: "dbo",
                table: "Medical",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_GenderId",
                schema: "dbo",
                table: "Patient",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleGroupUser_UsersId",
                schema: "dbo",
                table: "RoleGroupUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Specialties_MedicalId",
                schema: "dbo",
                table: "Specialties",
                column: "MedicalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patient",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RoleGroupUser",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Specialties",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Genders",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RoleGroups",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Medical",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Officies",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "User",
                schema: "dbo");
        }
    }
}
