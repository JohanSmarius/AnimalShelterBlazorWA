using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalShelterBlazorWA.Server.Data.Migrations
{
    public partial class ChangeNameOfUrlField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductImage",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "ProductImageUrl",
                table: "Products",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductImageUrl",
                value: "https://nl.m.wikipedia.org/wiki/Bestand:Hundefutter.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProductImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/1/16/Whiskas_cat%27s_petfood_with_chicken_dry.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ProductImageUrl",
                value: "https://www.publicdomainpictures.net/pictures/30000/velka/cat-litter.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductImageUrl",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "ProductImage",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductImage",
                value: "https://nl.m.wikipedia.org/wiki/Bestand:Hundefutter.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProductImage",
                value: "https://upload.wikimedia.org/wikipedia/commons/1/16/Whiskas_cat%27s_petfood_with_chicken_dry.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ProductImage",
                value: "https://www.publicdomainpictures.net/pictures/30000/velka/cat-litter.jpg");
        }
    }
}
