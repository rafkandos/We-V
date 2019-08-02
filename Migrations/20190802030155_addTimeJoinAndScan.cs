using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace wevi.Migrations
{
    public partial class addTimeJoinAndScan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "scantime",
                table: "HistoryProduct",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "jointime",
                table: "HistoryEvent",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "scantime",
                table: "HistoryProduct");

            migrationBuilder.DropColumn(
                name: "jointime",
                table: "HistoryEvent");
        }
    }
}
