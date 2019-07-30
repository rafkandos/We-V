using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace wevi.Migrations
{
    public partial class drop3Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Event_eventid",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Timeline_timelineid",
                table: "Comment");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropTable(
                name: "Qr");

            migrationBuilder.DropTable(
                name: "Timeline");

            migrationBuilder.DropIndex(
                name: "IX_Comment_eventid",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "eventid",
                table: "Comment");

            migrationBuilder.RenameColumn(
                name: "timelineid",
                table: "Comment",
                newName: "productid");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_timelineid",
                table: "Comment",
                newName: "IX_Comment_productid");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Product_productid",
                table: "Comment",
                column: "productid",
                principalTable: "Product",
                principalColumn: "productid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Product_productid",
                table: "Comment");

            migrationBuilder.RenameColumn(
                name: "productid",
                table: "Comment",
                newName: "timelineid");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_productid",
                table: "Comment",
                newName: "IX_Comment_timelineid");

            migrationBuilder.AddColumn<int>(
                name: "eventid",
                table: "Comment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    profileid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    userid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.profileid);
                    table.ForeignKey(
                        name: "FK_Profile_User_userid",
                        column: x => x.userid,
                        principalTable: "User",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Qr",
                columns: table => new
                {
                    qrid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    eventid = table.Column<int>(nullable: false),
                    productid = table.Column<int>(nullable: false),
                    userid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qr", x => x.qrid);
                    table.ForeignKey(
                        name: "FK_Qr_Event_eventid",
                        column: x => x.eventid,
                        principalTable: "Event",
                        principalColumn: "eventid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Qr_Product_productid",
                        column: x => x.productid,
                        principalTable: "Product",
                        principalColumn: "productid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Qr_User_userid",
                        column: x => x.userid,
                        principalTable: "User",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Timeline",
                columns: table => new
                {
                    timelineid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    eventid = table.Column<int>(nullable: false),
                    productid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timeline", x => x.timelineid);
                    table.ForeignKey(
                        name: "FK_Timeline_Event_eventid",
                        column: x => x.eventid,
                        principalTable: "Event",
                        principalColumn: "eventid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Timeline_Product_productid",
                        column: x => x.productid,
                        principalTable: "Product",
                        principalColumn: "productid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_eventid",
                table: "Comment",
                column: "eventid");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_userid",
                table: "Profile",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_Qr_eventid",
                table: "Qr",
                column: "eventid");

            migrationBuilder.CreateIndex(
                name: "IX_Qr_productid",
                table: "Qr",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_Qr_userid",
                table: "Qr",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_Timeline_eventid",
                table: "Timeline",
                column: "eventid");

            migrationBuilder.CreateIndex(
                name: "IX_Timeline_productid",
                table: "Timeline",
                column: "productid");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Event_eventid",
                table: "Comment",
                column: "eventid",
                principalTable: "Event",
                principalColumn: "eventid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Timeline_timelineid",
                table: "Comment",
                column: "timelineid",
                principalTable: "Timeline",
                principalColumn: "timelineid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
