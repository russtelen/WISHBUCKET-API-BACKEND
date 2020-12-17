using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GiftWishlist.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Wishlists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: true),
                    OwnerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    IsComplete = table.Column<bool>(nullable: false),
                    WishlistID = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ImageURL = table.Column<string>(nullable: true),
                    PurchaseURL = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Wishlists_WishlistID",
                        column: x => x.WishlistID,
                        principalTable: "Wishlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Wishlists",
                columns: new[] { "Id", "DueDate", "Name", "OwnerId", "Password" },
                values: new object[] { 1, new DateTime(2020, 12, 17, 12, 42, 8, 597, DateTimeKind.Local).AddTicks(7800), "Secret Santa 2020", null, "" });

            migrationBuilder.InsertData(
                table: "Wishlists",
                columns: new[] { "Id", "DueDate", "Name", "OwnerId", "Password" },
                values: new object[] { 2, new DateTime(2020, 5, 14, 13, 0, 2, 0, DateTimeKind.Unspecified), "SSD Completion Party", null, "ssd" });

            migrationBuilder.InsertData(
                table: "Wishlists",
                columns: new[] { "Id", "DueDate", "Name", "OwnerId", "Password" },
                values: new object[] { 3, new DateTime(2020, 12, 17, 12, 42, 8, 601, DateTimeKind.Local).AddTicks(681), "Secret Santa 2020", null, "" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Description", "ImageURL", "IsComplete", "Name", "Price", "PurchaseURL", "WishlistID" },
                values: new object[] { 1, "", "", false, "Socks", 12.00m, "", 1 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Description", "ImageURL", "IsComplete", "Name", "Price", "PurchaseURL", "WishlistID" },
                values: new object[] { 2, "", "", false, "Mug", 10.00m, "", 1 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Description", "ImageURL", "IsComplete", "Name", "Price", "PurchaseURL", "WishlistID" },
                values: new object[] { 3, "", "", false, "Gaming Mouse", 50.00m, "", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Items_WishlistID",
                table: "Items",
                column: "WishlistID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Wishlists");
        }
    }
}
