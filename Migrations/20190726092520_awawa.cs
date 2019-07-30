using Microsoft.EntityFrameworkCore.Migrations;

namespace wevi.Migrations
{
    public partial class awawa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "profilepicture",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "profilepicture",
                table: "User");
        }
    }
}
