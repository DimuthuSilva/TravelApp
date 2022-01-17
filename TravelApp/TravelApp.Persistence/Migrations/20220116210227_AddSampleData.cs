using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelApp.Persistence.Migrations
{
    public partial class AddSampleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(table: "TransportTypes", columns: new[] { "Id", "Name", "IsActive" }, values: new object[] {1, "Flight", true });
            migrationBuilder.InsertData(table: "TransportTypes", columns: new[] { "Id", "Name", "IsActive" }, values: new object[] {2, "Train", true });
            migrationBuilder.InsertData(table: "TransportTypes", columns: new[] { "Id", "Name", "IsActive" }, values: new object[] {3, "Ferry", true });

            migrationBuilder.InsertData(table: "TransportTypeDetails", columns: new[] { "Id", "TransportNumber", "IsActive", "TransportTypeId" }, values: new object[] { 1, "FL 101", true,1 });
            migrationBuilder.InsertData(table: "TransportTypeDetails", columns: new[] { "Id", "TransportNumber", "IsActive", "TransportTypeId" }, values: new object[] { 2, "FL 201", true, 1 });
            migrationBuilder.InsertData(table: "TransportTypeDetails", columns: new[] { "Id", "TransportNumber", "IsActive", "TransportTypeId" }, values: new object[] { 3, "TR 302", true, 2 });
            migrationBuilder.InsertData(table: "TransportTypeDetails", columns: new[] { "Id", "TransportNumber", "IsActive", "TransportTypeId" }, values: new object[] { 4, "TR 402", true, 2 });
            migrationBuilder.InsertData(table: "TransportTypeDetails", columns: new[] { "Id", "TransportNumber", "IsActive", "TransportTypeId" }, values: new object[] { 5, "FR 503", true, 3 });
            migrationBuilder.InsertData(table: "TransportTypeDetails", columns: new[] { "Id", "TransportNumber", "IsActive", "TransportTypeId" }, values: new object[] { 6, "FR 603", true, 3 });

            migrationBuilder.InsertData(table: "FareDetails", columns: new[] { "Id", "FareDate", "Fare", "IsActive", "TransportTypeDetailsId", "Destination", "Source" }, values: new object[] { 1, "2022-01-17", "500", true, 1, "France", "UK" });
            migrationBuilder.InsertData(table: "FareDetails", columns: new[] { "Id", "FareDate", "Fare", "IsActive", "TransportTypeDetailsId", "Destination", "Source" }, values: new object[] { 2, "2022-01-17", "550", true, 2, "France", "UK" });
            migrationBuilder.InsertData(table: "FareDetails", columns: new[] { "Id", "FareDate", "Fare", "IsActive", "TransportTypeDetailsId", "Destination", "Source" }, values: new object[] { 3, "2022-01-17", "300", true, 3, "France", "UK" });
            migrationBuilder.InsertData(table: "FareDetails", columns: new[] { "Id", "FareDate", "Fare", "IsActive", "TransportTypeDetailsId", "Destination", "Source" }, values: new object[] { 4, "2022-01-17", "330", true, 4, "France", "UK" });
            migrationBuilder.InsertData(table: "FareDetails", columns: new[] { "Id", "FareDate", "Fare", "IsActive", "TransportTypeDetailsId", "Destination", "Source" }, values: new object[] { 5, "2022-01-17", "200", true, 5, "France", "UK" });
            migrationBuilder.InsertData(table: "FareDetails", columns: new[] { "Id", "FareDate", "Fare", "IsActive", "TransportTypeDetailsId", "Destination", "Source" }, values: new object[] { 6, "2022-01-17", "220", true, 6, "France", "UK" });

            migrationBuilder.InsertData(table: "TravelDetails", columns: new[] { "Id", "DepartureTime", "ArrivalTime", "DepartureTerminal", "ArrivalTerminal", "FareDetailsId" }, values: new object[] { 1, "2022-01-17 11:00", "2022-01-17 12:00", "Terminal 1", "Terminal 2", 1 });
            migrationBuilder.InsertData(table: "TravelDetails", columns: new[] { "Id", "DepartureTime", "ArrivalTime", "DepartureTerminal", "ArrivalTerminal", "FareDetailsId" }, values: new object[] { 2, "2022-01-17 17:00", "2022-01-17 18:00", "Terminal 2", "Terminal 2", 2 });
            migrationBuilder.InsertData(table: "TravelDetails", columns: new[] { "Id", "DepartureTime", "ArrivalTime", "DepartureTerminal", "ArrivalTerminal", "FareDetailsId" }, values: new object[] { 3, "2022-01-17 10:00", "2022-01-17 12:00", "Line 1", "Line 2", 3 });
            migrationBuilder.InsertData(table: "TravelDetails", columns: new[] { "Id", "DepartureTime", "ArrivalTime", "DepartureTerminal", "ArrivalTerminal", "FareDetailsId" }, values: new object[] { 4, "2022-01-17 13:00", "2022-01-17 15:00", "Line 1", "Line 4", 4 });
            migrationBuilder.InsertData(table: "TravelDetails", columns: new[] { "Id", "DepartureTime", "ArrivalTime", "DepartureTerminal", "ArrivalTerminal", "FareDetailsId" }, values: new object[] { 5, "2022-01-17 10:00", "2022-01-17 12:00", "Bay 1", "Bay 2", 5 });
            migrationBuilder.InsertData(table: "TravelDetails", columns: new[] { "Id", "DepartureTime", "ArrivalTime", "DepartureTerminal", "ArrivalTerminal", "FareDetailsId" }, values: new object[] { 6, "2022-01-17 18:00", "2022-01-17 20:00", "Bay 9", "Bay 21", 6 });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
            @"
                TRUNCATE TABLE TravelDetails
                TRUNCATE TABLE FareDetails
                TRUNCATE TABLE TransportTypeDetails
                TRUNCATE TABLE TransportTypes
            
            ");
        }
    }
}
