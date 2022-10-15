using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CartApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    CartId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => new { x.CartId, x.ItemId });
                });

            migrationBuilder.CreateTable(
                name: "CartItemDALItemDAL",
                columns: table => new
                {
                    ItemDALItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    CartItemDALCartId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CartItemDALItemId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItemDALItemDAL", x => new { x.ItemDALItemId, x.CartItemDALCartId, x.CartItemDALItemId });
                    table.ForeignKey(
                        name: "FK_CartItemDALItemDAL_Items_ItemDALItemId",
                        column: x => x.ItemDALItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItemDALItemDAL_ShoppingCartItems_CartItemDALCartId_CartItemDALItemId",
                        columns: x => new { x.CartItemDALCartId, x.CartItemDALItemId },
                        principalTable: "ShoppingCartItems",
                        principalColumns: new[] { "CartId", "ItemId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "ImageUrl", "Name", "Price" },
                values: new object[] { 1, "https://picsum.photos/200/300", "iPhone 12", 50000m });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "ImageUrl", "Name", "Price" },
                values: new object[] { 2, "https://picsum.photos/200/300", "HP Laptop", 50000m });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "ImageUrl", "Name", "Price" },
                values: new object[] { 3, "https://picsum.photos/200/300", "Samsung S22 Ultra", 84000m });

            migrationBuilder.CreateIndex(
                name: "IX_CartItemDALItemDAL_CartItemDALCartId_CartItemDALItemId",
                table: "CartItemDALItemDAL",
                columns: new[] { "CartItemDALCartId", "CartItemDALItemId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItemDALItemDAL");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "ShoppingCartItems");
        }
    }
}
