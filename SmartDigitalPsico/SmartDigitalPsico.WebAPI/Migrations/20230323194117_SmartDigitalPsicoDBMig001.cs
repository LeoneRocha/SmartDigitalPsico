using System;
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
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationConfigSetting",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 3, 23, 16, 41, 17, 312, DateTimeKind.Local).AddTicks(3748), new DateTime(2023, 3, 23, 16, 41, 17, 312, DateTimeKind.Local).AddTicks(3764), new DateTime(2023, 3, 23, 16, 41, 17, 312, DateTimeKind.Local).AddTicks(3763) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationLanguage",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 3, 23, 16, 41, 17, 312, DateTimeKind.Local).AddTicks(3824), new DateTime(2023, 3, 23, 16, 41, 17, 312, DateTimeKind.Local).AddTicks(3827), new DateTime(2023, 3, 23, 16, 41, 17, 312, DateTimeKind.Local).AddTicks(3825) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Medicals",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 3, 23, 16, 41, 17, 312, DateTimeKind.Local).AddTicks(4625), new DateTime(2023, 3, 23, 16, 41, 17, 312, DateTimeKind.Local).AddTicks(4627), new DateTime(2023, 3, 23, 16, 41, 17, 312, DateTimeKind.Local).AddTicks(4628) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 3, 23, 16, 41, 17, 312, DateTimeKind.Local).AddTicks(4175), new DateTime(2023, 3, 23, 16, 41, 17, 312, DateTimeKind.Local).AddTicks(4177), new DateTime(2023, 3, 23, 16, 41, 17, 312, DateTimeKind.Local).AddTicks(4178), new byte[] { 112, 54, 106, 89, 179, 34, 91, 65, 136, 2, 126, 105, 153, 238, 118, 193, 2, 249, 151, 176, 49, 93, 130, 14, 174, 21, 17, 45, 20, 189, 212, 15, 169, 13, 47, 181, 190, 122, 244, 149, 128, 72, 23, 212, 138, 235, 62, 229, 170, 243, 39, 210, 31, 3, 144, 138, 74, 154, 175, 248, 4, 42, 201, 236 }, new byte[] { 85, 25, 37, 29, 248, 125, 172, 179, 155, 220, 57, 99, 82, 2, 72, 35, 130, 250, 235, 237, 113, 210, 170, 59, 79, 22, 223, 255, 253, 58, 196, 47, 163, 3, 224, 209, 105, 87, 124, 249, 26, 113, 179, 232, 129, 196, 97, 208, 187, 75, 181, 115, 229, 7, 138, 149, 146, 117, 127, 147, 181, 132, 92, 224, 141, 220, 6, 182, 219, 13, 244, 51, 238, 104, 247, 235, 102, 78, 211, 229, 58, 247, 181, 227, 158, 37, 119, 239, 250, 152, 40, 150, 64, 105, 85, 137, 197, 69, 126, 238, 179, 167, 52, 124, 146, 15, 4, 112, 192, 54, 255, 44, 157, 86, 192, 134, 51, 148, 145, 248, 126, 74, 98, 247, 34, 96, 16, 218 } });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 3, 23, 16, 41, 17, 312, DateTimeKind.Local).AddTicks(5029), new DateTime(2023, 3, 23, 16, 41, 17, 312, DateTimeKind.Local).AddTicks(5031), new DateTime(2023, 3, 23, 16, 41, 17, 312, DateTimeKind.Local).AddTicks(5033), new byte[] { 237, 46, 61, 124, 249, 241, 95, 84, 201, 189, 192, 5, 92, 13, 190, 232, 237, 155, 220, 238, 3, 228, 16, 176, 193, 29, 239, 2, 240, 229, 67, 182, 231, 14, 143, 146, 124, 17, 208, 66, 194, 239, 216, 246, 217, 141, 10, 175, 16, 243, 99, 49, 17, 114, 74, 215, 231, 200, 177, 248, 212, 205, 206, 87 }, new byte[] { 21, 197, 136, 138, 160, 137, 32, 33, 172, 118, 4, 196, 150, 139, 140, 252, 94, 140, 73, 21, 41, 83, 48, 8, 182, 26, 27, 197, 109, 172, 99, 51, 91, 164, 222, 75, 216, 241, 18, 210, 175, 105, 154, 155, 252, 5, 69, 14, 88, 234, 72, 87, 42, 6, 61, 151, 219, 79, 166, 133, 84, 191, 8, 221, 79, 63, 47, 231, 250, 83, 111, 181, 189, 248, 224, 97, 183, 78, 90, 21, 67, 31, 72, 222, 110, 195, 32, 87, 13, 255, 54, 166, 138, 19, 11, 193, 124, 148, 67, 243, 74, 253, 39, 177, 155, 163, 5, 6, 96, 125, 169, 149, 245, 189, 159, 164, 190, 3, 202, 192, 130, 165, 39, 39, 108, 198, 68, 65 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationConfigSetting",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 3, 23, 16, 38, 57, 8, DateTimeKind.Local).AddTicks(9910), new DateTime(2023, 3, 23, 16, 38, 57, 8, DateTimeKind.Local).AddTicks(9929), new DateTime(2023, 3, 23, 16, 38, 57, 8, DateTimeKind.Local).AddTicks(9926) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationLanguage",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 3, 23, 16, 38, 57, 9, DateTimeKind.Local).AddTicks(28), new DateTime(2023, 3, 23, 16, 38, 57, 9, DateTimeKind.Local).AddTicks(32), new DateTime(2023, 3, 23, 16, 38, 57, 9, DateTimeKind.Local).AddTicks(31) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Medicals",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 3, 23, 16, 38, 57, 9, DateTimeKind.Local).AddTicks(1060), new DateTime(2023, 3, 23, 16, 38, 57, 9, DateTimeKind.Local).AddTicks(1062), new DateTime(2023, 3, 23, 16, 38, 57, 9, DateTimeKind.Local).AddTicks(1064) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 3, 23, 16, 38, 57, 9, DateTimeKind.Local).AddTicks(412), new DateTime(2023, 3, 23, 16, 38, 57, 9, DateTimeKind.Local).AddTicks(415), new DateTime(2023, 3, 23, 16, 38, 57, 9, DateTimeKind.Local).AddTicks(416), new byte[] { 37, 111, 149, 113, 66, 105, 70, 53, 170, 24, 72, 98, 237, 234, 85, 184, 4, 35, 218, 131, 36, 132, 55, 205, 241, 121, 216, 204, 140, 23, 132, 216, 205, 166, 222, 191, 161, 217, 85, 32, 197, 186, 74, 121, 136, 176, 8, 25, 3, 156, 197, 92, 41, 177, 128, 255, 192, 3, 18, 118, 103, 88, 82, 56 }, new byte[] { 167, 105, 26, 213, 171, 167, 140, 121, 222, 99, 215, 101, 139, 48, 188, 113, 159, 237, 182, 8, 152, 136, 115, 219, 248, 106, 86, 67, 253, 227, 84, 217, 174, 62, 76, 173, 151, 84, 116, 214, 151, 133, 151, 85, 147, 222, 232, 145, 119, 84, 182, 242, 85, 189, 34, 63, 14, 141, 61, 54, 245, 164, 232, 22, 57, 124, 185, 150, 166, 159, 225, 183, 29, 57, 243, 12, 221, 157, 189, 202, 195, 154, 50, 152, 238, 0, 216, 59, 194, 217, 141, 87, 253, 84, 125, 175, 126, 81, 9, 109, 100, 17, 121, 27, 195, 161, 66, 27, 87, 110, 204, 109, 117, 48, 26, 130, 103, 194, 106, 249, 28, 29, 226, 74, 55, 201, 226, 179 } });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 3, 23, 16, 38, 57, 9, DateTimeKind.Local).AddTicks(1762), new DateTime(2023, 3, 23, 16, 38, 57, 9, DateTimeKind.Local).AddTicks(1765), new DateTime(2023, 3, 23, 16, 38, 57, 9, DateTimeKind.Local).AddTicks(1767), new byte[] { 219, 232, 44, 99, 182, 4, 44, 43, 178, 116, 84, 202, 100, 65, 54, 186, 164, 135, 23, 92, 62, 106, 18, 195, 122, 172, 11, 64, 247, 186, 145, 37, 46, 225, 38, 192, 212, 135, 224, 8, 181, 156, 202, 193, 77, 241, 116, 37, 152, 131, 45, 85, 221, 67, 128, 89, 198, 96, 162, 8, 190, 132, 166, 157 }, new byte[] { 148, 140, 50, 69, 178, 177, 8, 51, 18, 11, 29, 90, 111, 60, 83, 216, 244, 19, 130, 39, 219, 153, 208, 172, 27, 222, 251, 27, 27, 79, 16, 224, 188, 51, 134, 81, 136, 204, 86, 217, 51, 49, 148, 86, 206, 148, 42, 36, 178, 159, 109, 228, 9, 248, 126, 244, 198, 167, 187, 12, 123, 124, 146, 183, 90, 20, 193, 65, 140, 121, 5, 79, 98, 253, 191, 95, 8, 188, 73, 166, 77, 21, 33, 232, 125, 74, 209, 155, 167, 59, 108, 38, 36, 255, 220, 199, 217, 38, 90, 190, 82, 44, 149, 151, 41, 79, 251, 63, 163, 114, 21, 251, 73, 19, 158, 7, 25, 202, 198, 74, 205, 70, 4, 231, 252, 250, 221, 5 } });
        }
    }
}
