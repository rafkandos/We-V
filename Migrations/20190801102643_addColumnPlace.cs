using Microsoft.EntityFrameworkCore.Migrations;

namespace wevi.Migrations
{
    public partial class addColumnPlace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "place",
                table: "Event",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "place",
                table: "Event");
        }
    }
}
