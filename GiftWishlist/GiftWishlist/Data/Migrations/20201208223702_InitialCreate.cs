using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GiftWishlist.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WishlistId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IsComplete = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ImageURL = table.Column<string>(nullable: true),
                    PurchaseURL = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wishlists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlists", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Wishlists",
                columns: new[] { "Id", "DueDate", "Name", "Password" },
                values: new object[] { 1, new DateTime(2020, 12, 8, 14, 37, 2, 519, DateTimeKind.Local).AddTicks(4929), "Secret Santa 2020", "" });

            migrationBuilder.InsertData(
                table: "Wishlists",
                columns: new[] { "Id", "DueDate", "Name", "Password" },
                values: new object[] { 2, new DateTime(2020, 5, 14, 13, 0, 2, 0, DateTimeKind.Unspecified), "SSD Completion Party", "ssd" });

            migrationBuilder.InsertData(
                table: "Wishlists",
                columns: new[] { "Id", "DueDate", "Name", "Password" },
                values: new object[] { 3, new DateTime(2020, 12, 8, 14, 37, 2, 523, DateTimeKind.Local).AddTicks(855), "Secret Santa 2020", "" });
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
