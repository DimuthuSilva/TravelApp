using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelApp.Persistence.Migrations
{
    public partial class AddedSourceAndDestinationAddresses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "FareDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "FareDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Destination",
                table: "FareDetails");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "FareDetails");
        }
    }
}
