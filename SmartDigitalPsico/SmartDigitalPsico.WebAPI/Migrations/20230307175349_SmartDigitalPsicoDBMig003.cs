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
            migrationBuilder.AddColumn<int>(
                name: "TypeLocationSaveFile",
                schema: "dbo",
                table: "PatientFile",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeLocationSaveFile",
                schema: "dbo",
                table: "MedicalFile",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Medicals",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 3, 7, 14, 53, 49, 352, DateTimeKind.Local).AddTicks(7965), new DateTime(2023, 3, 7, 14, 53, 49, 352, DateTimeKind.Local).AddTicks(7968), new DateTime(2023, 3, 7, 14, 53, 49, 352, DateTimeKind.Local).AddTicks(7969) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 3, 7, 14, 53, 49, 352, DateTimeKind.Local).AddTicks(6914), new DateTime(2023, 3, 7, 14, 53, 49, 352, DateTimeKind.Local).AddTicks(6929), new DateTime(2023, 3, 7, 14, 53, 49, 352, DateTimeKind.Local).AddTicks(6930), new byte[] { 155, 234, 55, 52, 23, 30, 121, 156, 138, 247, 100, 111, 31, 165, 36, 166, 94, 181, 114, 214, 119, 78, 146, 136, 4, 94, 219, 41, 130, 72, 211, 65, 32, 189, 219, 125, 108, 100, 159, 61, 12, 111, 143, 33, 71, 13, 242, 18, 205, 123, 198, 231, 23, 151, 221, 27, 93, 46, 158, 111, 202, 49, 117, 62 }, new byte[] { 180, 216, 189, 112, 89, 64, 223, 181, 61, 74, 72, 18, 249, 199, 142, 205, 5, 172, 55, 64, 52, 57, 41, 39, 84, 42, 199, 153, 155, 251, 107, 79, 169, 153, 155, 9, 217, 111, 123, 149, 123, 38, 48, 245, 11, 232, 177, 147, 82, 71, 158, 22, 250, 21, 78, 215, 28, 27, 176, 164, 182, 61, 67, 154, 7, 186, 108, 81, 28, 47, 124, 16, 219, 42, 2, 249, 163, 199, 117, 118, 77, 39, 104, 227, 58, 23, 156, 196, 236, 198, 119, 148, 235, 136, 101, 170, 138, 228, 196, 237, 132, 105, 150, 198, 7, 238, 5, 178, 82, 34, 90, 88, 136, 243, 48, 128, 0, 170, 199, 194, 98, 7, 164, 245, 216, 164, 222, 136 } });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 3, 7, 14, 53, 49, 352, DateTimeKind.Local).AddTicks(7399), new DateTime(2023, 3, 7, 14, 53, 49, 352, DateTimeKind.Local).AddTicks(7401), new DateTime(2023, 3, 7, 14, 53, 49, 352, DateTimeKind.Local).AddTicks(7402), new byte[] { 251, 44, 57, 63, 147, 77, 170, 68, 14, 41, 214, 120, 81, 128, 189, 223, 159, 148, 218, 35, 238, 133, 180, 51, 23, 27, 225, 155, 129, 79, 84, 205, 211, 116, 245, 176, 203, 159, 7, 60, 113, 203, 48, 60, 78, 107, 6, 146, 139, 80, 121, 20, 154, 144, 138, 99, 79, 209, 112, 47, 251, 85, 107, 185 }, new byte[] { 18, 39, 47, 218, 226, 197, 112, 239, 198, 93, 98, 68, 76, 18, 105, 207, 68, 234, 70, 18, 70, 189, 218, 139, 254, 215, 206, 171, 109, 129, 61, 178, 204, 16, 238, 19, 100, 110, 5, 85, 16, 10, 1, 136, 182, 218, 202, 170, 128, 226, 116, 123, 92, 238, 36, 75, 13, 222, 79, 224, 150, 7, 139, 65, 217, 205, 44, 236, 211, 203, 172, 234, 32, 251, 143, 187, 140, 164, 133, 156, 41, 131, 2, 2, 74, 249, 115, 164, 115, 237, 137, 72, 119, 108, 5, 2, 222, 233, 36, 167, 13, 52, 212, 117, 110, 207, 216, 236, 40, 114, 155, 143, 230, 8, 86, 158, 35, 129, 226, 136, 243, 72, 142, 9, 39, 152, 82, 124 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeLocationSaveFile",
                schema: "dbo",
                table: "PatientFile");

            migrationBuilder.DropColumn(
                name: "TypeLocationSaveFile",
                schema: "dbo",
                table: "MedicalFile");

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
    }
}
