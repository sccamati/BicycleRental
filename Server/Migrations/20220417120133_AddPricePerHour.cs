using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BicycleRental.Server.Migrations
{
    public partial class AddPricePerHour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PricePerHour",
                table: "Bikes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PricePerHour",
                table: "Bikes");
        }
    }
}
