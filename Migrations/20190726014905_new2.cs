using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace wevi.Migrations
{
    public partial class new2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Numbering_participantcode",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_participantcode",
                table: "User");

            migrationBuilder.DropColumn(
                name: "participantcode",
                table: "User");

            migrationBuilder.AddColumn<DateTime>(
                name: "createdon",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createdon",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "participantcode",
                table: "User",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_User_participantcode",
                table: "User",
                column: "participantcode");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Numbering_participantcode",
                table: "User",
                column: "participantcode",
                principalTable: "Numbering",
                principalColumn: "participantcode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
