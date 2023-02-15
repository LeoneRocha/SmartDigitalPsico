using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartDigitalPsico.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User",
                newSchema: "dbo");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "dbo",
                table: "User",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                schema: "dbo",
                table: "User",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RoleGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleGroupUser",
                columns: table => new
                {
                    RoleGroupsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleGroupUser", x => new { x.RoleGroupsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_RoleGroupUser_RoleGroups_RoleGroupsId",
                        column: x => x.RoleGroupsId,
                        principalTable: "RoleGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleGroupUser_User_UsersId",
                        column: x => x.UsersId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleGroupUser_UsersId",
                table: "RoleGroupUser",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleGroupUser");

            migrationBuilder.DropTable(
                name: "RoleGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                schema: "dbo",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "dbo",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "dbo",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");
        }
    }
}
