using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbContext.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexesToRideDataTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IDX_PULocationID",
                table: "RideData",
                column: "PULocationID");

            migrationBuilder.CreateIndex(
                name: "IDX_TravelTime",
                table: "RideData",
                columns: new[] { "TpepPickupDatetime", "TpepDropoffDatetime" });

            migrationBuilder.CreateIndex(
                name: "IDX_TripDistance",
                table: "RideData",
                column: "TripDistance");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IDX_PULocationID",
                table: "RideData");

            migrationBuilder.DropIndex(
                name: "IDX_TravelTime",
                table: "RideData");

            migrationBuilder.DropIndex(
                name: "IDX_TripDistance",
                table: "RideData");
        }
    }
}
