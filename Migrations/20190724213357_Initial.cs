using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace wevi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banner",
                columns: table => new
                {
                    bannerid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banner", x => x.bannerid);
                });

            migrationBuilder.CreateTable(
                name: "Numbering",
                columns: table => new
                {
                    participantcode = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    userid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Numbering", x => x.participantcode);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    eventid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    eventname = table.Column<string>(nullable: true),
                    detailevent = table.Column<string>(nullable: true),
                    eventdate = table.Column<DateTime>(nullable: true),
                    statusevent = table.Column<string>(nullable: true),
                    eventcode = table.Column<string>(nullable: true),
                    bannerid = table.Column<int>(nullable: false),
                    countingevent = table.Column<int>(nullable: false),
                    linkstring = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.eventid);
                    table.ForeignKey(
                        name: "FK_Event_Banner_bannerid",
                        column: x => x.bannerid,
                        principalTable: "Banner",
                        principalColumn: "bannerid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    productid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    productname = table.Column<string>(nullable: true),
                    productdetail = table.Column<string>(nullable: true),
                    productcode = table.Column<string>(nullable: true),
                    bannerid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.productid);
                    table.ForeignKey(
                        name: "FK_Product_Banner_bannerid",
                        column: x => x.bannerid,
                        principalTable: "Banner",
                        principalColumn: "bannerid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    userid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    password = table.Column<string>(maxLength: 100, nullable: false),
                    phone = table.Column<string>(maxLength: 20, nullable: true),
                    school = table.Column<string>(maxLength: 80, nullable: true),
                    major = table.Column<string>(maxLength: 50, nullable: true),
                    interest = table.Column<string>(maxLength: 100, nullable: true),
                    email = table.Column<string>(maxLength: 100, nullable: false),
                    modifiedon = table.Column<int>(nullable: false),
                    dateofbirth = table.Column<DateTime>(nullable: true),
                    age = table.Column<int>(nullable: false),
                    fullname = table.Column<string>(maxLength: 200, nullable: true),
                    gender = table.Column<string>(maxLength: 20, nullable: true),
                    participantcode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.userid);
                    table.ForeignKey(
                        name: "FK_User_Numbering_participantcode",
                        column: x => x.participantcode,
                        principalTable: "Numbering",
                        principalColumn: "participantcode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Timeline",
                columns: table => new
                {
                    timelineid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    bannerid = table.Column<int>(nullable: false),
                    eventid = table.Column<int>(nullable: false),
                    productid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timeline", x => x.timelineid);
                    table.ForeignKey(
                        name: "FK_Timeline_Banner_bannerid",
                        column: x => x.bannerid,
                        principalTable: "Banner",
                        principalColumn: "bannerid",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    historyid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    userid = table.Column<int>(nullable: false),
                    eventid = table.Column<int>(nullable: false),
                    productid = table.Column<int>(nullable: false)
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
                name: "Comment",
                columns: table => new
                {
                    commentid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    userid = table.Column<int>(nullable: false),
                    comment = table.Column<string>(nullable: false),
                    timelineid = table.Column<int>(nullable: false),
                    commentdate = table.Column<DateTime>(nullable: false),
                    eventid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.commentid);
                    table.ForeignKey(
                        name: "FK_Comment_Event_eventid",
                        column: x => x.eventid,
                        principalTable: "Event",
                        principalColumn: "eventid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_Timeline_timelineid",
                        column: x => x.timelineid,
                        principalTable: "Timeline",
                        principalColumn: "timelineid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_User_userid",
                        column: x => x.userid,
                        principalTable: "User",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    adminid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    fullname = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    commentid = table.Column<int>(nullable: false)
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
                name: "IX_Admin_commentid",
                table: "Admin",
                column: "commentid");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_eventid",
                table: "Comment",
                column: "eventid");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_timelineid",
                table: "Comment",
                column: "timelineid");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_userid",
                table: "Comment",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_Event_bannerid",
                table: "Event",
                column: "bannerid");

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

            migrationBuilder.CreateIndex(
                name: "IX_Product_bannerid",
                table: "Product",
                column: "bannerid");

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
                name: "IX_Timeline_bannerid",
                table: "Timeline",
                column: "bannerid");

            migrationBuilder.CreateIndex(
                name: "IX_Timeline_eventid",
                table: "Timeline",
                column: "eventid");

            migrationBuilder.CreateIndex(
                name: "IX_Timeline_productid",
                table: "Timeline",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_User_participantcode",
                table: "User",
                column: "participantcode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "History");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropTable(
                name: "Qr");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Timeline");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Numbering");

            migrationBuilder.DropTable(
                name: "Banner");
        }
    }
}
