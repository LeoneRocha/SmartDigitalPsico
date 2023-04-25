using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartDigitalPsicoWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class SmartDigitalPsicoDBMig_MYSQL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_MedicalId",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ApplicationConfigSetting",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ApplicationLanguage",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "MedicalSpecialty",
                keyColumns: new[] { "MedicalsId", "SpecialtiesId" },
                keyValues: new object[] { 1L, 1L });

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Officies",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Officies",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "RoleGroupUser",
                keyColumns: new[] { "RoleGroupsId", "UsersId" },
                keyValues: new object[] { 1L, 1L });

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "RoleGroupUser",
                keyColumns: new[] { "RoleGroupsId", "UsersId" },
                keyValues: new object[] { 2L, 1L });

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "RoleGroupUser",
                keyColumns: new[] { "RoleGroupsId", "UsersId" },
                keyValues: new object[] { 2L, 2L });

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "RoleGroupUser",
                keyColumns: new[] { "RoleGroupsId", "UsersId" },
                keyValues: new object[] { 3L, 1L });

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "RoleGroupUser",
                keyColumns: new[] { "RoleGroupsId", "UsersId" },
                keyValues: new object[] { 4L, 1L });

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "RoleGroups",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "RoleGroups",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "RoleGroups",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "RoleGroups",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "RoleGroups",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "RoleGroups",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Specialties",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Medicals",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Officies",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Refresh_token_expiry_time",
                schema: "dbo",
                table: "Users",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Refresh_token",
                schema: "dbo",
                table: "Users",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordSalt",
                schema: "dbo",
                table: "Users",
                type: "longblob",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                schema: "dbo",
                table: "Users",
                type: "longblob",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyDate",
                schema: "dbo",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastAccessDate",
                schema: "dbo",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<bool>(
                name: "Enable",
                schema: "dbo",
                table: "Users",
                type: "tinyint(1)",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(ulong),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: 1ul);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<bool>(
                name: "Admin",
                schema: "dbo",
                table: "Users",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyDate",
                schema: "dbo",
                table: "Specialties",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastAccessDate",
                schema: "dbo",
                table: "Specialties",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<bool>(
                name: "Enable",
                schema: "dbo",
                table: "Specialties",
                type: "tinyint(1)",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(ulong),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: 1ul);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "Specialties",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyDate",
                schema: "dbo",
                table: "RoleGroups",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastAccessDate",
                schema: "dbo",
                table: "RoleGroups",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<bool>(
                name: "Enable",
                schema: "dbo",
                table: "RoleGroups",
                type: "tinyint(1)",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(ulong),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: 1ul);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "RoleGroups",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyDate",
                schema: "dbo",
                table: "Patients",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastAccessDate",
                schema: "dbo",
                table: "Patients",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<bool>(
                name: "Enable",
                schema: "dbo",
                table: "Patients",
                type: "tinyint(1)",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(ulong),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: 1ul);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                schema: "dbo",
                table: "Patients",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "Patients",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyDate",
                schema: "dbo",
                table: "PatientRecords",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastAccessDate",
                schema: "dbo",
                table: "PatientRecords",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<bool>(
                name: "Enable",
                schema: "dbo",
                table: "PatientRecords",
                type: "tinyint(1)",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(ulong),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: 1ul);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "PatientRecords",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AnnotationDate",
                schema: "dbo",
                table: "PatientRecords",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<string>(
                name: "Annotation",
                schema: "dbo",
                table: "PatientRecords",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReadingDate",
                schema: "dbo",
                table: "PatientNotificationMessage",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NotifiedDate",
                schema: "dbo",
                table: "PatientNotificationMessage",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Notified",
                schema: "dbo",
                table: "PatientNotificationMessage",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyDate",
                schema: "dbo",
                table: "PatientNotificationMessage",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastAccessDate",
                schema: "dbo",
                table: "PatientNotificationMessage",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsReaded",
                schema: "dbo",
                table: "PatientNotificationMessage",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Enable",
                schema: "dbo",
                table: "PatientNotificationMessage",
                type: "tinyint(1)",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(ulong),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: 1ul);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "PatientNotificationMessage",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                schema: "dbo",
                table: "PatientMedicationInformations",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyDate",
                schema: "dbo",
                table: "PatientMedicationInformations",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastAccessDate",
                schema: "dbo",
                table: "PatientMedicationInformations",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                schema: "dbo",
                table: "PatientMedicationInformations",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Enable",
                schema: "dbo",
                table: "PatientMedicationInformations",
                type: "tinyint(1)",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(ulong),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: 1ul);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "PatientMedicationInformations",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                schema: "dbo",
                table: "PatientHospitalizationInformations",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyDate",
                schema: "dbo",
                table: "PatientHospitalizationInformations",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastAccessDate",
                schema: "dbo",
                table: "PatientHospitalizationInformations",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                schema: "dbo",
                table: "PatientHospitalizationInformations",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Enable",
                schema: "dbo",
                table: "PatientHospitalizationInformations",
                type: "tinyint(1)",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(ulong),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: 1ul);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "PatientHospitalizationInformations",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyDate",
                schema: "dbo",
                table: "PatientFile",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastAccessDate",
                schema: "dbo",
                table: "PatientFile",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "FileData",
                schema: "dbo",
                table: "PatientFile",
                type: "longblob",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Enable",
                schema: "dbo",
                table: "PatientFile",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "PatientFile",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyDate",
                schema: "dbo",
                table: "PatientAdditionalInformations",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastAccessDate",
                schema: "dbo",
                table: "PatientAdditionalInformations",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<bool>(
                name: "Enable",
                schema: "dbo",
                table: "PatientAdditionalInformations",
                type: "tinyint(1)",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(ulong),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: 1ul);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "PatientAdditionalInformations",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyDate",
                schema: "dbo",
                table: "Officies",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastAccessDate",
                schema: "dbo",
                table: "Officies",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<bool>(
                name: "Enable",
                schema: "dbo",
                table: "Officies",
                type: "tinyint(1)",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(ulong),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: 1ul);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "Officies",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyDate",
                schema: "dbo",
                table: "Medicals",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastAccessDate",
                schema: "dbo",
                table: "Medicals",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<bool>(
                name: "Enable",
                schema: "dbo",
                table: "Medicals",
                type: "tinyint(1)",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(ulong),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: 1ul);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "Medicals",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyDate",
                schema: "dbo",
                table: "MedicalFile",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastAccessDate",
                schema: "dbo",
                table: "MedicalFile",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "FileData",
                schema: "dbo",
                table: "MedicalFile",
                type: "longblob",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Enable",
                schema: "dbo",
                table: "MedicalFile",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "MedicalFile",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyDate",
                schema: "dbo",
                table: "InfoTag",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastAccessDate",
                schema: "dbo",
                table: "InfoTag",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<bool>(
                name: "Enable",
                schema: "dbo",
                table: "InfoTag",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "InfoTag",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyDate",
                schema: "dbo",
                table: "Genders",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastAccessDate",
                schema: "dbo",
                table: "Genders",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<bool>(
                name: "Enable",
                schema: "dbo",
                table: "Genders",
                type: "tinyint(1)",
                nullable: true,
                defaultValue: true,
                oldClrType: typeof(ulong),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValue: 1ul);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "Genders",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyDate",
                schema: "dbo",
                table: "ApplicationLanguage",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastAccessDate",
                schema: "dbo",
                table: "ApplicationLanguage",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<bool>(
                name: "Enable",
                schema: "dbo",
                table: "ApplicationLanguage",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "ApplicationLanguage",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyDate",
                schema: "dbo",
                table: "ApplicationConfigSetting",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastAccessDate",
                schema: "dbo",
                table: "ApplicationConfigSetting",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<bool>(
                name: "Enable",
                schema: "dbo",
                table: "ApplicationConfigSetting",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "ApplicationConfigSetting",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyDate",
                schema: "dbo",
                table: "ApplicationCacheLogs",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastAccessDate",
                schema: "dbo",
                table: "ApplicationCacheLogs",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<bool>(
                name: "Enable",
                schema: "dbo",
                table: "ApplicationCacheLogs",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTimeSlidingExpiration",
                schema: "dbo",
                table: "ApplicationCacheLogs",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "ApplicationCacheLogs",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(6)");

            migrationBuilder.CreateIndex(
                name: "IX_Users_MedicalId",
                schema: "dbo",
                table: "Users",
                column: "MedicalId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_MedicalId",
                schema: "dbo",
                table: "Users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Refresh_token_expiry_time",
                schema: "dbo",
                table: "Users",
                type: "datetime2(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Refresh_token",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordSalt",
                schema: "dbo",
                table: "Users",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "longblob");

            migrationBuilder.AlterColumn<byte[]>(
                name: "PasswordHash",
                schema: "dbo",
                table: "Users",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "longblob");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyDate",
                schema: "dbo",
                table: "Users",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastAccessDate",
                schema: "dbo",
                table: "Users",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<ulong>(
                name: "Enable",
                schema: "dbo",
                table: "Users",
                type: "bit",
                nullable: true,
                defaultValue: 1ul,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "Users",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<ulong>(
                name: "Admin",
                schema: "dbo",
                table: "Users",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyDate",
                schema: "dbo",
                table: "Specialties",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastAccessDate",
                schema: "dbo",
                table: "Specialties",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<ulong>(
                name: "Enable",
                schema: "dbo",
                table: "Specialties",
                type: "bit",
                nullable: true,
                defaultValue: 1ul,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "Specialties",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyDate",
                schema: "dbo",
                table: "RoleGroups",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastAccessDate",
                schema: "dbo",
                table: "RoleGroups",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<ulong>(
                name: "Enable",
                schema: "dbo",
                table: "RoleGroups",
                type: "bit",
                nullable: true,
                defaultValue: 1ul,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "RoleGroups",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyDate",
                schema: "dbo",
                table: "Patients",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastAccessDate",
                schema: "dbo",
                table: "Patients",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<ulong>(
                name: "Enable",
                schema: "dbo",
                table: "Patients",
                type: "bit",
                nullable: true,
                defaultValue: 1ul,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                schema: "dbo",
                table: "Patients",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "Patients",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyDate",
                schema: "dbo",
                table: "PatientRecords",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastAccessDate",
                schema: "dbo",
                table: "PatientRecords",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<ulong>(
                name: "Enable",
                schema: "dbo",
                table: "PatientRecords",
                type: "bit",
                nullable: true,
                defaultValue: 1ul,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "PatientRecords",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AnnotationDate",
                schema: "dbo",
                table: "PatientRecords",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<string>(
                name: "Annotation",
                schema: "dbo",
                table: "PatientRecords",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReadingDate",
                schema: "dbo",
                table: "PatientNotificationMessage",
                type: "datetime2(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NotifiedDate",
                schema: "dbo",
                table: "PatientNotificationMessage",
                type: "datetime2(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "Notified",
                schema: "dbo",
                table: "PatientNotificationMessage",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyDate",
                schema: "dbo",
                table: "PatientNotificationMessage",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastAccessDate",
                schema: "dbo",
                table: "PatientNotificationMessage",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<ulong>(
                name: "IsReaded",
                schema: "dbo",
                table: "PatientNotificationMessage",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<ulong>(
                name: "Enable",
                schema: "dbo",
                table: "PatientNotificationMessage",
                type: "bit",
                nullable: true,
                defaultValue: 1ul,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "PatientNotificationMessage",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                schema: "dbo",
                table: "PatientMedicationInformations",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyDate",
                schema: "dbo",
                table: "PatientMedicationInformations",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastAccessDate",
                schema: "dbo",
                table: "PatientMedicationInformations",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                schema: "dbo",
                table: "PatientMedicationInformations",
                type: "datetime2(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "Enable",
                schema: "dbo",
                table: "PatientMedicationInformations",
                type: "bit",
                nullable: true,
                defaultValue: 1ul,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "PatientMedicationInformations",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                schema: "dbo",
                table: "PatientHospitalizationInformations",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyDate",
                schema: "dbo",
                table: "PatientHospitalizationInformations",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastAccessDate",
                schema: "dbo",
                table: "PatientHospitalizationInformations",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                schema: "dbo",
                table: "PatientHospitalizationInformations",
                type: "datetime2(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "Enable",
                schema: "dbo",
                table: "PatientHospitalizationInformations",
                type: "bit",
                nullable: true,
                defaultValue: 1ul,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "PatientHospitalizationInformations",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyDate",
                schema: "dbo",
                table: "PatientFile",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastAccessDate",
                schema: "dbo",
                table: "PatientFile",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "FileData",
                schema: "dbo",
                table: "PatientFile",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "longblob",
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "Enable",
                schema: "dbo",
                table: "PatientFile",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "PatientFile",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyDate",
                schema: "dbo",
                table: "PatientAdditionalInformations",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastAccessDate",
                schema: "dbo",
                table: "PatientAdditionalInformations",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<ulong>(
                name: "Enable",
                schema: "dbo",
                table: "PatientAdditionalInformations",
                type: "bit",
                nullable: true,
                defaultValue: 1ul,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "PatientAdditionalInformations",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyDate",
                schema: "dbo",
                table: "Officies",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastAccessDate",
                schema: "dbo",
                table: "Officies",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<ulong>(
                name: "Enable",
                schema: "dbo",
                table: "Officies",
                type: "bit",
                nullable: true,
                defaultValue: 1ul,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "Officies",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyDate",
                schema: "dbo",
                table: "Medicals",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastAccessDate",
                schema: "dbo",
                table: "Medicals",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<ulong>(
                name: "Enable",
                schema: "dbo",
                table: "Medicals",
                type: "bit",
                nullable: true,
                defaultValue: 1ul,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "Medicals",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyDate",
                schema: "dbo",
                table: "MedicalFile",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastAccessDate",
                schema: "dbo",
                table: "MedicalFile",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "FileData",
                schema: "dbo",
                table: "MedicalFile",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "longblob",
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "Enable",
                schema: "dbo",
                table: "MedicalFile",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "MedicalFile",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyDate",
                schema: "dbo",
                table: "InfoTag",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastAccessDate",
                schema: "dbo",
                table: "InfoTag",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<ulong>(
                name: "Enable",
                schema: "dbo",
                table: "InfoTag",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "InfoTag",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyDate",
                schema: "dbo",
                table: "Genders",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastAccessDate",
                schema: "dbo",
                table: "Genders",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<ulong>(
                name: "Enable",
                schema: "dbo",
                table: "Genders",
                type: "bit",
                nullable: true,
                defaultValue: 1ul,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true,
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "Genders",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyDate",
                schema: "dbo",
                table: "ApplicationLanguage",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastAccessDate",
                schema: "dbo",
                table: "ApplicationLanguage",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<ulong>(
                name: "Enable",
                schema: "dbo",
                table: "ApplicationLanguage",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "ApplicationLanguage",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyDate",
                schema: "dbo",
                table: "ApplicationConfigSetting",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastAccessDate",
                schema: "dbo",
                table: "ApplicationConfigSetting",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<ulong>(
                name: "Enable",
                schema: "dbo",
                table: "ApplicationConfigSetting",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "ApplicationConfigSetting",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifyDate",
                schema: "dbo",
                table: "ApplicationCacheLogs",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastAccessDate",
                schema: "dbo",
                table: "ApplicationCacheLogs",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<ulong>(
                name: "Enable",
                schema: "dbo",
                table: "ApplicationCacheLogs",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTimeSlidingExpiration",
                schema: "dbo",
                table: "ApplicationCacheLogs",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "dbo",
                table: "ApplicationCacheLogs",
                type: "datetime2(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "ApplicationConfigSetting",
                columns: new[] { "Id", "CreatedDate", "Description", "Enable", "EndPointUrl_Cache", "EndPointUrl_StorageFiles", "Language", "LastAccessDate", "ModifyDate", "TypeLocationCache", "TypeLocationQueeMessaging", "TypeLocationSaveFiles" },
                values: new object[] { 1L, new DateTime(2023, 4, 25, 11, 53, 49, 9, DateTimeKind.Local).AddTicks(4942), "Default", 1ul, "", "", "pt-BR", new DateTime(2023, 4, 25, 11, 53, 49, 9, DateTimeKind.Local).AddTicks(4958), new DateTime(2023, 4, 25, 11, 53, 49, 9, DateTimeKind.Local).AddTicks(4957), 1, 0, 0 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "ApplicationLanguage",
                columns: new[] { "Id", "CreatedDate", "Description", "Enable", "Language", "LanguageKey", "LanguageValue", "LastAccessDate", "ModifyDate" },
                values: new object[] { 1L, new DateTime(2023, 4, 25, 11, 53, 49, 9, DateTimeKind.Local).AddTicks(4985), "Default", 1ul, "pt-BR", "Default_ptbr", "Padrão", new DateTime(2023, 4, 25, 11, 53, 49, 9, DateTimeKind.Local).AddTicks(4987), new DateTime(2023, 4, 25, 11, 53, 49, 9, DateTimeKind.Local).AddTicks(4986) });

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
                values: new object[] { 1L, 1ul, new DateTime(2023, 4, 25, 11, 53, 49, 9, DateTimeKind.Local).AddTicks(5201), "admin@sistemas.com", 1ul, "pt-BR", new DateTime(2023, 4, 25, 11, 53, 49, 9, DateTimeKind.Local).AddTicks(5201), "admin", null, new DateTime(2023, 4, 25, 11, 53, 49, 9, DateTimeKind.Local).AddTicks(5202), "User MOCK ", new byte[] { 44, 255, 196, 47, 75, 208, 67, 107, 138, 89, 190, 113, 13, 2, 26, 225, 6, 3, 97, 7, 179, 107, 118, 147, 175, 0, 186, 189, 144, 147, 144, 186, 169, 26, 0, 161, 105, 129, 243, 141, 242, 218, 195, 187, 117, 149, 6, 80, 8, 45, 70, 61, 65, 74, 234, 33, 108, 225, 246, 82, 225, 29, 123, 100 }, new byte[] { 254, 37, 33, 160, 27, 167, 217, 58, 71, 210, 58, 102, 143, 41, 141, 28, 252, 158, 74, 117, 45, 184, 117, 2, 48, 104, 4, 106, 68, 110, 40, 57, 137, 17, 226, 186, 147, 6, 233, 221, 92, 217, 255, 33, 126, 40, 159, 215, 132, 240, 172, 47, 183, 192, 6, 236, 52, 56, 131, 141, 129, 55, 236, 225, 247, 2, 128, 183, 141, 94, 191, 198, 178, 80, 89, 163, 207, 72, 83, 230, 248, 239, 214, 26, 68, 62, 249, 224, 91, 4, 168, 79, 231, 238, 153, 32, 151, 117, 0, 76, 96, 191, 69, 45, 121, 236, 180, 202, 20, 39, 71, 131, 58, 68, 249, 252, 150, 221, 135, 236, 166, 72, 142, 170, 37, 90, 72, 124 }, null, null, "Admin", "E. South America Standard Time" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Medicals",
                columns: new[] { "Id", "Accreditation", "CreatedDate", "CreatedUserId", "Email", "Enable", "LastAccessDate", "ModifyDate", "ModifyUserId", "Name", "OfficeId", "SecurityKey", "TypeAccreditation", "UserId" },
                values: new object[] { 1L, "123456", new DateTime(2023, 4, 25, 11, 53, 49, 11, DateTimeKind.Local).AddTicks(7001), 1L, "medical@sistemas.com", 1ul, new DateTime(2023, 4, 25, 11, 53, 49, 11, DateTimeKind.Local).AddTicks(7003), new DateTime(2023, 4, 25, 11, 53, 49, 11, DateTimeKind.Local).AddTicks(7003), null, "Medical MOCK ", 3L, null, 0, null });

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
                values: new object[] { 1L, "45675-970", "Aurelino Leal", "Centro", "Bahia", "Avenida Presidente Médici 264", "947.846.605-42", new DateTime(2023, 4, 25, 11, 53, 49, 13, DateTimeKind.Local).AddTicks(6739), 1L, new DateTime(1960, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Superior", "tiago.thales.mendes@andrade.com", "Milena Isabelly Vanessa", "(73) 98540-4268", 1ul, 1L, new DateTime(2023, 4, 25, 11, 53, 49, 13, DateTimeKind.Local).AddTicks(6742), 0, 1L, new DateTime(2023, 4, 25, 11, 53, 49, 13, DateTimeKind.Local).AddTicks(6742), null, "Tiago Thales Mendes", "(73) 2877-3408", "Professor", "13.809.283-7" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Users",
                columns: new[] { "Id", "Admin", "CreatedDate", "Email", "Enable", "Language", "LastAccessDate", "Login", "MedicalId", "ModifyDate", "Name", "PasswordHash", "PasswordSalt", "Refresh_token", "Refresh_token_expiry_time", "Role", "TimeZone" },
                values: new object[] { 2L, 0ul, new DateTime(2023, 4, 25, 11, 53, 49, 11, DateTimeKind.Local).AddTicks(7291), "doctor@sistemas.com", 1ul, "pt-BR", new DateTime(2023, 4, 25, 11, 53, 49, 11, DateTimeKind.Local).AddTicks(7292), "doctor", 1L, new DateTime(2023, 4, 25, 11, 53, 49, 11, DateTimeKind.Local).AddTicks(7293), "User Medical", new byte[] { 66, 45, 189, 67, 99, 58, 40, 181, 107, 23, 3, 166, 147, 109, 210, 99, 14, 31, 56, 101, 103, 144, 14, 203, 201, 85, 102, 254, 90, 146, 1, 69, 52, 66, 155, 185, 229, 146, 202, 240, 37, 4, 185, 68, 123, 238, 106, 119, 82, 239, 165, 174, 207, 19, 108, 61, 41, 106, 92, 221, 160, 38, 116, 117 }, new byte[] { 167, 43, 190, 26, 243, 242, 132, 32, 77, 86, 28, 120, 122, 109, 140, 114, 3, 111, 34, 168, 176, 73, 61, 173, 213, 50, 47, 23, 174, 238, 212, 77, 216, 220, 223, 192, 71, 168, 56, 227, 26, 187, 58, 164, 198, 211, 157, 139, 123, 133, 144, 226, 156, 113, 239, 200, 197, 59, 27, 236, 40, 16, 75, 211, 73, 189, 12, 238, 231, 88, 115, 88, 26, 129, 144, 129, 193, 134, 134, 31, 246, 124, 183, 69, 216, 124, 119, 119, 240, 214, 192, 142, 252, 104, 90, 156, 139, 97, 239, 208, 70, 228, 139, 226, 215, 10, 159, 22, 149, 83, 155, 91, 114, 129, 62, 207, 246, 8, 227, 60, 4, 29, 69, 164, 222, 42, 228, 49 }, null, null, "Medical", "E. South America Standard Time" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "RoleGroupUser",
                columns: new[] { "RoleGroupsId", "UsersId" },
                values: new object[] { 2L, 2L });

            migrationBuilder.CreateIndex(
                name: "IX_Users_MedicalId",
                schema: "dbo",
                table: "Users",
                column: "MedicalId",
                unique: true,
                filter: "[MedicalId] IS NOT NULL");
        }
    }
}
