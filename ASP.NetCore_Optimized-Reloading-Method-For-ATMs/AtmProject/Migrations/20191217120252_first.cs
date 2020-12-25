using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtmProject.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atms",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    TID = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atms", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HistoricData",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    TID = table.Column<string>(nullable: true),
                    EventDate = table.Column<DateTime>(nullable: false),
                    PreviousPeriodID = table.Column<int>(nullable: false),
                    PreviousLoad = table.Column<DateTime>(nullable: false),
                    PreviousDeposit = table.Column<int>(nullable: false),
                    PreviousWithdraw = table.Column<int>(nullable: false),
                    PreviousTransactionCount = table.Column<int>(nullable: false),
                    PeriodID = table.Column<int>(nullable: false),
                    LoadDate = table.Column<DateTime>(nullable: false),
                    Deposit = table.Column<int>(nullable: false),
                    Withdraw = table.Column<int>(nullable: false),
                    TransactionCount = table.Column<int>(nullable: false),
                    AtmId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricData", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HistoricData_Atms_AtmId",
                        column: x => x.AtmId,
                        principalTable: "Atms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    LoadingAndCounting = table.Column<double>(nullable: false),
                    Transport = table.Column<double>(nullable: false),
                    Risk = table.Column<double>(nullable: false),
                    AlternativePrice = table.Column<double>(nullable: false),
                    AtmId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Prices_Atms_AtmId",
                        column: x => x.AtmId,
                        principalTable: "Atms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoricData_AtmId",
                table: "HistoricData",
                column: "AtmId");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_AtmId",
                table: "Prices",
                column: "AtmId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricData");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "Atms");
        }
    }
}
