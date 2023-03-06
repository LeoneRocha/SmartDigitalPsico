using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartDigitalPsico.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class SmartDigitalPsicoDBMig002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeLocationCache",
                schema: "dbo",
                table: "ApplicationConfigSetting",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeLocationQueeMessaging",
                schema: "dbo",
                table: "ApplicationConfigSetting",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Medicals",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 3, 6, 20, 50, 18, 289, DateTimeKind.Local).AddTicks(4905), new DateTime(2023, 3, 6, 20, 50, 18, 289, DateTimeKind.Local).AddTicks(4906), new DateTime(2023, 3, 6, 20, 50, 18, 289, DateTimeKind.Local).AddTicks(4907) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 3, 6, 20, 50, 18, 289, DateTimeKind.Local).AddTicks(4424), new DateTime(2023, 3, 6, 20, 50, 18, 289, DateTimeKind.Local).AddTicks(4433), new DateTime(2023, 3, 6, 20, 50, 18, 289, DateTimeKind.Local).AddTicks(4433), new byte[] { 121, 213, 210, 25, 201, 28, 177, 62, 152, 58, 187, 160, 42, 83, 211, 42, 214, 42, 29, 16, 139, 168, 229, 81, 95, 16, 186, 34, 26, 183, 109, 246, 161, 190, 27, 132, 235, 218, 191, 253, 100, 88, 47, 235, 129, 169, 8, 243, 240, 229, 71, 64, 253, 215, 52, 19, 193, 57, 199, 59, 236, 46, 183, 130 }, new byte[] { 58, 50, 58, 69, 21, 170, 18, 230, 173, 191, 45, 8, 78, 155, 160, 166, 127, 101, 66, 237, 122, 58, 135, 5, 92, 215, 225, 217, 72, 36, 191, 10, 233, 163, 97, 108, 224, 178, 16, 35, 27, 179, 90, 210, 85, 137, 37, 128, 166, 244, 84, 55, 12, 239, 18, 140, 121, 123, 189, 128, 95, 152, 46, 38, 145, 206, 13, 178, 107, 190, 141, 176, 57, 244, 214, 112, 13, 230, 196, 111, 88, 82, 72, 172, 128, 166, 52, 250, 96, 152, 117, 110, 191, 108, 63, 3, 49, 171, 157, 96, 198, 207, 163, 28, 2, 9, 134, 136, 157, 245, 88, 127, 34, 113, 13, 2, 217, 128, 117, 68, 99, 135, 219, 30, 30, 1, 114, 203 } });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 3, 6, 20, 50, 18, 289, DateTimeKind.Local).AddTicks(4649), new DateTime(2023, 3, 6, 20, 50, 18, 289, DateTimeKind.Local).AddTicks(4650), new DateTime(2023, 3, 6, 20, 50, 18, 289, DateTimeKind.Local).AddTicks(4651), new byte[] { 191, 112, 3, 249, 232, 47, 36, 139, 175, 130, 69, 207, 247, 77, 117, 73, 124, 27, 135, 79, 155, 1, 33, 208, 207, 65, 190, 98, 231, 87, 52, 155, 66, 218, 72, 8, 3, 126, 204, 84, 213, 246, 169, 160, 35, 114, 113, 87, 96, 218, 107, 216, 88, 0, 10, 20, 123, 131, 4, 115, 184, 27, 80, 239 }, new byte[] { 139, 58, 59, 107, 157, 187, 94, 78, 87, 140, 16, 111, 138, 15, 229, 6, 83, 218, 171, 230, 235, 74, 39, 218, 241, 254, 189, 86, 80, 195, 129, 1, 223, 17, 163, 118, 243, 60, 22, 73, 117, 194, 174, 154, 228, 41, 62, 34, 155, 199, 227, 236, 157, 213, 94, 21, 148, 108, 192, 138, 252, 201, 52, 12, 128, 216, 235, 255, 22, 7, 7, 73, 49, 211, 19, 44, 142, 124, 61, 240, 72, 7, 42, 16, 46, 95, 40, 197, 178, 146, 247, 249, 202, 69, 42, 222, 208, 117, 45, 75, 196, 29, 66, 250, 50, 223, 61, 25, 234, 40, 21, 126, 3, 214, 191, 104, 58, 6, 175, 114, 86, 228, 52, 124, 17, 220, 40, 177 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeLocationCache",
                schema: "dbo",
                table: "ApplicationConfigSetting");

            migrationBuilder.DropColumn(
                name: "TypeLocationQueeMessaging",
                schema: "dbo",
                table: "ApplicationConfigSetting");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Medicals",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 3, 6, 20, 33, 39, 777, DateTimeKind.Local).AddTicks(2363), new DateTime(2023, 3, 6, 20, 33, 39, 777, DateTimeKind.Local).AddTicks(2364), new DateTime(2023, 3, 6, 20, 33, 39, 777, DateTimeKind.Local).AddTicks(2364) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 3, 6, 20, 33, 39, 777, DateTimeKind.Local).AddTicks(1847), new DateTime(2023, 3, 6, 20, 33, 39, 777, DateTimeKind.Local).AddTicks(1856), new DateTime(2023, 3, 6, 20, 33, 39, 777, DateTimeKind.Local).AddTicks(1857), new byte[] { 189, 211, 210, 118, 26, 244, 161, 211, 122, 228, 54, 154, 138, 137, 84, 84, 152, 152, 236, 6, 147, 67, 206, 59, 65, 137, 79, 228, 144, 74, 56, 137, 207, 30, 170, 48, 118, 171, 20, 120, 42, 166, 125, 100, 202, 23, 90, 237, 153, 246, 45, 212, 251, 180, 89, 9, 159, 246, 191, 40, 155, 97, 221, 87 }, new byte[] { 84, 250, 42, 129, 142, 191, 128, 131, 44, 33, 113, 84, 106, 189, 2, 160, 68, 163, 101, 128, 176, 236, 199, 250, 192, 38, 2, 66, 142, 177, 147, 242, 79, 197, 60, 106, 33, 57, 248, 35, 156, 252, 56, 4, 169, 36, 202, 181, 94, 91, 20, 73, 162, 108, 147, 85, 72, 37, 252, 103, 153, 144, 125, 128, 37, 3, 15, 249, 56, 135, 249, 3, 165, 143, 85, 175, 3, 15, 127, 161, 188, 157, 64, 109, 19, 4, 239, 245, 229, 93, 178, 79, 127, 176, 103, 198, 90, 84, 180, 169, 166, 85, 110, 210, 190, 60, 86, 113, 191, 250, 109, 139, 23, 159, 57, 191, 84, 82, 183, 87, 38, 89, 13, 58, 158, 184, 144, 183 } });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 3, 6, 20, 33, 39, 777, DateTimeKind.Local).AddTicks(2110), new DateTime(2023, 3, 6, 20, 33, 39, 777, DateTimeKind.Local).AddTicks(2111), new DateTime(2023, 3, 6, 20, 33, 39, 777, DateTimeKind.Local).AddTicks(2112), new byte[] { 17, 159, 47, 198, 115, 164, 72, 92, 40, 16, 92, 170, 87, 2, 139, 202, 151, 71, 216, 201, 60, 42, 250, 189, 10, 96, 215, 255, 83, 217, 95, 158, 185, 241, 82, 197, 12, 220, 114, 221, 133, 166, 63, 186, 26, 63, 10, 61, 247, 209, 16, 82, 203, 78, 238, 196, 131, 7, 135, 60, 236, 91, 159, 95 }, new byte[] { 115, 45, 21, 247, 139, 125, 169, 50, 9, 248, 199, 78, 131, 187, 217, 232, 166, 64, 163, 116, 0, 191, 117, 153, 139, 205, 199, 195, 254, 143, 143, 73, 1, 105, 187, 121, 165, 177, 144, 207, 214, 95, 178, 180, 176, 183, 238, 38, 91, 233, 87, 6, 130, 103, 182, 127, 46, 139, 92, 201, 156, 195, 49, 238, 43, 100, 75, 161, 189, 249, 4, 248, 62, 20, 48, 7, 150, 190, 223, 198, 25, 202, 187, 241, 219, 113, 183, 205, 252, 155, 250, 157, 144, 156, 138, 146, 193, 30, 209, 22, 63, 249, 124, 107, 190, 182, 97, 118, 195, 163, 238, 13, 228, 249, 159, 49, 212, 226, 95, 207, 212, 27, 0, 163, 66, 115, 109, 77 } });
        }
    }
}
