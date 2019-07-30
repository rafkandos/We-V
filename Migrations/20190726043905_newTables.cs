using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace wevi.Migrations
{
    public partial class newTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "History");

            migrationBuilder.CreateTable(
                name: "HistoryEvent",
                columns: table => new
                {
                    hisevid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    userid = table.Column<int>(nullable: false),
                    eventid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryEvent", x => x.hisevid);
                    table.ForeignKey(
                        name: "FK_HistoryEvent_Event_eventid",
                        column: x => x.eventid,
                        principalTable: "Event",
                        principalColumn: "eventid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoryEvent_User_userid",
                        column: x => x.userid,
                        principalTable: "User",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoryProduct",
                columns: table => new
                {
                    hisproid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    userid = table.Column<int>(nullable: false),
                    productid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryProduct", x => x.hisproid);
                    table.ForeignKey(
                        name: "FK_HistoryProduct_Product_productid",
                        column: x => x.productid,
                        principalTable: "Product",
                        principalColumn: "productid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoryProduct_User_userid",
                        column: x => x.userid,
                        principalTable: "User",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoryEvent_eventid",
                table: "HistoryEvent",
                column: "eventid");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryEvent_userid",
                table: "HistoryEvent",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryProduct_productid",
                table: "HistoryProduct",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryProduct_userid",
                table: "HistoryProduct",
                column: "userid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoryEvent");

            migrationBuilder.DropTable(
                name: "HistoryProduct");

            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    historyid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    eventid = table.Column<int>(nullable: false),
                    productid = table.Column<int>(nullable: false),
                    userid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.historyid);
                    table.ForeignKey(
                        name: "FK_History_Event_eventid",
                        column: x => x.eventid,
                        principalTable: "Event",
                        principalColumn: "eventid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_History_Product_productid",
                        column: x => x.productid,
                        principalTable: "Product",
                        principalColumn: "productid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_History_User_userid",
                        column: x => x.userid,
                        principalTable: "User",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_History_eventid",
                table: "History",
                column: "eventid");

            migrationBuilder.CreateIndex(
                name: "IX_History_productid",
                table: "History",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_History_userid",
                table: "History",
                column: "userid");
        }
    }
}
