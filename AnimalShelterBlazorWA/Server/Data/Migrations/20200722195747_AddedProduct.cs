using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalShelterBlazorWA.Server.Data.Migrations
{
    public partial class AddedProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PictureUrl",
                table: "Animals",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    VatPercentage = table.Column<int>(nullable: false),
                    ProductImage = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "ProductImage", "VatPercentage" },
                values: new object[] { 1, "Dogfood", 10.99m, "https://nl.m.wikipedia.org/wiki/Bestand:Hundefutter.jpg", 21 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "ProductImage", "VatPercentage" },
                values: new object[] { 2, "Catfood", 8.99m, "https://upload.wikimedia.org/wikipedia/commons/1/16/Whiskas_cat%27s_petfood_with_chicken_dry.jpg", 21 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "ProductImage", "VatPercentage" },
                values: new object[] { 3, "Cat litter 50 liter", 15.12m, "https://www.publicdomainpictures.net/pictures/30000/velka/cat-litter.jpg", 21 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "PictureUrl",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
