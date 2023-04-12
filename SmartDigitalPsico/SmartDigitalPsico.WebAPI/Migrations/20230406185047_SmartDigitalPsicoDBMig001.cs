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
                name: "MaritalStatus",
                schema: "dbo",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                columns: new[] { "CreatedDate", "LastAccessDate", "MaritalStatus", "ModifyDate" },
                values: new object[] { new DateTime(2023, 4, 6, 15, 50, 47, 84, DateTimeKind.Local).AddTicks(5322), new DateTime(2023, 4, 6, 15, 50, 47, 84, DateTimeKind.Local).AddTicks(5333), 0, new DateTime(2023, 4, 6, 15, 50, 47, 84, DateTimeKind.Local).AddTicks(5343) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 4, 6, 15, 50, 47, 72, DateTimeKind.Local).AddTicks(1153), new DateTime(2023, 4, 6, 15, 50, 47, 72, DateTimeKind.Local).AddTicks(1155), new DateTime(2023, 4, 6, 15, 50, 47, 72, DateTimeKind.Local).AddTicks(1157), new byte[] { 99, 160, 130, 13, 99, 55, 209, 57, 186, 195, 102, 194, 172, 169, 230, 39, 242, 246, 117, 100, 59, 138, 182, 240, 152, 200, 136, 145, 51, 141, 170, 23, 8, 219, 97, 219, 241, 190, 78, 146, 162, 33, 231, 47, 243, 117, 16, 74, 97, 173, 184, 101, 198, 158, 2, 58, 22, 13, 237, 28, 112, 46, 19, 82 }, new byte[] { 108, 50, 2, 140, 75, 116, 157, 39, 119, 72, 12, 47, 121, 70, 155, 92, 98, 117, 40, 3, 24, 48, 1, 98, 154, 136, 240, 195, 199, 48, 162, 198, 191, 27, 64, 164, 145, 136, 150, 206, 21, 16, 84, 139, 86, 232, 10, 73, 99, 8, 95, 120, 133, 225, 74, 133, 76, 236, 195, 137, 245, 99, 104, 167, 241, 215, 10, 242, 230, 213, 64, 72, 99, 155, 168, 196, 58, 199, 235, 211, 152, 172, 143, 90, 38, 224, 136, 64, 51, 34, 211, 97, 19, 223, 176, 218, 14, 134, 178, 181, 163, 214, 146, 157, 132, 185, 180, 138, 113, 221, 215, 64, 84, 91, 182, 54, 229, 20, 156, 245, 135, 25, 63, 61, 13, 44, 246, 76 } });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 4, 6, 15, 50, 47, 78, DateTimeKind.Local).AddTicks(687), new DateTime(2023, 4, 6, 15, 50, 47, 78, DateTimeKind.Local).AddTicks(694), new DateTime(2023, 4, 6, 15, 50, 47, 78, DateTimeKind.Local).AddTicks(697), new byte[] { 217, 227, 109, 150, 208, 149, 236, 206, 145, 123, 6, 107, 17, 170, 39, 194, 43, 149, 167, 246, 234, 193, 169, 244, 17, 34, 255, 175, 233, 191, 223, 40, 74, 209, 53, 151, 43, 57, 181, 215, 227, 156, 220, 248, 208, 60, 83, 12, 218, 25, 144, 189, 234, 217, 39, 85, 108, 51, 35, 207, 149, 224, 35, 231 }, new byte[] { 9, 249, 93, 149, 64, 206, 193, 217, 157, 87, 2, 121, 16, 227, 92, 143, 195, 237, 23, 113, 33, 171, 118, 243, 251, 140, 89, 20, 121, 125, 210, 136, 151, 224, 215, 80, 83, 223, 21, 143, 69, 138, 3, 183, 13, 163, 80, 239, 208, 212, 9, 20, 219, 91, 196, 99, 223, 255, 96, 70, 226, 179, 183, 181, 44, 132, 228, 168, 76, 64, 60, 238, 165, 24, 144, 16, 172, 89, 238, 125, 103, 188, 59, 190, 23, 0, 150, 243, 32, 233, 118, 180, 88, 79, 250, 106, 95, 60, 139, 178, 37, 168, 234, 164, 58, 237, 225, 27, 158, 63, 216, 13, 132, 49, 71, 206, 116, 236, 205, 233, 255, 131, 47, 18, 60, 57, 3, 175 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationConfigSetting",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 4, 5, 18, 0, 33, 752, DateTimeKind.Local).AddTicks(2596), new DateTime(2023, 4, 5, 18, 0, 33, 752, DateTimeKind.Local).AddTicks(2617), new DateTime(2023, 4, 5, 18, 0, 33, 752, DateTimeKind.Local).AddTicks(2615) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationLanguage",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 4, 5, 18, 0, 33, 752, DateTimeKind.Local).AddTicks(2723), new DateTime(2023, 4, 5, 18, 0, 33, 752, DateTimeKind.Local).AddTicks(2727), new DateTime(2023, 4, 5, 18, 0, 33, 752, DateTimeKind.Local).AddTicks(2725) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Medicals",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 4, 5, 18, 0, 33, 757, DateTimeKind.Local).AddTicks(8720), new DateTime(2023, 4, 5, 18, 0, 33, 757, DateTimeKind.Local).AddTicks(8729), new DateTime(2023, 4, 5, 18, 0, 33, 757, DateTimeKind.Local).AddTicks(8731) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 4, 5, 18, 0, 33, 762, DateTimeKind.Local).AddTicks(9567), new DateTime(2023, 4, 5, 18, 0, 33, 762, DateTimeKind.Local).AddTicks(9572), new DateTime(2023, 4, 5, 18, 0, 33, 762, DateTimeKind.Local).AddTicks(9573) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 4, 5, 18, 0, 33, 752, DateTimeKind.Local).AddTicks(3427), new DateTime(2023, 4, 5, 18, 0, 33, 752, DateTimeKind.Local).AddTicks(3429), new DateTime(2023, 4, 5, 18, 0, 33, 752, DateTimeKind.Local).AddTicks(3431), new byte[] { 180, 83, 191, 59, 224, 95, 207, 217, 38, 81, 255, 246, 49, 96, 85, 189, 91, 73, 42, 185, 253, 92, 252, 78, 141, 191, 150, 5, 193, 54, 4, 253, 71, 89, 51, 105, 217, 214, 112, 220, 126, 226, 145, 70, 163, 50, 35, 222, 87, 156, 60, 193, 20, 25, 214, 2, 192, 16, 50, 170, 22, 75, 69, 120 }, new byte[] { 191, 240, 150, 121, 166, 196, 1, 181, 117, 5, 89, 145, 63, 75, 142, 239, 159, 102, 225, 3, 161, 12, 37, 127, 99, 115, 252, 62, 173, 154, 232, 46, 62, 216, 63, 220, 78, 20, 163, 124, 16, 102, 40, 158, 179, 6, 11, 133, 172, 27, 190, 187, 250, 248, 49, 183, 157, 195, 159, 121, 241, 87, 138, 43, 86, 84, 142, 251, 8, 243, 206, 137, 143, 231, 235, 167, 253, 251, 36, 104, 30, 74, 152, 149, 3, 221, 210, 20, 108, 68, 14, 85, 42, 221, 186, 44, 195, 62, 4, 12, 155, 255, 146, 100, 228, 107, 75, 74, 51, 120, 121, 246, 165, 125, 25, 229, 246, 217, 52, 30, 94, 146, 185, 215, 85, 145, 94, 5 } });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 4, 5, 18, 0, 33, 757, DateTimeKind.Local).AddTicks(9500), new DateTime(2023, 4, 5, 18, 0, 33, 757, DateTimeKind.Local).AddTicks(9503), new DateTime(2023, 4, 5, 18, 0, 33, 757, DateTimeKind.Local).AddTicks(9504), new byte[] { 206, 36, 30, 140, 80, 123, 129, 123, 210, 86, 248, 67, 16, 244, 199, 178, 99, 248, 12, 174, 194, 46, 23, 252, 33, 143, 71, 64, 186, 109, 202, 174, 221, 81, 125, 217, 63, 40, 23, 44, 73, 27, 91, 178, 104, 248, 210, 148, 221, 88, 51, 122, 134, 43, 40, 225, 148, 28, 136, 125, 236, 152, 221, 226 }, new byte[] { 143, 163, 174, 120, 98, 211, 255, 15, 74, 21, 163, 213, 84, 24, 246, 198, 141, 92, 156, 37, 46, 146, 56, 139, 207, 65, 95, 133, 225, 31, 141, 233, 42, 212, 157, 40, 210, 200, 155, 129, 47, 101, 254, 115, 179, 39, 17, 182, 13, 112, 79, 219, 166, 255, 161, 213, 27, 29, 55, 32, 206, 15, 89, 42, 101, 44, 4, 134, 180, 139, 109, 123, 124, 209, 185, 5, 53, 169, 134, 161, 205, 6, 8, 234, 19, 192, 166, 38, 237, 221, 52, 88, 9, 245, 202, 42, 125, 168, 95, 226, 4, 139, 144, 105, 205, 88, 49, 10, 253, 75, 187, 33, 251, 140, 5, 143, 143, 26, 110, 94, 135, 133, 117, 193, 189, 69, 107, 88 } });
        }
    }
}
