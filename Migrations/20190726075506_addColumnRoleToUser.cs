using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace wevi.Migrations
{
    public partial class addColumnRoleToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Timeline_Banner_bannerid",
                table: "Timeline");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropIndex(
                name: "IX_Timeline_bannerid",
                table: "Timeline");

            migrationBuilder.DropColumn(
                name: "bannerid",
                table: "Timeline");

            migrationBuilder.AddColumn<int>(
                name: "role",
                table: "User",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "role",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "bannerid",
                table: "Timeline",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    adminid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    commentid = table.Column<int>(nullable: false),
                    email = table.Column<string>(nullable: true),
                    fullname = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.adminid);
                    table.ForeignKey(
                        name: "FK_Admin_Comment_commentid",
                        column: x => x.commentid,
                        principalTable: "Comment",
                        principalColumn: "commentid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Timeline_bannerid",
                table: "Timeline",
                column: "bannerid");

            migrationBuilder.CreateIndex(
                name: "IX_Admin_commentid",
                table: "Admin",
                column: "commentid");

            migrationBuilder.AddForeignKey(
                name: "FK_Timeline_Banner_bannerid",
                table: "Timeline",
                column: "bannerid",
                principalTable: "Banner",
                principalColumn: "bannerid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
