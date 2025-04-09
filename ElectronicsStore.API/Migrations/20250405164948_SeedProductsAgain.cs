using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ElectronicsStore.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductsAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageUrl", "Name", "Price", "Rating", "Reviews", "Stock" },
                values: new object[,]
                {
                    { 10, "Laptop", "13-inch, 2023, 8GB RAM, 256GB SSD", "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/mba15-skyblue-select-202503?wid=904&hei=840&fmt=jpeg&qlt=90&.v=1741885366344", "MacBook Air M2", 99999m, 0.0, 0, 0 },
                    { 11, "Laptop", "15.6-inch, Ryzen 7, 16GB RAM", "https://p1-ofp.static.pub/ShareResource/na/products/ideapad/1060x596/lenovo-ideapad-slim-5-16inch-amd-abyss-blue-01.png", "Lenovo IdeaPad Slim 5", 59999m, 0.0, 0, 0 },
                    { 12, "Laptop", "14-inch, i5, 8GB RAM, 512GB SSD", "https://ssl-product-images.www8-hp.com/digmedialib/prodimg/lowres/c08928130.png?imwidth=270&imdensity=1&impolicy=Png_Res", "HP Pavilion x360", 65999m, 0.0, 0, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "ImageUrl", "Name", "Price", "Rating", "Reviews", "Stock" },
                values: new object[,]
                {
                    { 1, "Laptop", "13-inch, 2023, 8GB RAM, 256GB SSD", "https://m.media-amazon.com/images/I/71f5Eu5lJSL._SL1500_.jpg", "MacBook Air M2", 99999m, 0.0, 0, 0 },
                    { 2, "Laptop", "15.6-inch, Ryzen 7, 16GB RAM", "https://m.media-amazon.com/images/I/81TmwvD3M+L._SL1500_.jpg", "Lenovo IdeaPad Slim 5", 59999m, 0.0, 0, 0 },
                    { 3, "Laptop", "14-inch, i5, 8GB RAM, 512GB SSD", "https://m.media-amazon.com/images/I/71fw2xkWQ3L._SL1500_.jpg", "HP Pavilion x360", 65999m, 0.0, 0, 0 }
                });
        }
    }
}
