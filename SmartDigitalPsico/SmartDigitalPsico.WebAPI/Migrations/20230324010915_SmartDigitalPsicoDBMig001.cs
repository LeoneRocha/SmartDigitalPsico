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
                values: new object[] { new DateTime(2023, 3, 23, 22, 9, 14, 481, DateTimeKind.Local).AddTicks(9286), new DateTime(2023, 3, 23, 22, 9, 14, 481, DateTimeKind.Local).AddTicks(9304), new DateTime(2023, 3, 23, 22, 9, 14, 481, DateTimeKind.Local).AddTicks(9302) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationLanguage",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 3, 23, 22, 9, 14, 481, DateTimeKind.Local).AddTicks(9404), new DateTime(2023, 3, 23, 22, 9, 14, 481, DateTimeKind.Local).AddTicks(9408), new DateTime(2023, 3, 23, 22, 9, 14, 481, DateTimeKind.Local).AddTicks(9407) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Medicals",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 3, 23, 22, 9, 14, 482, DateTimeKind.Local).AddTicks(679), new DateTime(2023, 3, 23, 22, 9, 14, 482, DateTimeKind.Local).AddTicks(682), new DateTime(2023, 3, 23, 22, 9, 14, 482, DateTimeKind.Local).AddTicks(683) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 3, 23, 22, 9, 14, 482, DateTimeKind.Local).AddTicks(31), new DateTime(2023, 3, 23, 22, 9, 14, 482, DateTimeKind.Local).AddTicks(35), new DateTime(2023, 3, 23, 22, 9, 14, 482, DateTimeKind.Local).AddTicks(36), new byte[] { 41, 123, 183, 44, 224, 118, 124, 179, 218, 115, 121, 173, 240, 50, 62, 77, 199, 192, 104, 60, 244, 96, 118, 110, 207, 105, 220, 108, 95, 25, 113, 107, 68, 226, 34, 70, 10, 133, 222, 192, 129, 79, 138, 188, 216, 193, 203, 139, 124, 139, 53, 105, 200, 106, 25, 197, 102, 132, 120, 137, 46, 143, 140, 201 }, new byte[] { 104, 238, 129, 68, 123, 128, 197, 4, 142, 204, 139, 245, 27, 155, 77, 31, 167, 196, 181, 233, 36, 132, 103, 76, 192, 173, 225, 147, 73, 80, 104, 44, 136, 31, 218, 8, 245, 115, 55, 76, 100, 131, 68, 129, 114, 116, 40, 190, 131, 225, 237, 215, 3, 32, 118, 195, 243, 123, 59, 235, 173, 219, 190, 194, 87, 171, 40, 231, 192, 119, 133, 253, 121, 8, 115, 118, 155, 98, 186, 132, 36, 254, 39, 201, 181, 232, 59, 149, 39, 238, 202, 182, 154, 137, 96, 192, 88, 110, 21, 88, 207, 134, 103, 55, 93, 7, 142, 95, 5, 41, 92, 210, 46, 219, 212, 237, 26, 229, 46, 250, 131, 149, 57, 251, 246, 141, 84, 69 } });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 3, 23, 22, 9, 14, 482, DateTimeKind.Local).AddTicks(1363), new DateTime(2023, 3, 23, 22, 9, 14, 482, DateTimeKind.Local).AddTicks(1368), new DateTime(2023, 3, 23, 22, 9, 14, 482, DateTimeKind.Local).AddTicks(1369), new byte[] { 1, 164, 199, 189, 206, 243, 10, 75, 253, 197, 51, 205, 54, 159, 71, 92, 185, 50, 206, 0, 211, 246, 125, 160, 238, 115, 39, 150, 136, 207, 178, 67, 27, 193, 66, 132, 251, 72, 24, 73, 180, 56, 25, 175, 247, 109, 228, 96, 163, 141, 228, 90, 142, 155, 197, 227, 119, 206, 138, 246, 214, 237, 5, 132 }, new byte[] { 113, 133, 150, 78, 243, 121, 24, 128, 36, 7, 187, 89, 251, 64, 35, 50, 10, 8, 98, 127, 113, 119, 131, 27, 108, 72, 159, 30, 87, 128, 237, 136, 188, 148, 74, 44, 151, 166, 28, 134, 158, 58, 109, 190, 1, 170, 123, 34, 205, 19, 10, 51, 21, 22, 17, 106, 112, 120, 53, 249, 95, 29, 151, 87, 207, 160, 240, 97, 203, 82, 27, 147, 96, 106, 193, 41, 132, 144, 154, 124, 199, 140, 51, 82, 20, 190, 112, 212, 146, 213, 38, 216, 119, 42, 193, 237, 121, 180, 209, 147, 31, 208, 188, 128, 240, 75, 73, 164, 46, 97, 219, 3, 125, 135, 232, 20, 204, 0, 18, 109, 184, 0, 1, 150, 244, 58, 140, 225 } });
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
                values: new object[] { new DateTime(2023, 3, 23, 21, 54, 12, 155, DateTimeKind.Local).AddTicks(4930), new DateTime(2023, 3, 23, 21, 54, 12, 155, DateTimeKind.Local).AddTicks(4945), new DateTime(2023, 3, 23, 21, 54, 12, 155, DateTimeKind.Local).AddTicks(4944) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationLanguage",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 3, 23, 21, 54, 12, 155, DateTimeKind.Local).AddTicks(5008), new DateTime(2023, 3, 23, 21, 54, 12, 155, DateTimeKind.Local).AddTicks(5011), new DateTime(2023, 3, 23, 21, 54, 12, 155, DateTimeKind.Local).AddTicks(5010) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Medicals",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 3, 23, 21, 54, 12, 155, DateTimeKind.Local).AddTicks(5837), new DateTime(2023, 3, 23, 21, 54, 12, 155, DateTimeKind.Local).AddTicks(5838), new DateTime(2023, 3, 23, 21, 54, 12, 155, DateTimeKind.Local).AddTicks(5839) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 3, 23, 21, 54, 12, 155, DateTimeKind.Local).AddTicks(5372), new DateTime(2023, 3, 23, 21, 54, 12, 155, DateTimeKind.Local).AddTicks(5374), new DateTime(2023, 3, 23, 21, 54, 12, 155, DateTimeKind.Local).AddTicks(5376), new byte[] { 10, 184, 17, 106, 137, 136, 26, 20, 182, 174, 31, 239, 199, 73, 126, 178, 204, 21, 134, 23, 126, 215, 198, 29, 76, 47, 163, 233, 232, 115, 23, 201, 140, 7, 65, 227, 19, 113, 204, 43, 66, 66, 65, 11, 137, 33, 105, 180, 207, 217, 104, 13, 15, 253, 60, 14, 147, 78, 69, 35, 120, 7, 74, 70 }, new byte[] { 11, 24, 189, 159, 193, 67, 54, 226, 70, 58, 2, 68, 110, 182, 18, 217, 72, 200, 5, 178, 166, 108, 143, 50, 83, 122, 165, 157, 176, 84, 192, 5, 78, 244, 232, 129, 167, 100, 248, 192, 214, 22, 10, 226, 245, 43, 225, 199, 139, 92, 233, 134, 21, 124, 196, 206, 202, 233, 11, 202, 207, 30, 124, 200, 20, 195, 151, 181, 12, 235, 34, 200, 48, 222, 195, 172, 251, 124, 12, 217, 191, 213, 138, 27, 25, 219, 170, 85, 113, 121, 159, 86, 129, 115, 160, 81, 8, 216, 38, 145, 198, 4, 12, 213, 157, 199, 97, 155, 82, 96, 156, 141, 193, 228, 143, 127, 103, 250, 11, 222, 28, 47, 187, 237, 134, 250, 207, 214 } });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 3, 23, 21, 54, 12, 155, DateTimeKind.Local).AddTicks(6263), new DateTime(2023, 3, 23, 21, 54, 12, 155, DateTimeKind.Local).AddTicks(6266), new DateTime(2023, 3, 23, 21, 54, 12, 155, DateTimeKind.Local).AddTicks(6267), new byte[] { 87, 179, 80, 130, 74, 91, 230, 17, 69, 176, 105, 174, 53, 107, 140, 123, 148, 211, 125, 0, 193, 253, 196, 161, 88, 110, 17, 39, 190, 86, 11, 22, 69, 232, 215, 118, 235, 205, 154, 28, 159, 21, 174, 81, 206, 6, 166, 193, 68, 150, 86, 249, 210, 91, 232, 58, 48, 52, 11, 213, 14, 45, 113, 46 }, new byte[] { 100, 178, 216, 235, 188, 145, 102, 13, 105, 204, 158, 74, 86, 59, 239, 45, 164, 21, 205, 32, 8, 161, 100, 230, 102, 113, 74, 31, 172, 91, 91, 107, 55, 236, 143, 123, 83, 196, 66, 155, 101, 6, 62, 15, 111, 95, 190, 248, 89, 8, 5, 144, 133, 200, 192, 255, 176, 43, 76, 242, 126, 80, 100, 217, 128, 143, 84, 178, 174, 87, 106, 112, 171, 245, 53, 95, 121, 161, 242, 241, 255, 95, 23, 97, 104, 236, 49, 111, 82, 71, 224, 201, 105, 249, 80, 241, 213, 123, 71, 95, 84, 3, 3, 8, 118, 28, 103, 122, 46, 151, 51, 207, 65, 108, 188, 154, 153, 147, 170, 136, 249, 174, 167, 229, 152, 78, 62, 60 } });
        }
    }
}
