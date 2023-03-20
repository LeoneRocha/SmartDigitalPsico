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
            migrationBuilder.AddColumn<string>(
                name: "Refresh_token",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Refresh_token_expiry_time",
                schema: "dbo",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationConfigSetting",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 3, 20, 14, 47, 14, 182, DateTimeKind.Local).AddTicks(4390), new DateTime(2023, 3, 20, 14, 47, 14, 182, DateTimeKind.Local).AddTicks(4399), new DateTime(2023, 3, 20, 14, 47, 14, 182, DateTimeKind.Local).AddTicks(4399) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationLanguage",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 3, 20, 14, 47, 14, 182, DateTimeKind.Local).AddTicks(4430), new DateTime(2023, 3, 20, 14, 47, 14, 182, DateTimeKind.Local).AddTicks(4432), new DateTime(2023, 3, 20, 14, 47, 14, 182, DateTimeKind.Local).AddTicks(4431) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Medicals",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 3, 20, 14, 47, 14, 182, DateTimeKind.Local).AddTicks(5226), new DateTime(2023, 3, 20, 14, 47, 14, 182, DateTimeKind.Local).AddTicks(5227), new DateTime(2023, 3, 20, 14, 47, 14, 182, DateTimeKind.Local).AddTicks(5228) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate", "PasswordHash", "PasswordSalt", "Refresh_token", "Refresh_token_expiry_time" },
                values: new object[] { new DateTime(2023, 3, 20, 14, 47, 14, 182, DateTimeKind.Local).AddTicks(4674), new DateTime(2023, 3, 20, 14, 47, 14, 182, DateTimeKind.Local).AddTicks(4674), new DateTime(2023, 3, 20, 14, 47, 14, 182, DateTimeKind.Local).AddTicks(4675), new byte[] { 41, 112, 167, 128, 53, 193, 65, 249, 58, 186, 160, 248, 84, 232, 163, 220, 118, 126, 117, 219, 71, 61, 77, 49, 31, 119, 165, 168, 176, 228, 25, 245, 169, 11, 189, 171, 182, 15, 95, 47, 62, 237, 88, 129, 243, 21, 141, 254, 212, 215, 116, 208, 156, 132, 21, 41, 13, 97, 60, 19, 253, 47, 37, 184 }, new byte[] { 23, 72, 23, 194, 57, 211, 85, 118, 247, 207, 232, 170, 154, 199, 5, 193, 21, 133, 213, 154, 191, 99, 198, 201, 23, 45, 77, 248, 245, 254, 164, 92, 13, 170, 12, 3, 74, 185, 92, 89, 42, 44, 116, 185, 148, 96, 191, 185, 0, 175, 63, 165, 208, 202, 11, 195, 104, 220, 140, 181, 220, 219, 62, 161, 166, 88, 20, 37, 109, 246, 105, 16, 11, 75, 211, 4, 166, 63, 140, 187, 155, 142, 19, 9, 184, 34, 160, 57, 32, 190, 161, 31, 211, 12, 174, 243, 88, 3, 17, 208, 196, 149, 215, 216, 68, 228, 101, 204, 110, 18, 197, 70, 99, 58, 5, 122, 107, 249, 72, 187, 83, 244, 4, 186, 198, 211, 52, 219 }, null, null });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate", "PasswordHash", "PasswordSalt", "Refresh_token", "Refresh_token_expiry_time" },
                values: new object[] { new DateTime(2023, 3, 20, 14, 47, 14, 182, DateTimeKind.Local).AddTicks(4952), new DateTime(2023, 3, 20, 14, 47, 14, 182, DateTimeKind.Local).AddTicks(4952), new DateTime(2023, 3, 20, 14, 47, 14, 182, DateTimeKind.Local).AddTicks(4953), new byte[] { 136, 231, 247, 255, 64, 65, 120, 143, 228, 205, 70, 84, 175, 19, 159, 150, 106, 63, 174, 52, 171, 169, 110, 213, 162, 227, 172, 39, 131, 204, 4, 0, 180, 180, 37, 244, 220, 105, 147, 207, 196, 20, 56, 185, 4, 114, 7, 165, 105, 220, 231, 127, 235, 187, 84, 243, 28, 255, 182, 200, 30, 103, 113, 97 }, new byte[] { 132, 7, 54, 74, 141, 98, 47, 208, 196, 172, 53, 124, 25, 163, 135, 42, 220, 213, 194, 103, 254, 18, 31, 132, 91, 62, 181, 50, 25, 117, 63, 157, 115, 219, 32, 165, 63, 34, 74, 225, 208, 236, 126, 104, 125, 20, 100, 55, 51, 188, 34, 117, 215, 142, 80, 117, 104, 202, 141, 117, 114, 236, 88, 67, 97, 141, 186, 72, 53, 52, 247, 53, 162, 72, 125, 48, 160, 244, 216, 42, 114, 42, 158, 25, 108, 213, 67, 189, 248, 110, 144, 178, 122, 19, 101, 60, 155, 45, 214, 47, 127, 178, 210, 171, 125, 229, 193, 118, 155, 176, 165, 65, 245, 227, 219, 135, 93, 193, 77, 65, 142, 53, 114, 71, 6, 105, 157, 242 }, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Refresh_token",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Refresh_token_expiry_time",
                schema: "dbo",
                table: "Users");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationConfigSetting",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 3, 20, 10, 58, 45, 444, DateTimeKind.Local).AddTicks(8807), new DateTime(2023, 3, 20, 10, 58, 45, 444, DateTimeKind.Local).AddTicks(8820), new DateTime(2023, 3, 20, 10, 58, 45, 444, DateTimeKind.Local).AddTicks(8819) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationLanguage",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 3, 20, 10, 58, 45, 444, DateTimeKind.Local).AddTicks(8847), new DateTime(2023, 3, 20, 10, 58, 45, 444, DateTimeKind.Local).AddTicks(8848), new DateTime(2023, 3, 20, 10, 58, 45, 444, DateTimeKind.Local).AddTicks(8847) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Medicals",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 3, 20, 10, 58, 45, 444, DateTimeKind.Local).AddTicks(9497), new DateTime(2023, 3, 20, 10, 58, 45, 444, DateTimeKind.Local).AddTicks(9498), new DateTime(2023, 3, 20, 10, 58, 45, 444, DateTimeKind.Local).AddTicks(9498) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 3, 20, 10, 58, 45, 444, DateTimeKind.Local).AddTicks(9031), new DateTime(2023, 3, 20, 10, 58, 45, 444, DateTimeKind.Local).AddTicks(9032), new DateTime(2023, 3, 20, 10, 58, 45, 444, DateTimeKind.Local).AddTicks(9033), new byte[] { 250, 188, 161, 147, 138, 210, 173, 220, 131, 185, 143, 189, 216, 99, 247, 210, 182, 172, 141, 202, 145, 151, 117, 237, 238, 208, 169, 244, 244, 195, 130, 87, 61, 43, 213, 191, 38, 203, 81, 189, 145, 163, 213, 204, 73, 243, 144, 252, 69, 11, 119, 150, 250, 131, 161, 18, 74, 184, 212, 4, 167, 222, 106, 244 }, new byte[] { 57, 234, 136, 133, 166, 162, 246, 184, 245, 28, 188, 152, 59, 179, 61, 133, 184, 115, 99, 127, 71, 131, 22, 42, 53, 18, 196, 61, 137, 103, 33, 217, 146, 95, 242, 206, 207, 204, 152, 42, 123, 201, 232, 85, 103, 4, 31, 187, 251, 187, 165, 23, 186, 244, 171, 30, 170, 43, 165, 230, 124, 241, 79, 239, 35, 155, 97, 20, 138, 74, 77, 65, 120, 212, 21, 172, 117, 78, 95, 53, 39, 99, 191, 192, 3, 147, 100, 79, 249, 7, 76, 250, 31, 207, 218, 243, 178, 112, 79, 0, 77, 17, 10, 58, 18, 106, 133, 9, 155, 23, 71, 166, 246, 92, 197, 251, 183, 208, 233, 73, 245, 116, 228, 36, 26, 30, 83, 143 } });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 3, 20, 10, 58, 45, 444, DateTimeKind.Local).AddTicks(9263), new DateTime(2023, 3, 20, 10, 58, 45, 444, DateTimeKind.Local).AddTicks(9264), new DateTime(2023, 3, 20, 10, 58, 45, 444, DateTimeKind.Local).AddTicks(9265), new byte[] { 102, 164, 179, 149, 141, 64, 203, 50, 17, 136, 187, 183, 139, 229, 188, 142, 190, 142, 74, 185, 182, 198, 24, 172, 80, 233, 35, 165, 117, 105, 194, 118, 162, 174, 241, 92, 225, 53, 136, 80, 29, 56, 186, 255, 15, 160, 223, 235, 112, 89, 95, 232, 25, 115, 54, 146, 13, 140, 43, 27, 25, 157, 104, 48 }, new byte[] { 48, 109, 42, 98, 63, 220, 222, 148, 44, 16, 186, 159, 115, 111, 42, 23, 232, 234, 137, 101, 39, 217, 83, 48, 198, 178, 7, 104, 56, 71, 103, 70, 102, 134, 216, 215, 59, 96, 130, 57, 202, 181, 187, 240, 92, 85, 146, 26, 22, 241, 202, 246, 165, 66, 61, 14, 55, 28, 143, 159, 46, 97, 155, 255, 19, 155, 221, 61, 222, 140, 253, 184, 255, 120, 243, 186, 76, 88, 9, 102, 225, 29, 102, 7, 137, 204, 116, 238, 226, 97, 157, 158, 171, 51, 159, 255, 239, 238, 115, 27, 190, 172, 83, 159, 103, 201, 117, 101, 12, 127, 60, 250, 17, 68, 45, 190, 107, 84, 80, 236, 40, 110, 51, 112, 28, 83, 233, 167 } });
        }
    }
}
