using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GiftWishlist.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Wishlists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: true)
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
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    IsComplete = table.Column<bool>(nullable: false),
                    WishlistID = table.Column<int>(nullable: false),
                    OwnerEmail = table.Column<string>(nullable: true),
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
                columns: new[] { "Id", "DueDate", "Name", "Password" },
                values: new object[] { 1, new DateTime(2020, 12, 9, 10, 36, 35, 990, DateTimeKind.Local).AddTicks(478), "Secret Santa 2020", "" });

            migrationBuilder.InsertData(
                table: "Wishlists",
                columns: new[] { "Id", "DueDate", "Name", "Password" },
                values: new object[] { 2, new DateTime(2020, 5, 14, 13, 0, 2, 0, DateTimeKind.Unspecified), "SSD Completion Party", "ssd" });

            migrationBuilder.InsertData(
                table: "Wishlists",
                columns: new[] { "Id", "DueDate", "Name", "Password" },
                values: new object[] { 3, new DateTime(2020, 12, 9, 10, 36, 35, 993, DateTimeKind.Local).AddTicks(3492), "Secret Santa 2020", "" });

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
