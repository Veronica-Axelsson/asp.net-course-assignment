using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class Tableadjusted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserProfileEntityUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.RoleId);
                    table.ForeignKey(
                        name: "FK_UserRole_UserProfiles_UserProfileEntityUserId",
                        column: x => x.UserProfileEntityUserId,
                        principalTable: "UserProfiles",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserProfileEntityUserId",
                table: "UserRole",
                column: "UserProfileEntityUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRole");
        }
    }
}
