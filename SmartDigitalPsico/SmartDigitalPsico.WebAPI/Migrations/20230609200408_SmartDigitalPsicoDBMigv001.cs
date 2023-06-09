using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartDigitalPsicoWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class SmartDigitalPsicoDBMigv001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicalCalendar",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Enable = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    MedicalId = table.Column<long>(type: "bigint", nullable: false),
                    PatientId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedUserId = table.Column<long>(type: "bigint", nullable: true),
                    ModifyUserId = table.Column<long>(type: "bigint", nullable: true),
                    Title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AllDay = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ColorCategory = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Url = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PushedCalendar = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TimeZone = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastAccessDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalCalendar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalCalendar_Medicals_MedicalId",
                        column: x => x.MedicalId,
                        principalSchema: "dbo",
                        principalTable: "Medicals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalCalendar_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicalCalendar_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicalCalendar_Users_ModifyUserId",
                        column: x => x.ModifyUserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationConfigSetting",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 6, 9, 17, 4, 8, 504, DateTimeKind.Local).AddTicks(6991), new DateTime(2023, 6, 9, 17, 4, 8, 504, DateTimeKind.Local).AddTicks(7012), new DateTime(2023, 6, 9, 17, 4, 8, 504, DateTimeKind.Local).AddTicks(7005) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationLanguage",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 6, 9, 17, 4, 8, 504, DateTimeKind.Local).AddTicks(7049), new DateTime(2023, 6, 9, 17, 4, 8, 504, DateTimeKind.Local).AddTicks(7050), new DateTime(2023, 6, 9, 17, 4, 8, 504, DateTimeKind.Local).AddTicks(7049) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Medicals",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 6, 9, 17, 4, 8, 506, DateTimeKind.Local).AddTicks(8712), new DateTime(2023, 6, 9, 17, 4, 8, 506, DateTimeKind.Local).AddTicks(8714), new DateTime(2023, 6, 9, 17, 4, 8, 506, DateTimeKind.Local).AddTicks(8725) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 6, 9, 17, 4, 8, 508, DateTimeKind.Local).AddTicks(8603), new DateTime(2023, 6, 9, 17, 4, 8, 508, DateTimeKind.Local).AddTicks(8606), new DateTime(2023, 6, 9, 17, 4, 8, 508, DateTimeKind.Local).AddTicks(8606) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 6, 9, 17, 4, 8, 504, DateTimeKind.Local).AddTicks(7281), new DateTime(2023, 6, 9, 17, 4, 8, 504, DateTimeKind.Local).AddTicks(7281), new DateTime(2023, 6, 9, 17, 4, 8, 504, DateTimeKind.Local).AddTicks(7282), new byte[] { 10, 105, 186, 138, 61, 254, 47, 72, 36, 199, 80, 139, 173, 89, 119, 202, 81, 126, 100, 227, 242, 229, 83, 95, 22, 92, 223, 28, 78, 30, 20, 251, 235, 153, 59, 93, 210, 235, 18, 221, 39, 96, 150, 238, 199, 27, 243, 126, 201, 205, 13, 181, 64, 156, 146, 200, 122, 129, 134, 245, 251, 123, 162, 87 }, new byte[] { 193, 96, 132, 34, 171, 153, 156, 108, 166, 162, 245, 140, 91, 138, 143, 30, 177, 84, 62, 46, 212, 210, 162, 235, 186, 25, 161, 47, 43, 35, 86, 168, 134, 86, 164, 74, 95, 29, 178, 106, 74, 63, 127, 106, 218, 104, 91, 66, 171, 219, 10, 156, 157, 141, 67, 9, 69, 184, 172, 190, 77, 66, 170, 115, 108, 113, 229, 71, 20, 132, 15, 142, 112, 183, 224, 3, 135, 200, 10, 8, 145, 169, 27, 54, 65, 41, 188, 79, 47, 178, 138, 133, 157, 247, 189, 225, 200, 166, 129, 50, 47, 91, 47, 247, 65, 78, 20, 111, 172, 46, 237, 81, 15, 92, 90, 100, 40, 23, 164, 29, 134, 223, 119, 196, 157, 17, 128, 154 } });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 6, 9, 17, 4, 8, 506, DateTimeKind.Local).AddTicks(9027), new DateTime(2023, 6, 9, 17, 4, 8, 506, DateTimeKind.Local).AddTicks(9029), new DateTime(2023, 6, 9, 17, 4, 8, 506, DateTimeKind.Local).AddTicks(9029), new byte[] { 93, 241, 192, 18, 53, 245, 80, 179, 125, 141, 180, 14, 162, 26, 10, 145, 199, 195, 174, 72, 183, 206, 88, 117, 198, 104, 205, 18, 154, 167, 15, 14, 20, 71, 5, 94, 242, 94, 103, 47, 121, 45, 200, 147, 3, 211, 145, 206, 157, 178, 87, 122, 24, 209, 141, 181, 21, 108, 205, 135, 169, 104, 127, 78 }, new byte[] { 137, 28, 22, 244, 168, 1, 80, 224, 248, 3, 223, 72, 43, 93, 84, 18, 193, 4, 18, 36, 82, 204, 17, 67, 129, 75, 65, 162, 227, 102, 251, 135, 57, 95, 187, 89, 141, 230, 209, 245, 148, 107, 253, 185, 216, 146, 230, 49, 96, 183, 84, 115, 118, 185, 140, 29, 139, 217, 217, 27, 48, 84, 166, 221, 212, 57, 244, 193, 242, 186, 251, 122, 67, 141, 48, 175, 57, 109, 247, 246, 50, 88, 169, 239, 146, 207, 193, 162, 241, 100, 174, 253, 93, 100, 16, 139, 136, 72, 102, 55, 104, 199, 237, 8, 154, 135, 114, 242, 210, 223, 22, 120, 1, 72, 171, 30, 241, 85, 124, 239, 75, 60, 49, 240, 172, 94, 162, 199 } });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalCalendar_CreatedUserId",
                schema: "dbo",
                table: "MedicalCalendar",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalCalendar_MedicalId",
                schema: "dbo",
                table: "MedicalCalendar",
                column: "MedicalId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalCalendar_ModifyUserId",
                schema: "dbo",
                table: "MedicalCalendar",
                column: "ModifyUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalCalendar_PatientId",
                schema: "dbo",
                table: "MedicalCalendar",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalCalendar",
                schema: "dbo");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationConfigSetting",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 6, 9, 17, 0, 56, 17, DateTimeKind.Local).AddTicks(5649), new DateTime(2023, 6, 9, 17, 0, 56, 17, DateTimeKind.Local).AddTicks(5669), new DateTime(2023, 6, 9, 17, 0, 56, 17, DateTimeKind.Local).AddTicks(5668) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "ApplicationLanguage",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 6, 9, 17, 0, 56, 17, DateTimeKind.Local).AddTicks(5741), new DateTime(2023, 6, 9, 17, 0, 56, 17, DateTimeKind.Local).AddTicks(5742), new DateTime(2023, 6, 9, 17, 0, 56, 17, DateTimeKind.Local).AddTicks(5742) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Medicals",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 6, 9, 17, 0, 56, 19, DateTimeKind.Local).AddTicks(6951), new DateTime(2023, 6, 9, 17, 0, 56, 19, DateTimeKind.Local).AddTicks(6953), new DateTime(2023, 6, 9, 17, 0, 56, 19, DateTimeKind.Local).AddTicks(6961) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate" },
                values: new object[] { new DateTime(2023, 6, 9, 17, 0, 56, 21, DateTimeKind.Local).AddTicks(6907), new DateTime(2023, 6, 9, 17, 0, 56, 21, DateTimeKind.Local).AddTicks(6910), new DateTime(2023, 6, 9, 17, 0, 56, 21, DateTimeKind.Local).AddTicks(6910) });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 6, 9, 17, 0, 56, 17, DateTimeKind.Local).AddTicks(5979), new DateTime(2023, 6, 9, 17, 0, 56, 17, DateTimeKind.Local).AddTicks(5980), new DateTime(2023, 6, 9, 17, 0, 56, 17, DateTimeKind.Local).AddTicks(5980), new byte[] { 166, 4, 163, 125, 42, 141, 51, 246, 178, 193, 254, 234, 149, 187, 228, 208, 35, 43, 70, 77, 48, 108, 158, 254, 198, 240, 81, 90, 150, 35, 76, 157, 70, 190, 175, 127, 175, 122, 90, 247, 20, 191, 245, 105, 183, 177, 151, 68, 99, 250, 20, 124, 187, 10, 218, 91, 90, 114, 241, 169, 83, 251, 97, 64 }, new byte[] { 140, 239, 211, 9, 210, 106, 106, 216, 71, 197, 132, 16, 128, 150, 162, 192, 67, 105, 164, 230, 192, 4, 162, 247, 81, 109, 0, 37, 203, 96, 172, 58, 43, 1, 184, 240, 55, 105, 226, 123, 65, 202, 202, 140, 108, 88, 208, 117, 0, 228, 95, 95, 230, 97, 177, 230, 215, 96, 81, 206, 190, 189, 209, 58, 12, 47, 221, 45, 36, 220, 40, 80, 93, 190, 109, 63, 182, 17, 202, 104, 162, 203, 211, 73, 17, 221, 168, 206, 181, 188, 239, 86, 123, 165, 17, 118, 84, 94, 50, 66, 82, 233, 134, 39, 176, 10, 89, 194, 114, 89, 146, 12, 70, 83, 137, 105, 29, 5, 18, 111, 228, 151, 250, 81, 140, 94, 74, 181 } });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedDate", "LastAccessDate", "ModifyDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 6, 9, 17, 0, 56, 19, DateTimeKind.Local).AddTicks(7276), new DateTime(2023, 6, 9, 17, 0, 56, 19, DateTimeKind.Local).AddTicks(7277), new DateTime(2023, 6, 9, 17, 0, 56, 19, DateTimeKind.Local).AddTicks(7278), new byte[] { 63, 221, 95, 152, 10, 182, 77, 17, 173, 99, 2, 12, 16, 85, 156, 84, 78, 135, 168, 250, 67, 225, 62, 106, 128, 20, 154, 175, 31, 64, 232, 32, 49, 138, 174, 78, 134, 240, 140, 245, 194, 109, 176, 246, 161, 110, 106, 150, 156, 247, 160, 222, 129, 133, 6, 232, 238, 177, 205, 218, 189, 234, 7, 225 }, new byte[] { 158, 80, 250, 228, 43, 62, 230, 151, 34, 192, 25, 241, 207, 55, 252, 56, 73, 47, 40, 50, 39, 77, 241, 143, 48, 119, 227, 220, 128, 105, 108, 193, 120, 74, 18, 231, 34, 66, 36, 237, 142, 137, 67, 10, 245, 27, 87, 139, 92, 227, 114, 89, 99, 219, 40, 135, 252, 185, 184, 51, 100, 23, 167, 189, 97, 31, 237, 99, 22, 122, 243, 207, 114, 125, 2, 20, 126, 200, 187, 75, 227, 67, 227, 118, 22, 140, 197, 127, 22, 72, 54, 22, 22, 7, 109, 88, 200, 11, 197, 235, 153, 179, 219, 171, 106, 25, 234, 251, 236, 117, 51, 47, 93, 195, 100, 69, 139, 172, 179, 201, 58, 230, 208, 167, 169, 232, 20, 19 } });
        }
    }
}
