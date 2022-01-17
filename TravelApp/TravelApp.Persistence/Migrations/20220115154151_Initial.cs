using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelApp.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransportTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransportTypeDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransportNumber = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    TransportTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportTypeDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransportTypeDetails_TransportTypes_TransportTypeId",
                        column: x => x.TransportTypeId,
                        principalTable: "TransportTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FareDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FareDate = table.Column<DateTime>(nullable: false),
                    Fare = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    TransportTypeDetailsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FareDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FareDetails_TransportTypeDetails_TransportTypeDetailsId",
                        column: x => x.TransportTypeDetailsId,
                        principalTable: "TransportTypeDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TravelDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartureTime = table.Column<DateTime>(nullable: false),
                    ArrivalTime = table.Column<DateTime>(nullable: false),
                    DepartureTerminal = table.Column<string>(nullable: true),
                    ArrivalTerminal = table.Column<string>(nullable: true),
                    FareDetailsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TravelDetails_FareDetails_FareDetailsId",
                        column: x => x.FareDetailsId,
                        principalTable: "FareDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FareDetails_TransportTypeDetailsId",
                table: "FareDetails",
                column: "TransportTypeDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportTypeDetails_TransportTypeId",
                table: "TransportTypeDetails",
                column: "TransportTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelDetails_FareDetailsId",
                table: "TravelDetails",
                column: "FareDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TravelDetails");

            migrationBuilder.DropTable(
                name: "FareDetails");

            migrationBuilder.DropTable(
                name: "TransportTypeDetails");

            migrationBuilder.DropTable(
                name: "TransportTypes");
        }
    }
}
