using Microsoft.EntityFrameworkCore.Migrations;

namespace wevi.Migrations
{
    public partial class addColumnPC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "participantcode",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "participantcode",
                table: "User");
        }
    }
}
