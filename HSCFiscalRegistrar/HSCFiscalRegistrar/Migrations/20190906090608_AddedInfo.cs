using HSCFiscalRegistrar.Models;
using HSCFiscalRegistrar.Models.APKInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HSCFiscalRegistrar.Migrations
{
    public partial class AddedInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kkms",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    SerialNumber = table.Column<string>(nullable: true),
                    PointOfPayment = table.Column<string>(nullable: true),
                    FnsKkmId = table.Column<string>(nullable: true),
                    TerminalNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kkms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orgs",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Okved = table.Column<string>(nullable: true),
                    TaxationType = table.Column<int>(nullable: false),
                    Inn = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orgs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegInfos",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    OrgId = table.Column<string>(nullable: true),
                    KkmId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegInfos_Kkms_KkmId",
                        column: x => x.KkmId,
                        principalTable: "Kkms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegInfos_Orgs_OrgId",
                        column: x => x.OrgId,
                        principalTable: "Orgs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    RegInfoId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_RegInfos_RegInfoId",
                        column: x => x.RegInfoId,
                        principalTable: "RegInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Command = table.Column<string>(nullable: true),
                    DeviceId = table.Column<int>(nullable: false),
                    ReqNum = table.Column<int>(nullable: false),
                    Token = table.Column<int>(nullable: false),
                    ServiceId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegInfos_KkmId",
                table: "RegInfos",
                column: "KkmId");

            migrationBuilder.CreateIndex(
                name: "IX_RegInfos_OrgId",
                table: "RegInfos",
                column: "OrgId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ServiceId",
                table: "Requests",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_RegInfoId",
                table: "Services",
                column: "RegInfoId");
            
            
            
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "RegInfos");

            migrationBuilder.DropTable(
                name: "Kkms");

            migrationBuilder.DropTable(
                name: "Orgs");
        }
    }
}
