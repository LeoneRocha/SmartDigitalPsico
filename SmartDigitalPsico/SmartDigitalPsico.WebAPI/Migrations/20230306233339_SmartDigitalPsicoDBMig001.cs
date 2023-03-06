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
            migrationBuilder.AddColumn<int>(
                name: "TypeLocationSaveFiles",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeLocationSaveFiles",
                schema: "dbo",
                table: "ApplicationConfigSetting");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Medicals",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 3, 6, 11, 11, 13, 276, DateTimeKind.Local).AddTicks(7055), new DateTime(2023, 3, 6, 11, 11, 13, 276, DateTimeKind.Local).AddTicks(7061), new DateTime(2023, 3, 6, 11, 11, 13, 276, DateTimeKind.Local).AddTicks(7062) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 3, 6, 11, 11, 13, 276, DateTimeKind.Local).AddTicks(5538), new DateTime(2023, 3, 6, 11, 11, 13, 276, DateTimeKind.Local).AddTicks(5556), new DateTime(2023, 3, 6, 11, 11, 13, 276, DateTimeKind.Local).AddTicks(5558), new byte[] { 29, 86, 108, 104, 155, 149, 15, 24, 70, 81, 165, 192, 39, 73, 55, 242, 19, 68, 181, 141, 170, 35, 126, 22, 67, 159, 200, 7, 165, 81, 160, 251, 180, 82, 51, 9, 38, 204, 8, 46, 101, 12, 187, 73, 92, 209, 63, 86, 226, 250, 158, 149, 227, 131, 130, 211, 86, 126, 55, 148, 89, 102, 16, 194 }, new byte[] { 196, 203, 39, 32, 77, 106, 244, 13, 230, 40, 238, 97, 250, 136, 232, 11, 76, 211, 26, 133, 83, 28, 206, 250, 168, 118, 62, 147, 30, 11, 84, 160, 106, 111, 26, 148, 65, 93, 114, 89, 136, 37, 209, 243, 126, 144, 198, 9, 229, 128, 170, 49, 70, 102, 109, 164, 58, 229, 54, 213, 186, 18, 231, 3, 7, 43, 6, 250, 153, 120, 56, 152, 26, 228, 19, 64, 25, 191, 140, 2, 141, 134, 158, 42, 247, 194, 86, 117, 151, 80, 240, 11, 179, 247, 99, 136, 170, 64, 200, 232, 82, 162, 88, 1, 44, 95, 190, 83, 223, 30, 43, 25, 132, 45, 42, 52, 191, 46, 106, 2, 84, 22, 195, 163, 73, 88, 227, 46 } });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 3, 6, 11, 11, 13, 276, DateTimeKind.Local).AddTicks(6059), new DateTime(2023, 3, 6, 11, 11, 13, 276, DateTimeKind.Local).AddTicks(6064), new DateTime(2023, 3, 6, 11, 11, 13, 276, DateTimeKind.Local).AddTicks(6066), new byte[] { 153, 187, 74, 165, 128, 153, 151, 240, 6, 15, 214, 51, 192, 25, 56, 176, 216, 171, 184, 213, 90, 217, 179, 118, 26, 215, 78, 136, 208, 111, 207, 15, 241, 222, 164, 4, 43, 210, 176, 105, 80, 229, 5, 18, 189, 163, 45, 176, 15, 231, 30, 188, 80, 84, 32, 161, 251, 191, 49, 15, 188, 231, 255, 180 }, new byte[] { 82, 47, 66, 56, 247, 247, 166, 182, 163, 72, 139, 204, 124, 44, 29, 105, 252, 91, 178, 118, 143, 243, 77, 214, 133, 218, 91, 109, 197, 10, 95, 240, 172, 122, 224, 201, 94, 2, 111, 144, 144, 47, 38, 215, 61, 245, 70, 46, 33, 174, 217, 160, 51, 58, 50, 209, 151, 90, 8, 93, 233, 36, 137, 45, 45, 14, 208, 4, 172, 61, 44, 116, 195, 153, 212, 172, 117, 69, 55, 209, 30, 23, 59, 39, 211, 217, 16, 187, 108, 248, 136, 181, 62, 181, 98, 210, 132, 216, 62, 182, 233, 56, 77, 179, 222, 174, 61, 243, 249, 126, 220, 245, 176, 110, 96, 124, 211, 232, 249, 32, 192, 203, 88, 76, 255, 5, 197, 42 } });
        }
    }
}
