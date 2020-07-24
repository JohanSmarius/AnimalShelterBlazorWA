using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalShelterBlazorWA.Server.Data.Migrations
{
    public partial class NewSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/4/4f/Hundefutter.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductImageUrl",
                value: "https://nl.m.wikipedia.org/wiki/Bestand:Hundefutter.jpg");
        }
    }
}
