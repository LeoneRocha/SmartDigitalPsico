using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartDigitalPsico.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class SmartDigitalPsicoDBMig0003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResourceKey ",
                schema: "dbo",
                table: "ApplicationLanguage",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "ApplicationLanguage");

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
                columns: new[] { "CreatedDate", "Language", "LastAccessDate", "ModifyDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 4, 7, 19, 5, 44, 105, DateTimeKind.Local).AddTicks(1489), null, new DateTime(2023, 4, 7, 19, 5, 44, 105, DateTimeKind.Local).AddTicks(1490), new DateTime(2023, 4, 7, 19, 5, 44, 105, DateTimeKind.Local).AddTicks(1490), new byte[] { 92, 97, 137, 94, 46, 122, 136, 138, 94, 203, 248, 149, 81, 177, 145, 125, 77, 235, 81, 152, 92, 72, 8, 215, 187, 231, 34, 1, 244, 232, 248, 127, 83, 151, 240, 10, 18, 171, 108, 155, 140, 39, 86, 165, 62, 3, 72, 238, 19, 194, 123, 148, 245, 231, 84, 84, 146, 235, 35, 92, 222, 209, 36, 93 }, new byte[] { 66, 44, 200, 122, 103, 45, 252, 110, 236, 82, 104, 121, 245, 167, 230, 73, 181, 212, 25, 227, 225, 118, 255, 224, 36, 83, 34, 50, 228, 72, 99, 51, 242, 175, 77, 22, 208, 142, 179, 129, 170, 3, 103, 120, 144, 3, 107, 213, 247, 106, 144, 95, 37, 146, 108, 230, 74, 122, 193, 59, 201, 144, 7, 245, 138, 222, 199, 115, 160, 202, 189, 8, 201, 154, 188, 249, 101, 206, 96, 202, 190, 165, 247, 29, 186, 233, 119, 252, 91, 214, 109, 246, 181, 119, 55, 177, 228, 4, 247, 23, 18, 207, 192, 44, 9, 37, 107, 184, 104, 249, 138, 57, 19, 188, 178, 56, 199, 108, 179, 145, 13, 26, 115, 232, 219, 144, 91, 52 } });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "Language", "LastAccessDate", "ModifyDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 4, 7, 19, 5, 44, 107, DateTimeKind.Local).AddTicks(3954), null, new DateTime(2023, 4, 7, 19, 5, 44, 107, DateTimeKind.Local).AddTicks(3955), new DateTime(2023, 4, 7, 19, 5, 44, 107, DateTimeKind.Local).AddTicks(3956), new byte[] { 178, 204, 173, 18, 148, 30, 179, 225, 157, 168, 83, 208, 65, 105, 203, 121, 97, 226, 7, 147, 37, 116, 94, 61, 201, 113, 6, 184, 251, 203, 216, 131, 90, 192, 115, 251, 98, 92, 50, 214, 136, 149, 195, 216, 10, 31, 220, 114, 148, 71, 239, 84, 27, 98, 104, 158, 102, 103, 191, 239, 20, 147, 75, 3 }, new byte[] { 143, 231, 24, 61, 25, 219, 165, 27, 36, 109, 228, 21, 149, 74, 118, 102, 59, 48, 110, 75, 141, 69, 161, 21, 79, 20, 194, 132, 164, 217, 182, 251, 203, 229, 251, 14, 11, 34, 203, 204, 100, 77, 40, 65, 178, 18, 125, 108, 207, 97, 18, 183, 48, 56, 121, 195, 45, 43, 61, 232, 98, 218, 126, 185, 230, 41, 253, 211, 146, 202, 129, 113, 184, 213, 111, 159, 201, 62, 227, 209, 62, 1, 162, 18, 91, 206, 23, 132, 237, 63, 195, 86, 223, 208, 131, 206, 99, 46, 229, 19, 22, 6, 227, 54, 241, 81, 170, 202, 211, 125, 125, 147, 223, 14, 31, 236, 32, 60, 32, 130, 50, 190, 59, 169, 148, 147, 149, 61 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResourceKey ",
                schema: "dbo",
                table: "ApplicationLanguage");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationConfigSetting",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 4, 6, 15, 50, 47, 72, DateTimeKind.Local).AddTicks(544), new DateTime(2023, 4, 6, 15, 50, 47, 72, DateTimeKind.Local).AddTicks(569), new DateTime(2023, 4, 6, 15, 50, 47, 72, DateTimeKind.Local).AddTicks(566) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationLanguage",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 4, 6, 15, 50, 47, 72, DateTimeKind.Local).AddTicks(654), new DateTime(2023, 4, 6, 15, 50, 47, 72, DateTimeKind.Local).AddTicks(658), new DateTime(2023, 4, 6, 15, 50, 47, 72, DateTimeKind.Local).AddTicks(656) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Medicals",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 4, 6, 15, 50, 47, 77, DateTimeKind.Local).AddTicks(9679), new DateTime(2023, 4, 6, 15, 50, 47, 77, DateTimeKind.Local).AddTicks(9690), new DateTime(2023, 4, 6, 15, 50, 47, 77, DateTimeKind.Local).AddTicks(9692) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 4, 6, 15, 50, 47, 84, DateTimeKind.Local).AddTicks(5322), new DateTime(2023, 4, 6, 15, 50, 47, 84, DateTimeKind.Local).AddTicks(5333), new DateTime(2023, 4, 6, 15, 50, 47, 84, DateTimeKind.Local).AddTicks(5343) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "Language", "LastAccessDate", "ModifyDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 4, 6, 15, 50, 47, 72, DateTimeKind.Local).AddTicks(1153), "pt-BR", new DateTime(2023, 4, 6, 15, 50, 47, 72, DateTimeKind.Local).AddTicks(1155), new DateTime(2023, 4, 6, 15, 50, 47, 72, DateTimeKind.Local).AddTicks(1157), new byte[] { 99, 160, 130, 13, 99, 55, 209, 57, 186, 195, 102, 194, 172, 169, 230, 39, 242, 246, 117, 100, 59, 138, 182, 240, 152, 200, 136, 145, 51, 141, 170, 23, 8, 219, 97, 219, 241, 190, 78, 146, 162, 33, 231, 47, 243, 117, 16, 74, 97, 173, 184, 101, 198, 158, 2, 58, 22, 13, 237, 28, 112, 46, 19, 82 }, new byte[] { 108, 50, 2, 140, 75, 116, 157, 39, 119, 72, 12, 47, 121, 70, 155, 92, 98, 117, 40, 3, 24, 48, 1, 98, 154, 136, 240, 195, 199, 48, 162, 198, 191, 27, 64, 164, 145, 136, 150, 206, 21, 16, 84, 139, 86, 232, 10, 73, 99, 8, 95, 120, 133, 225, 74, 133, 76, 236, 195, 137, 245, 99, 104, 167, 241, 215, 10, 242, 230, 213, 64, 72, 99, 155, 168, 196, 58, 199, 235, 211, 152, 172, 143, 90, 38, 224, 136, 64, 51, 34, 211, 97, 19, 223, 176, 218, 14, 134, 178, 181, 163, 214, 146, 157, 132, 185, 180, 138, 113, 221, 215, 64, 84, 91, 182, 54, 229, 20, 156, 245, 135, 25, 63, 61, 13, 44, 246, 76 } });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "Language", "LastAccessDate", "ModifyDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 4, 6, 15, 50, 47, 78, DateTimeKind.Local).AddTicks(687), "pt-BR", new DateTime(2023, 4, 6, 15, 50, 47, 78, DateTimeKind.Local).AddTicks(694), new DateTime(2023, 4, 6, 15, 50, 47, 78, DateTimeKind.Local).AddTicks(697), new byte[] { 217, 227, 109, 150, 208, 149, 236, 206, 145, 123, 6, 107, 17, 170, 39, 194, 43, 149, 167, 246, 234, 193, 169, 244, 17, 34, 255, 175, 233, 191, 223, 40, 74, 209, 53, 151, 43, 57, 181, 215, 227, 156, 220, 248, 208, 60, 83, 12, 218, 25, 144, 189, 234, 217, 39, 85, 108, 51, 35, 207, 149, 224, 35, 231 }, new byte[] { 9, 249, 93, 149, 64, 206, 193, 217, 157, 87, 2, 121, 16, 227, 92, 143, 195, 237, 23, 113, 33, 171, 118, 243, 251, 140, 89, 20, 121, 125, 210, 136, 151, 224, 215, 80, 83, 223, 21, 143, 69, 138, 3, 183, 13, 163, 80, 239, 208, 212, 9, 20, 219, 91, 196, 99, 223, 255, 96, 70, 226, 179, 183, 181, 44, 132, 228, 168, 76, 64, 60, 238, 165, 24, 144, 16, 172, 89, 238, 125, 103, 188, 59, 190, 23, 0, 150, 243, 32, 233, 118, 180, 88, 79, 250, 106, 95, 60, 139, 178, 37, 168, 234, 164, 58, 237, 225, 27, 158, 63, 216, 13, 132, 49, 71, 206, 116, 236, 205, 233, 255, 131, 47, 18, 60, 57, 3, 175 } });
        }
    }
}
