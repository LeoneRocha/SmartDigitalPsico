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
            migrationBuilder.AlterColumn<string>(
                name: "Language",
                schema: "dbo",
                table: "Users",
                type: "varchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(5)",
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                schema: "dbo",
                table: "Specialties",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(5)",
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                schema: "dbo",
                table: "RoleGroups",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(5)",
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                schema: "dbo",
                table: "Officies",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(5)",
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                schema: "dbo",
                table: "Genders",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(5)",
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                schema: "dbo",
                table: "ApplicationLanguage",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(5)",
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                schema: "dbo",
                table: "ApplicationConfigSetting",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(5)",
                oldMaxLength: 5);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Language",
                schema: "dbo",
                table: "Users",
                type: "char(5)",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                schema: "dbo",
                table: "Specialties",
                type: "char(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                schema: "dbo",
                table: "RoleGroups",
                type: "char(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                schema: "dbo",
                table: "Officies",
                type: "char(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                schema: "dbo",
                table: "Genders",
                type: "char(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                schema: "dbo",
                table: "ApplicationLanguage",
                type: "char(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                schema: "dbo",
                table: "ApplicationConfigSetting",
                type: "char(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10);

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
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 3, 20, 10, 54, 47, 295, DateTimeKind.Local).AddTicks(1030), new DateTime(2023, 3, 20, 10, 54, 47, 295, DateTimeKind.Local).AddTicks(1031), new DateTime(2023, 3, 20, 10, 54, 47, 295, DateTimeKind.Local).AddTicks(1032), new byte[] { 153, 2, 144, 255, 101, 89, 185, 96, 142, 143, 45, 224, 36, 147, 227, 50, 95, 129, 75, 153, 56, 182, 4, 99, 1, 10, 213, 243, 28, 19, 63, 207, 17, 74, 173, 122, 235, 179, 144, 40, 122, 204, 41, 58, 170, 30, 101, 151, 198, 200, 29, 137, 125, 190, 29, 71, 139, 84, 81, 164, 0, 95, 243, 195 }, new byte[] { 184, 133, 104, 188, 139, 182, 36, 151, 247, 36, 152, 223, 123, 45, 0, 33, 236, 161, 61, 84, 27, 109, 90, 93, 89, 242, 167, 96, 100, 197, 142, 94, 105, 241, 4, 41, 179, 222, 129, 37, 13, 101, 172, 249, 12, 148, 66, 123, 31, 94, 109, 179, 159, 209, 40, 159, 36, 59, 17, 180, 132, 32, 235, 171, 44, 6, 68, 35, 198, 34, 154, 168, 62, 221, 170, 195, 183, 205, 37, 193, 245, 82, 166, 118, 167, 243, 164, 119, 243, 180, 45, 80, 36, 157, 68, 130, 253, 89, 77, 226, 167, 225, 16, 136, 4, 244, 131, 76, 49, 180, 231, 202, 186, 236, 78, 58, 94, 123, 230, 41, 211, 105, 50, 219, 195, 135, 99, 29 } });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 3, 20, 10, 54, 47, 295, DateTimeKind.Local).AddTicks(1277), new DateTime(2023, 3, 20, 10, 54, 47, 295, DateTimeKind.Local).AddTicks(1278), new DateTime(2023, 3, 20, 10, 54, 47, 295, DateTimeKind.Local).AddTicks(1279), new byte[] { 128, 110, 237, 194, 118, 252, 107, 80, 114, 186, 4, 14, 164, 105, 100, 222, 119, 65, 28, 21, 180, 128, 46, 252, 187, 121, 54, 31, 66, 224, 255, 180, 186, 81, 184, 211, 112, 1, 162, 88, 169, 196, 78, 145, 172, 65, 53, 50, 104, 233, 142, 201, 2, 6, 25, 176, 99, 233, 161, 44, 25, 33, 197, 138 }, new byte[] { 71, 137, 127, 64, 7, 66, 253, 188, 93, 130, 195, 144, 103, 27, 45, 84, 216, 249, 221, 152, 86, 151, 252, 243, 163, 55, 178, 194, 42, 186, 228, 51, 187, 58, 149, 209, 168, 181, 6, 179, 178, 18, 167, 171, 65, 77, 92, 179, 215, 143, 120, 34, 228, 233, 104, 242, 23, 95, 120, 116, 34, 229, 2, 200, 43, 114, 100, 249, 105, 135, 241, 140, 179, 244, 237, 167, 187, 159, 164, 119, 12, 103, 21, 55, 50, 20, 139, 103, 74, 115, 108, 221, 66, 212, 181, 42, 83, 177, 35, 17, 127, 20, 166, 154, 230, 45, 213, 173, 210, 100, 119, 143, 177, 2, 131, 174, 238, 136, 247, 67, 179, 144, 254, 112, 237, 83, 135, 156 } });
        }
    }
}
