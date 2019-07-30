using Microsoft.EntityFrameworkCore.Migrations;

namespace wevi.Migrations
{
    public partial class addColumnBanner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Banner_bannerid",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Banner_bannerid",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_bannerid",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Event_bannerid",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "bannerid",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "bannerproduct",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "linkstring",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "bannerevent",
                table: "Event",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bannerproduct",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "linkstring",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "bannerevent",
                table: "Event");

            migrationBuilder.AddColumn<int>(
                name: "bannerid",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Product_bannerid",
                table: "Product",
                column: "bannerid");

            migrationBuilder.CreateIndex(
                name: "IX_Event_bannerid",
                table: "Event",
                column: "bannerid");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Banner_bannerid",
                table: "Event",
                column: "bannerid",
                principalTable: "Banner",
                principalColumn: "bannerid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Banner_bannerid",
                table: "Product",
                column: "bannerid",
                principalTable: "Banner",
                principalColumn: "bannerid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
