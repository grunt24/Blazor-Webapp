using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataStore.SQL.Migrations
{
    /// <inheritdoc />
    public partial class InitialDbSetUp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    BeforeQty = table.Column<int>(type: "int", nullable: false),
                    SoldQty = table.Column<int>(type: "int", nullable: false),
                    CashierName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Beverage", "Fruit" },
                    { 2, "Bakery", "Vegetable" },
                    { 3, "Meat", "Canned Goods" },
                    { 4, "Meat", "Dairy" },
                    { 5, "Meat", "Meat" },
                    { 6, "Meat", "Seafood" },
                    { 7, "Meat", "Condiments" },
                    { 8, "Meat", "Drink" },
                    { 9, "Meat", "Frozenfood" },
                    { 10, "Meat", "Personal Care" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, "Apple", 25.0, 100 },
                    { 2, 1, "Bananas", 120.0, 100 },
                    { 3, 1, "Orange", 39.799999999999997, 100 },
                    { 4, 2, "Potatoes", 50.0, 100 },
                    { 5, 2, "Onions", 100.0, 100 },
                    { 6, 3, "Century Tuna", 32.0, 100 },
                    { 7, 3, "San Marino", 35.0, 100 },
                    { 8, 4, "Butter", 100.0, 100 },
                    { 9, 4, "Egg", 10.0, 100 },
                    { 10, 5, "Pork", 150.0, 100 },
                    { 11, 6, "Shrimp", 500.0, 100 },
                    { 12, 7, "Pepper", 5.0, 100 },
                    { 13, 8, "Vitamilk", 33.0, 100 },
                    { 14, 9, "Hotdog", 85.0, 100 },
                    { 15, 10, "Shampoo", 333.0, 100 },
                    { 16, 10, "Dr.Wong Soap", 52.0, 100 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
