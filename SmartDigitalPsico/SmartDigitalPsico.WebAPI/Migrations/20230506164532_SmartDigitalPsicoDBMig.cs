using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartDigitalPsicoWebAPI.Migrations
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
                name: "ApplicationCacheLogs",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enable = table.Column<bool>(type: "bit", nullable: true),
                    DateTimeSlidingExpiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CacheId = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    CacheKey = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastAccessDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationCacheLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationConfigSetting",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enable = table.Column<bool>(type: "bit", nullable: true),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Language = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    EndPointUrl_StorageFiles = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    EndPointUrl_Cache = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    TypeLocationSaveFiles = table.Column<int>(type: "int", nullable: false),
                    TypeLocationCache = table.Column<int>(type: "int", nullable: false),
                    TypeLocationQueeMessaging = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastAccessDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationConfigSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationLanguage",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enable = table.Column<bool>(type: "bit", nullable: true),
                    Language = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    LanguageKey = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    ResourceKey = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, defaultValue: "ApplicationLanguage"),
                    LanguageValue = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastAccessDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationLanguage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enable = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Description = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Language = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastAccessDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    Enable = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Language = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastAccessDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    Enable = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Description = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Language = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    RolePolicyClaimCode = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastAccessDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialties",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enable = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Language = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastAccessDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InfoTag",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enable = table.Column<bool>(type: "bit", nullable: true),
                    MedicalId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true),
                    ModifyUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastAccessDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoTag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalFile",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enable = table.Column<bool>(type: "bit", nullable: true),
                    MedicalId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true),
                    ModifyUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastAccessDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    FilePath = table.Column<string>(type: "varchar(2083)", maxLength: 2083, nullable: true),
                    FileData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FileExtension = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: true),
                    FileContentType = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    FileSizeKB = table.Column<long>(type: "bigint", nullable: false),
                    TypeLocationSaveFile = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalFile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicals",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enable = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    OfficeId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true),
                    ModifyUserId = table.Column<long>(type: "bigint", nullable: true),
                    Accreditation = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    TypeAccreditation = table.Column<int>(type: "int", nullable: false),
                    SecurityKey = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastAccessDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicals_Officies_OfficeId",
                        column: x => x.OfficeId,
                        principalSchema: "dbo",
                        principalTable: "Officies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalSpecialty",
                schema: "dbo",
                columns: table => new
                {
                    MedicalsId = table.Column<long>(type: "bigint", nullable: false),
                    SpecialtiesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalSpecialty", x => new { x.MedicalsId, x.SpecialtiesId });
                    table.ForeignKey(
                        name: "FK_MedicalSpecialty_Medicals_MedicalsId",
                        column: x => x.MedicalsId,
                        principalSchema: "dbo",
                        principalTable: "Medicals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalSpecialty_Specialties_SpecialtiesId",
                        column: x => x.SpecialtiesId,
                        principalSchema: "dbo",
                        principalTable: "Specialties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enable = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Login = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    MedicalId = table.Column<long>(type: "bigint", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Role = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValue: "Admin"),
                    Admin = table.Column<bool>(type: "bit", nullable: false),
                    Language = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    TimeZone = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Refresh_token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Refresh_token_expiry_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastAccessDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Medicals_MedicalId",
                        column: x => x.MedicalId,
                        principalSchema: "dbo",
                        principalTable: "Medicals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enable = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    MedicalId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true),
                    ModifyUserId = table.Column<long>(type: "bigint", nullable: true),
                    GenderId = table.Column<long>(type: "bigint", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Profession = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Cpf = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    Rg = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    Education = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    MaritalStatus = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    AddressStreet = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    AddressNeighborhood = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    AddressCity = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    AddressState = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    AddressCep = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    EmergencyContactName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    EmergencyContactPhoneNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastAccessDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Genders_GenderId",
                        column: x => x.GenderId,
                        principalSchema: "dbo",
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patients_Medicals_MedicalId",
                        column: x => x.MedicalId,
                        principalSchema: "dbo",
                        principalTable: "Medicals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patients_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Patients_Users_ModifyUserId",
                        column: x => x.ModifyUserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
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
                        name: "FK_RoleGroupUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientAdditionalInformations",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enable = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    PatientId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true),
                    ModifyUserId = table.Column<long>(type: "bigint", nullable: true),
                    FollowUp_Psychiatric = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: true),
                    FollowUp_Neurological = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastAccessDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAdditionalInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientAdditionalInformations_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientAdditionalInformations_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PatientAdditionalInformations_Users_ModifyUserId",
                        column: x => x.ModifyUserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PatientFile",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enable = table.Column<bool>(type: "bit", nullable: true),
                    PatientId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true),
                    ModifyUserId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastAccessDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    FilePath = table.Column<string>(type: "varchar(2083)", maxLength: 2083, nullable: true),
                    FileData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FileExtension = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: true),
                    FileContentType = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    FileSizeKB = table.Column<long>(type: "bigint", nullable: false),
                    TypeLocationSaveFile = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientFile_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientFile_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PatientFile_Users_ModifyUserId",
                        column: x => x.ModifyUserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PatientHospitalizationInformations",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enable = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    PatientId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true),
                    ModifyUserId = table.Column<long>(type: "bigint", nullable: true),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CID = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Observation = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastAccessDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientHospitalizationInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientHospitalizationInformations_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientHospitalizationInformations_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PatientHospitalizationInformations_Users_ModifyUserId",
                        column: x => x.ModifyUserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PatientInfoTag",
                schema: "dbo",
                columns: table => new
                {
                    InfoTagId = table.Column<long>(type: "bigint", nullable: false),
                    PatientId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientInfoTag", x => new { x.PatientId, x.InfoTagId });
                    table.ForeignKey(
                        name: "FK_PatientInfoTag_InfoTag_InfoTagId",
                        column: x => x.InfoTagId,
                        principalSchema: "dbo",
                        principalTable: "InfoTag",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PatientInfoTag_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PatientMedicationInformations",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enable = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    PatientId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true),
                    ModifyUserId = table.Column<long>(type: "bigint", nullable: true),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Dosage = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Posology = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    MainDrug = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastAccessDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientMedicationInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientMedicationInformations_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientMedicationInformations_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PatientMedicationInformations_Users_ModifyUserId",
                        column: x => x.ModifyUserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PatientNotificationMessage",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enable = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    PatientId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true),
                    ModifyUserId = table.Column<long>(type: "bigint", nullable: true),
                    MessagePatient = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: false),
                    IsReaded = table.Column<bool>(type: "bit", nullable: false),
                    ReadingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notified = table.Column<bool>(type: "bit", nullable: false),
                    NotifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastAccessDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientNotificationMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientNotificationMessage_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientNotificationMessage_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PatientNotificationMessage_Users_ModifyUserId",
                        column: x => x.ModifyUserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PatientRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enable = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    PatientId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true),
                    ModifyUserId = table.Column<long>(type: "bigint", nullable: true),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Annotation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnnotationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastAccessDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientRecords_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PatientRecords_Users_ModifyUserId",
                        column: x => x.ModifyUserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "ApplicationConfigSetting",
                columns: new[] { "Id", "CreatedDate", "Description", "Enable", "EndPointUrl_Cache", "EndPointUrl_StorageFiles", "Language", "LastAccessDate", "ModifyDate", "TypeLocationCache", "TypeLocationQueeMessaging", "TypeLocationSaveFiles" },
                values: new object[] { 1L, new DateTime(2023, 5, 6, 13, 45, 32, 245, DateTimeKind.Local).AddTicks(5565), "Default", true, "", "", "pt-BR", new DateTime(2023, 5, 6, 13, 45, 32, 245, DateTimeKind.Local).AddTicks(5578), new DateTime(2023, 5, 6, 13, 45, 32, 245, DateTimeKind.Local).AddTicks(5577), 1, 0, 0 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "ApplicationLanguage",
                columns: new[] { "Id", "CreatedDate", "Description", "Enable", "Language", "LanguageKey", "LanguageValue", "LastAccessDate", "ModifyDate" },
                values: new object[] { 1L, new DateTime(2023, 5, 6, 13, 45, 32, 245, DateTimeKind.Local).AddTicks(5628), "Default", true, "pt-BR", "Default_ptbr", "Padrão", new DateTime(2023, 5, 6, 13, 45, 32, 245, DateTimeKind.Local).AddTicks(5628), new DateTime(2023, 5, 6, 13, 45, 32, 245, DateTimeKind.Local).AddTicks(5628) });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Genders",
                columns: new[] { "Id", "CreatedDate", "Description", "Language", "LastAccessDate", "ModifyDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Masculino", "pt-BR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Feminino", "pt-BR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Officies",
                columns: new[] { "Id", "CreatedDate", "Description", "Language", "LastAccessDate", "ModifyDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Psicólogo", "pt-BR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Psicóloga", "pt-BR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clínico", "pt-BR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "RoleGroups",
                columns: new[] { "Id", "CreatedDate", "Description", "Language", "LastAccessDate", "ModifyDate", "RolePolicyClaimCode" },
                values: new object[,]
                {
                    { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Administrador", "pt-BR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin" },
                    { 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medico", "pt-BR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medical" },
                    { 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Recepcionista", "pt-BR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Staff" },
                    { 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paciente", "pt-BR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patient" },
                    { 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Leitura", "pt-BR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Read" },
                    { 6L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Escrita", "pt-BR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Write" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Specialties",
                columns: new[] { "Id", "CreatedDate", "Description", "Language", "LastAccessDate", "ModifyDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Psicologia Clínica", "pt-BR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Psicologia Social", "pt-BR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Psicologia educacional", "pt-BR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Psicologia Esportiva ", "pt-BR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Psicologia organizacional", "pt-BR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Psicologia hospitalar", "pt-BR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Psicologia do trânsito", "pt-BR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Users",
                columns: new[] { "Id", "Admin", "CreatedDate", "Email", "Enable", "Language", "LastAccessDate", "Login", "MedicalId", "ModifyDate", "Name", "PasswordHash", "PasswordSalt", "Refresh_token", "Refresh_token_expiry_time", "Role", "TimeZone" },
                values: new object[] { 1L, true, new DateTime(2023, 5, 6, 13, 45, 32, 245, DateTimeKind.Local).AddTicks(5906), "admin@sistemas.com", true, "pt-BR", new DateTime(2023, 5, 6, 13, 45, 32, 245, DateTimeKind.Local).AddTicks(5906), "admin", null, new DateTime(2023, 5, 6, 13, 45, 32, 245, DateTimeKind.Local).AddTicks(5907), "User MOCK ", new byte[] { 233, 213, 169, 153, 38, 208, 28, 254, 26, 189, 204, 103, 234, 231, 108, 53, 168, 238, 19, 235, 25, 160, 36, 247, 16, 58, 119, 247, 152, 230, 120, 34, 45, 147, 183, 219, 27, 7, 34, 144, 117, 131, 21, 187, 88, 238, 179, 21, 92, 207, 44, 228, 79, 13, 255, 120, 146, 44, 96, 163, 45, 233, 226, 230 }, new byte[] { 12, 76, 181, 122, 102, 216, 25, 247, 97, 29, 196, 102, 100, 91, 31, 234, 233, 245, 93, 34, 129, 215, 236, 172, 166, 195, 55, 155, 178, 12, 138, 229, 50, 14, 250, 252, 158, 206, 189, 212, 156, 205, 169, 84, 109, 53, 174, 118, 212, 114, 174, 55, 128, 47, 126, 102, 100, 19, 1, 190, 245, 198, 79, 148, 204, 9, 48, 113, 93, 99, 36, 171, 71, 108, 3, 201, 19, 49, 217, 15, 240, 133, 1, 163, 186, 129, 172, 180, 121, 181, 181, 113, 132, 218, 116, 97, 162, 166, 114, 81, 233, 120, 98, 28, 92, 1, 242, 120, 172, 110, 125, 88, 122, 155, 126, 217, 215, 2, 92, 156, 238, 62, 53, 115, 155, 247, 170, 57 }, null, null, "Admin", "E. South America Standard Time" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Medicals",
                columns: new[] { "Id", "Accreditation", "CreatedDate", "CreatedUserId", "Email", "Enable", "LastAccessDate", "ModifyDate", "ModifyUserId", "Name", "OfficeId", "SecurityKey", "TypeAccreditation", "UserId" },
                values: new object[] { 1L, "123456", new DateTime(2023, 5, 6, 13, 45, 32, 247, DateTimeKind.Local).AddTicks(7002), 1L, "medical@sistemas.com", true, new DateTime(2023, 5, 6, 13, 45, 32, 247, DateTimeKind.Local).AddTicks(7004), new DateTime(2023, 5, 6, 13, 45, 32, 247, DateTimeKind.Local).AddTicks(7004), null, "Medical MOCK ", 3L, null, 0, null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "RoleGroupUser",
                columns: new[] { "RoleGroupsId", "UsersId" },
                values: new object[,]
                {
                    { 1L, 1L },
                    { 2L, 1L },
                    { 3L, 1L },
                    { 4L, 1L }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "MedicalSpecialty",
                columns: new[] { "MedicalsId", "SpecialtiesId" },
                values: new object[] { 1L, 1L });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Patients",
                columns: new[] { "Id", "AddressCep", "AddressCity", "AddressNeighborhood", "AddressState", "AddressStreet", "Cpf", "CreatedDate", "CreatedUserId", "DateOfBirth", "Education", "Email", "EmergencyContactName", "EmergencyContactPhoneNumber", "Enable", "GenderId", "LastAccessDate", "MaritalStatus", "MedicalId", "ModifyDate", "ModifyUserId", "Name", "PhoneNumber", "Profession", "Rg" },
                values: new object[] { 1L, "45675-970", "Aurelino Leal", "Centro", "Bahia", "Avenida Presidente Médici 264", "947.846.605-42", new DateTime(2023, 5, 6, 13, 45, 32, 249, DateTimeKind.Local).AddTicks(6323), 1L, new DateTime(1960, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Superior", "tiago.thales.mendes@andrade.com", "Milena Isabelly Vanessa", "(73) 98540-4268", true, 1L, new DateTime(2023, 5, 6, 13, 45, 32, 249, DateTimeKind.Local).AddTicks(6327), 0, 1L, new DateTime(2023, 5, 6, 13, 45, 32, 249, DateTimeKind.Local).AddTicks(6327), null, "Tiago Thales Mendes", "(73) 2877-3408", "Professor", "13.809.283-7" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Users",
                columns: new[] { "Id", "Admin", "CreatedDate", "Email", "Enable", "Language", "LastAccessDate", "Login", "MedicalId", "ModifyDate", "Name", "PasswordHash", "PasswordSalt", "Refresh_token", "Refresh_token_expiry_time", "Role", "TimeZone" },
                values: new object[] { 2L, false, new DateTime(2023, 5, 6, 13, 45, 32, 247, DateTimeKind.Local).AddTicks(7269), "doctor@sistemas.com", true, "pt-BR", new DateTime(2023, 5, 6, 13, 45, 32, 247, DateTimeKind.Local).AddTicks(7270), "doctor", 1L, new DateTime(2023, 5, 6, 13, 45, 32, 247, DateTimeKind.Local).AddTicks(7271), "User Medical", new byte[] { 244, 177, 156, 6, 44, 150, 97, 9, 131, 148, 85, 246, 67, 119, 72, 245, 146, 226, 46, 112, 236, 193, 113, 193, 19, 91, 41, 139, 240, 231, 146, 235, 14, 98, 164, 177, 109, 157, 37, 136, 174, 67, 113, 94, 154, 62, 97, 31, 41, 64, 249, 249, 69, 178, 39, 7, 226, 129, 25, 241, 205, 47, 83, 146 }, new byte[] { 77, 15, 79, 253, 37, 72, 60, 81, 223, 30, 253, 186, 30, 80, 71, 30, 115, 240, 134, 233, 0, 148, 213, 253, 185, 80, 133, 19, 23, 107, 246, 236, 102, 137, 161, 139, 162, 1, 90, 157, 197, 95, 253, 98, 196, 103, 254, 110, 172, 202, 199, 11, 151, 196, 117, 110, 45, 13, 124, 161, 75, 145, 243, 7, 41, 16, 244, 73, 44, 14, 123, 227, 205, 93, 143, 83, 222, 105, 126, 137, 103, 179, 161, 56, 89, 196, 216, 65, 102, 236, 161, 56, 200, 121, 79, 45, 94, 23, 75, 49, 236, 198, 75, 12, 15, 194, 18, 12, 43, 62, 66, 173, 92, 80, 125, 236, 53, 81, 212, 35, 176, 159, 49, 218, 33, 129, 47, 92 }, null, null, "Medical", "E. South America Standard Time" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "RoleGroupUser",
                columns: new[] { "RoleGroupsId", "UsersId" },
                values: new object[] { 2L, 2L });

            migrationBuilder.CreateIndex(
                name: "Idx_ApplicationLanguage_ResourceKey_Language_LanguageKey_Unique",
                schema: "dbo",
                table: "ApplicationLanguage",
                columns: new[] { "ResourceKey", "Language", "LanguageKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InfoTag_CreatedUserId",
                schema: "dbo",
                table: "InfoTag",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InfoTag_MedicalId",
                schema: "dbo",
                table: "InfoTag",
                column: "MedicalId");

            migrationBuilder.CreateIndex(
                name: "IX_InfoTag_ModifyUserId",
                schema: "dbo",
                table: "InfoTag",
                column: "ModifyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalFile_CreatedUserId",
                schema: "dbo",
                table: "MedicalFile",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalFile_MedicalId",
                schema: "dbo",
                table: "MedicalFile",
                column: "MedicalId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalFile_ModifyUserId",
                schema: "dbo",
                table: "MedicalFile",
                column: "ModifyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicals_CreatedUserId",
                schema: "dbo",
                table: "Medicals",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicals_ModifyUserId",
                schema: "dbo",
                table: "Medicals",
                column: "ModifyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicals_OfficeId",
                schema: "dbo",
                table: "Medicals",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicals_UserId",
                schema: "dbo",
                table: "Medicals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalSpecialty_SpecialtiesId",
                schema: "dbo",
                table: "MedicalSpecialty",
                column: "SpecialtiesId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAdditionalInformations_CreatedUserId",
                schema: "dbo",
                table: "PatientAdditionalInformations",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAdditionalInformations_ModifyUserId",
                schema: "dbo",
                table: "PatientAdditionalInformations",
                column: "ModifyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAdditionalInformations_PatientId",
                schema: "dbo",
                table: "PatientAdditionalInformations",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientFile_CreatedUserId",
                schema: "dbo",
                table: "PatientFile",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientFile_ModifyUserId",
                schema: "dbo",
                table: "PatientFile",
                column: "ModifyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientFile_PatientId",
                schema: "dbo",
                table: "PatientFile",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientHospitalizationInformations_CreatedUserId",
                schema: "dbo",
                table: "PatientHospitalizationInformations",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientHospitalizationInformations_ModifyUserId",
                schema: "dbo",
                table: "PatientHospitalizationInformations",
                column: "ModifyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientHospitalizationInformations_PatientId",
                schema: "dbo",
                table: "PatientHospitalizationInformations",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientInfoTag_InfoTagId",
                schema: "dbo",
                table: "PatientInfoTag",
                column: "InfoTagId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicationInformations_CreatedUserId",
                schema: "dbo",
                table: "PatientMedicationInformations",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicationInformations_ModifyUserId",
                schema: "dbo",
                table: "PatientMedicationInformations",
                column: "ModifyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicationInformations_PatientId",
                schema: "dbo",
                table: "PatientMedicationInformations",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientNotificationMessage_CreatedUserId",
                schema: "dbo",
                table: "PatientNotificationMessage",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientNotificationMessage_ModifyUserId",
                schema: "dbo",
                table: "PatientNotificationMessage",
                column: "ModifyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientNotificationMessage_PatientId",
                schema: "dbo",
                table: "PatientNotificationMessage",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientRecords_CreatedUserId",
                schema: "dbo",
                table: "PatientRecords",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientRecords_ModifyUserId",
                schema: "dbo",
                table: "PatientRecords",
                column: "ModifyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientRecords_PatientId",
                schema: "dbo",
                table: "PatientRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_CreatedUserId",
                schema: "dbo",
                table: "Patients",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_GenderId",
                schema: "dbo",
                table: "Patients",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_MedicalId",
                schema: "dbo",
                table: "Patients",
                column: "MedicalId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_ModifyUserId",
                schema: "dbo",
                table: "Patients",
                column: "ModifyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleGroupUser_UsersId",
                schema: "dbo",
                table: "RoleGroupUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_MedicalId",
                schema: "dbo",
                table: "Users",
                column: "MedicalId",
                unique: true,
                filter: "[MedicalId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_InfoTag_Medicals_MedicalId",
                schema: "dbo",
                table: "InfoTag",
                column: "MedicalId",
                principalSchema: "dbo",
                principalTable: "Medicals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InfoTag_Users_CreatedUserId",
                schema: "dbo",
                table: "InfoTag",
                column: "CreatedUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InfoTag_Users_ModifyUserId",
                schema: "dbo",
                table: "InfoTag",
                column: "ModifyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalFile_Medicals_MedicalId",
                schema: "dbo",
                table: "MedicalFile",
                column: "MedicalId",
                principalSchema: "dbo",
                principalTable: "Medicals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalFile_Users_CreatedUserId",
                schema: "dbo",
                table: "MedicalFile",
                column: "CreatedUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalFile_Users_ModifyUserId",
                schema: "dbo",
                table: "MedicalFile",
                column: "ModifyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicals_Users_CreatedUserId",
                schema: "dbo",
                table: "Medicals",
                column: "CreatedUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicals_Users_ModifyUserId",
                schema: "dbo",
                table: "Medicals",
                column: "ModifyUserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicals_Users_UserId",
                schema: "dbo",
                table: "Medicals",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Medicals_MedicalId",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropTable(
                name: "ApplicationCacheLogs",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ApplicationConfigSetting",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ApplicationLanguage",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MedicalFile",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MedicalSpecialty",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PatientAdditionalInformations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PatientFile",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PatientHospitalizationInformations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PatientInfoTag",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PatientMedicationInformations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PatientNotificationMessage",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PatientRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RoleGroupUser",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Specialties",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "InfoTag",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Patients",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RoleGroups",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Genders",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Medicals",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Officies",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "dbo");
        }
    }
}
