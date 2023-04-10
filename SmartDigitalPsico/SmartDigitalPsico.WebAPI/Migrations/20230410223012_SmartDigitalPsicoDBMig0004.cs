using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartDigitalPsico.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class SmartDigitalPsicoDBMig0004 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationConfigSetting",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 4, 10, 19, 30, 11, 503, DateTimeKind.Local).AddTicks(5033), new DateTime(2023, 4, 10, 19, 30, 11, 503, DateTimeKind.Local).AddTicks(5050), new DateTime(2023, 4, 10, 19, 30, 11, 503, DateTimeKind.Local).AddTicks(5048) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationLanguage",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 4, 10, 19, 30, 11, 503, DateTimeKind.Local).AddTicks(5141), new DateTime(2023, 4, 10, 19, 30, 11, 503, DateTimeKind.Local).AddTicks(5145), new DateTime(2023, 4, 10, 19, 30, 11, 503, DateTimeKind.Local).AddTicks(5144) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Medicals",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 4, 10, 19, 30, 11, 509, DateTimeKind.Local).AddTicks(6943), new DateTime(2023, 4, 10, 19, 30, 11, 509, DateTimeKind.Local).AddTicks(6961), new DateTime(2023, 4, 10, 19, 30, 11, 509, DateTimeKind.Local).AddTicks(6963) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 4, 10, 19, 30, 11, 516, DateTimeKind.Local).AddTicks(285), new DateTime(2023, 4, 10, 19, 30, 11, 516, DateTimeKind.Local).AddTicks(295), new DateTime(2023, 4, 10, 19, 30, 11, 516, DateTimeKind.Local).AddTicks(296) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 4, 10, 19, 30, 11, 503, DateTimeKind.Local).AddTicks(5496), new DateTime(2023, 4, 10, 19, 30, 11, 503, DateTimeKind.Local).AddTicks(5498), new DateTime(2023, 4, 10, 19, 30, 11, 503, DateTimeKind.Local).AddTicks(5500), new byte[] { 214, 14, 104, 171, 240, 158, 79, 5, 240, 129, 63, 39, 8, 195, 147, 195, 145, 186, 205, 206, 249, 217, 64, 61, 56, 204, 4, 195, 169, 64, 63, 131, 40, 58, 76, 71, 188, 161, 137, 161, 219, 171, 171, 123, 124, 223, 55, 162, 105, 195, 175, 113, 94, 216, 218, 200, 89, 60, 17, 177, 234, 171, 7, 103 }, new byte[] { 212, 105, 175, 80, 65, 47, 22, 175, 212, 84, 158, 255, 142, 249, 103, 132, 146, 224, 43, 113, 144, 205, 127, 12, 178, 43, 66, 143, 159, 63, 2, 234, 74, 93, 183, 156, 182, 234, 82, 182, 13, 172, 251, 224, 47, 119, 117, 32, 198, 152, 190, 97, 229, 224, 83, 175, 191, 160, 108, 190, 228, 184, 132, 72, 136, 129, 92, 242, 206, 117, 56, 8, 30, 253, 59, 49, 79, 53, 195, 120, 102, 21, 213, 28, 165, 77, 166, 202, 123, 88, 164, 73, 90, 141, 251, 26, 55, 44, 60, 93, 213, 133, 255, 22, 47, 48, 64, 156, 176, 154, 163, 110, 250, 20, 75, 183, 201, 81, 109, 141, 60, 125, 70, 19, 199, 223, 132, 174 } });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 4, 10, 19, 30, 11, 509, DateTimeKind.Local).AddTicks(8742), new DateTime(2023, 4, 10, 19, 30, 11, 509, DateTimeKind.Local).AddTicks(8749), new DateTime(2023, 4, 10, 19, 30, 11, 509, DateTimeKind.Local).AddTicks(8750), new byte[] { 96, 136, 209, 146, 236, 217, 100, 69, 84, 82, 68, 247, 2, 32, 150, 31, 3, 240, 238, 142, 249, 25, 29, 167, 61, 225, 151, 191, 130, 208, 240, 106, 80, 90, 72, 254, 167, 85, 42, 240, 163, 23, 99, 177, 136, 163, 4, 140, 110, 179, 219, 143, 92, 48, 146, 190, 112, 204, 87, 39, 6, 20, 247, 89 }, new byte[] { 42, 79, 99, 115, 74, 250, 224, 198, 211, 188, 129, 154, 59, 228, 185, 145, 216, 107, 157, 190, 51, 252, 17, 53, 52, 119, 113, 136, 202, 110, 147, 111, 241, 190, 141, 81, 135, 52, 110, 19, 47, 142, 131, 198, 67, 19, 43, 182, 172, 34, 151, 223, 210, 26, 39, 239, 110, 108, 172, 117, 232, 201, 42, 125, 23, 95, 123, 250, 1, 61, 129, 115, 6, 149, 151, 109, 112, 3, 249, 146, 228, 180, 215, 229, 88, 69, 193, 36, 196, 80, 17, 181, 129, 180, 148, 97, 60, 148, 119, 123, 19, 244, 28, 2, 109, 164, 213, 169, 236, 178, 168, 25, 41, 132, 93, 211, 190, 62, 46, 182, 135, 240, 246, 49, 176, 129, 149, 95 } });

            migrationBuilder.CreateIndex(
                name: "Idx_ApplicationLanguage_ResourceKey_Language_LanguageKey_Unique",
                schema: "dbo",
                table: "ApplicationLanguage",
                columns: new[] { "ResourceKey ", "Language", "LanguageKey" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Idx_ApplicationLanguage_ResourceKey_Language_LanguageKey_Unique",
                schema: "dbo",
                table: "ApplicationLanguage");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationConfigSetting",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 4, 7, 19, 5, 44, 105, DateTimeKind.Local).AddTicks(1205), new DateTime(2023, 4, 7, 19, 5, 44, 105, DateTimeKind.Local).AddTicks(1213), new DateTime(2023, 4, 7, 19, 5, 44, 105, DateTimeKind.Local).AddTicks(1212) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationLanguage",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 4, 7, 19, 5, 44, 105, DateTimeKind.Local).AddTicks(1243), new DateTime(2023, 4, 7, 19, 5, 44, 105, DateTimeKind.Local).AddTicks(1244), new DateTime(2023, 4, 7, 19, 5, 44, 105, DateTimeKind.Local).AddTicks(1243) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Medicals",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 4, 7, 19, 5, 44, 107, DateTimeKind.Local).AddTicks(3640), new DateTime(2023, 4, 7, 19, 5, 44, 107, DateTimeKind.Local).AddTicks(3644), new DateTime(2023, 4, 7, 19, 5, 44, 107, DateTimeKind.Local).AddTicks(3644) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 4, 7, 19, 5, 44, 109, DateTimeKind.Local).AddTicks(5597), new DateTime(2023, 4, 7, 19, 5, 44, 109, DateTimeKind.Local).AddTicks(5600), new DateTime(2023, 4, 7, 19, 5, 44, 109, DateTimeKind.Local).AddTicks(5600) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 4, 7, 19, 5, 44, 105, DateTimeKind.Local).AddTicks(1489), new DateTime(2023, 4, 7, 19, 5, 44, 105, DateTimeKind.Local).AddTicks(1490), new DateTime(2023, 4, 7, 19, 5, 44, 105, DateTimeKind.Local).AddTicks(1490), new byte[] { 92, 97, 137, 94, 46, 122, 136, 138, 94, 203, 248, 149, 81, 177, 145, 125, 77, 235, 81, 152, 92, 72, 8, 215, 187, 231, 34, 1, 244, 232, 248, 127, 83, 151, 240, 10, 18, 171, 108, 155, 140, 39, 86, 165, 62, 3, 72, 238, 19, 194, 123, 148, 245, 231, 84, 84, 146, 235, 35, 92, 222, 209, 36, 93 }, new byte[] { 66, 44, 200, 122, 103, 45, 252, 110, 236, 82, 104, 121, 245, 167, 230, 73, 181, 212, 25, 227, 225, 118, 255, 224, 36, 83, 34, 50, 228, 72, 99, 51, 242, 175, 77, 22, 208, 142, 179, 129, 170, 3, 103, 120, 144, 3, 107, 213, 247, 106, 144, 95, 37, 146, 108, 230, 74, 122, 193, 59, 201, 144, 7, 245, 138, 222, 199, 115, 160, 202, 189, 8, 201, 154, 188, 249, 101, 206, 96, 202, 190, 165, 247, 29, 186, 233, 119, 252, 91, 214, 109, 246, 181, 119, 55, 177, 228, 4, 247, 23, 18, 207, 192, 44, 9, 37, 107, 184, 104, 249, 138, 57, 19, 188, 178, 56, 199, 108, 179, 145, 13, 26, 115, 232, 219, 144, 91, 52 } });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 4, 7, 19, 5, 44, 107, DateTimeKind.Local).AddTicks(3954), new DateTime(2023, 4, 7, 19, 5, 44, 107, DateTimeKind.Local).AddTicks(3955), new DateTime(2023, 4, 7, 19, 5, 44, 107, DateTimeKind.Local).AddTicks(3956), new byte[] { 178, 204, 173, 18, 148, 30, 179, 225, 157, 168, 83, 208, 65, 105, 203, 121, 97, 226, 7, 147, 37, 116, 94, 61, 201, 113, 6, 184, 251, 203, 216, 131, 90, 192, 115, 251, 98, 92, 50, 214, 136, 149, 195, 216, 10, 31, 220, 114, 148, 71, 239, 84, 27, 98, 104, 158, 102, 103, 191, 239, 20, 147, 75, 3 }, new byte[] { 143, 231, 24, 61, 25, 219, 165, 27, 36, 109, 228, 21, 149, 74, 118, 102, 59, 48, 110, 75, 141, 69, 161, 21, 79, 20, 194, 132, 164, 217, 182, 251, 203, 229, 251, 14, 11, 34, 203, 204, 100, 77, 40, 65, 178, 18, 125, 108, 207, 97, 18, 183, 48, 56, 121, 195, 45, 43, 61, 232, 98, 218, 126, 185, 230, 41, 253, 211, 146, 202, 129, 113, 184, 213, 111, 159, 201, 62, 227, 209, 62, 1, 162, 18, 91, 206, 23, 132, 237, 63, 195, 86, 223, 208, 131, 206, 99, 46, 229, 19, 22, 6, 227, 54, 241, 81, 170, 202, 211, 125, 125, 147, 223, 14, 31, 236, 32, 60, 32, 130, 50, 190, 59, 169, 148, 147, 149, 61 } });
        }
    }
}
