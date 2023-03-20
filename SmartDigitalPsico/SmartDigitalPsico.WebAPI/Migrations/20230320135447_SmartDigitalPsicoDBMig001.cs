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
            migrationBuilder.AddColumn<string>(
                name: "Language",
                schema: "dbo",
                table: "Users",
                type: "char(5)",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimeZone",
                schema: "dbo",
                table: "Users",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationConfigSetting",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 3, 20, 10, 54, 47, 295, DateTimeKind.Local).AddTicks(702), new DateTime(2023, 3, 20, 10, 54, 47, 295, DateTimeKind.Local).AddTicks(711), new DateTime(2023, 3, 20, 10, 54, 47, 295, DateTimeKind.Local).AddTicks(711) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationLanguage",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 3, 20, 10, 54, 47, 295, DateTimeKind.Local).AddTicks(740), new DateTime(2023, 3, 20, 10, 54, 47, 295, DateTimeKind.Local).AddTicks(742), new DateTime(2023, 3, 20, 10, 54, 47, 295, DateTimeKind.Local).AddTicks(741) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Medicals",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 3, 20, 10, 54, 47, 295, DateTimeKind.Local).AddTicks(1513), new DateTime(2023, 3, 20, 10, 54, 47, 295, DateTimeKind.Local).AddTicks(1514), new DateTime(2023, 3, 20, 10, 54, 47, 295, DateTimeKind.Local).AddTicks(1514) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "Language", "LastAccessDate", "ModifyDate", "PasswordHash", "PasswordSalt", "TimeZone" },
                values: new object[] { new DateTime(2023, 3, 20, 10, 54, 47, 295, DateTimeKind.Local).AddTicks(1030), null, new DateTime(2023, 3, 20, 10, 54, 47, 295, DateTimeKind.Local).AddTicks(1031), new DateTime(2023, 3, 20, 10, 54, 47, 295, DateTimeKind.Local).AddTicks(1032), new byte[] { 153, 2, 144, 255, 101, 89, 185, 96, 142, 143, 45, 224, 36, 147, 227, 50, 95, 129, 75, 153, 56, 182, 4, 99, 1, 10, 213, 243, 28, 19, 63, 207, 17, 74, 173, 122, 235, 179, 144, 40, 122, 204, 41, 58, 170, 30, 101, 151, 198, 200, 29, 137, 125, 190, 29, 71, 139, 84, 81, 164, 0, 95, 243, 195 }, new byte[] { 184, 133, 104, 188, 139, 182, 36, 151, 247, 36, 152, 223, 123, 45, 0, 33, 236, 161, 61, 84, 27, 109, 90, 93, 89, 242, 167, 96, 100, 197, 142, 94, 105, 241, 4, 41, 179, 222, 129, 37, 13, 101, 172, 249, 12, 148, 66, 123, 31, 94, 109, 179, 159, 209, 40, 159, 36, 59, 17, 180, 132, 32, 235, 171, 44, 6, 68, 35, 198, 34, 154, 168, 62, 221, 170, 195, 183, 205, 37, 193, 245, 82, 166, 118, 167, 243, 164, 119, 243, 180, 45, 80, 36, 157, 68, 130, 253, 89, 77, 226, 167, 225, 16, 136, 4, 244, 131, 76, 49, 180, 231, 202, 186, 236, 78, 58, 94, 123, 230, 41, 211, 105, 50, 219, 195, 135, 99, 29 }, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "Language", "LastAccessDate", "ModifyDate", "PasswordHash", "PasswordSalt", "TimeZone" },
                values: new object[] { new DateTime(2023, 3, 20, 10, 54, 47, 295, DateTimeKind.Local).AddTicks(1277), null, new DateTime(2023, 3, 20, 10, 54, 47, 295, DateTimeKind.Local).AddTicks(1278), new DateTime(2023, 3, 20, 10, 54, 47, 295, DateTimeKind.Local).AddTicks(1279), new byte[] { 128, 110, 237, 194, 118, 252, 107, 80, 114, 186, 4, 14, 164, 105, 100, 222, 119, 65, 28, 21, 180, 128, 46, 252, 187, 121, 54, 31, 66, 224, 255, 180, 186, 81, 184, 211, 112, 1, 162, 88, 169, 196, 78, 145, 172, 65, 53, 50, 104, 233, 142, 201, 2, 6, 25, 176, 99, 233, 161, 44, 25, 33, 197, 138 }, new byte[] { 71, 137, 127, 64, 7, 66, 253, 188, 93, 130, 195, 144, 103, 27, 45, 84, 216, 249, 221, 152, 86, 151, 252, 243, 163, 55, 178, 194, 42, 186, 228, 51, 187, 58, 149, 209, 168, 181, 6, 179, 178, 18, 167, 171, 65, 77, 92, 179, 215, 143, 120, 34, 228, 233, 104, 242, 23, 95, 120, 116, 34, 229, 2, 200, 43, 114, 100, 249, 105, 135, 241, 140, 179, 244, 237, 167, 187, 159, 164, 119, 12, 103, 21, 55, 50, 20, 139, 103, 74, 115, 108, 221, 66, 212, 181, 42, 83, 177, 35, 17, 127, 20, 166, 154, 230, 45, 213, 173, 210, 100, 119, 143, 177, 2, 131, 174, 238, 136, 247, 67, 179, 144, 254, 112, 237, 83, 135, 156 }, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TimeZone",
                schema: "dbo",
                table: "Users");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationConfigSetting",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 3, 18, 13, 10, 32, 971, DateTimeKind.Local).AddTicks(9226), new DateTime(2023, 3, 18, 13, 10, 32, 971, DateTimeKind.Local).AddTicks(9252), new DateTime(2023, 3, 18, 13, 10, 32, 971, DateTimeKind.Local).AddTicks(9249) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationLanguage",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 3, 18, 13, 10, 32, 971, DateTimeKind.Local).AddTicks(9569), new DateTime(2023, 3, 18, 13, 10, 32, 971, DateTimeKind.Local).AddTicks(9584), new DateTime(2023, 3, 18, 13, 10, 32, 971, DateTimeKind.Local).AddTicks(9582) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Medicals",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 3, 18, 13, 10, 32, 972, DateTimeKind.Local).AddTicks(1898), new DateTime(2023, 3, 18, 13, 10, 32, 972, DateTimeKind.Local).AddTicks(1905), new DateTime(2023, 3, 18, 13, 10, 32, 972, DateTimeKind.Local).AddTicks(1907) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 3, 18, 13, 10, 32, 972, DateTimeKind.Local).AddTicks(318), new DateTime(2023, 3, 18, 13, 10, 32, 972, DateTimeKind.Local).AddTicks(324), new DateTime(2023, 3, 18, 13, 10, 32, 972, DateTimeKind.Local).AddTicks(326), new byte[] { 230, 53, 187, 150, 34, 24, 64, 73, 28, 190, 173, 106, 17, 197, 199, 53, 161, 238, 154, 209, 159, 252, 121, 117, 228, 114, 111, 130, 9, 104, 0, 168, 192, 105, 167, 84, 8, 141, 0, 55, 156, 224, 182, 212, 253, 85, 251, 37, 116, 3, 0, 173, 92, 226, 91, 180, 238, 116, 240, 111, 73, 5, 20, 68 }, new byte[] { 139, 10, 115, 198, 109, 139, 51, 50, 1, 177, 5, 33, 69, 108, 97, 9, 242, 187, 27, 55, 127, 19, 205, 193, 106, 221, 158, 138, 99, 184, 243, 98, 100, 104, 16, 21, 49, 105, 143, 66, 178, 174, 220, 226, 248, 116, 57, 32, 166, 220, 67, 0, 77, 194, 150, 69, 225, 189, 20, 148, 115, 81, 207, 253, 163, 249, 222, 205, 196, 105, 37, 55, 1, 54, 68, 68, 52, 213, 129, 226, 131, 4, 147, 175, 223, 130, 56, 164, 129, 254, 225, 28, 20, 215, 216, 233, 62, 79, 205, 25, 159, 49, 132, 46, 189, 247, 65, 144, 60, 229, 107, 219, 71, 164, 235, 136, 140, 115, 157, 255, 126, 10, 254, 38, 187, 174, 29, 119 } });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 3, 18, 13, 10, 32, 972, DateTimeKind.Local).AddTicks(883), new DateTime(2023, 3, 18, 13, 10, 32, 972, DateTimeKind.Local).AddTicks(889), new DateTime(2023, 3, 18, 13, 10, 32, 972, DateTimeKind.Local).AddTicks(891), new byte[] { 51, 55, 255, 94, 181, 137, 193, 82, 27, 45, 100, 255, 130, 151, 61, 245, 245, 95, 119, 25, 85, 54, 198, 75, 70, 80, 67, 69, 154, 129, 65, 127, 30, 95, 18, 59, 92, 159, 127, 191, 35, 147, 235, 223, 139, 241, 33, 225, 54, 83, 131, 5, 213, 245, 241, 75, 191, 221, 122, 86, 146, 82, 164, 19 }, new byte[] { 138, 80, 156, 156, 38, 17, 111, 17, 64, 144, 86, 138, 241, 239, 12, 217, 81, 159, 175, 76, 197, 142, 63, 171, 209, 28, 216, 153, 115, 72, 220, 66, 171, 96, 227, 71, 26, 61, 126, 11, 239, 71, 13, 117, 241, 135, 11, 142, 93, 51, 169, 193, 39, 69, 181, 153, 65, 112, 68, 164, 170, 49, 8, 156, 104, 23, 30, 40, 68, 84, 135, 238, 134, 121, 194, 168, 64, 84, 157, 149, 61, 85, 241, 116, 227, 167, 224, 138, 40, 75, 61, 148, 36, 78, 65, 75, 246, 37, 142, 82, 154, 196, 63, 235, 87, 234, 74, 255, 154, 252, 243, 87, 151, 14, 24, 37, 189, 112, 28, 27, 171, 122, 226, 142, 90, 5, 252, 226 } });
        }
    }
}
