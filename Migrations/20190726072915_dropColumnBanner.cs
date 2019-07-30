using Microsoft.EntityFrameworkCore.Migrations;

namespace wevi.Migrations
{
    public partial class dropColumnBanner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bannerid",
                table: "Event");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "bannerid",
                table: "Event",
                nullable: false,
                defaultValue: 0);
        }
    }
}
