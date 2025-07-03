using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Theatre_App.Migrations
{
    /// <inheritdoc />
    public partial class updatedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Items_ProductId",
                table: "OrderItems");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d1c2c31e-1234-4fae-8c1c-abcdef123456"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d2c1c31e-1234-4fae-8c1c-abcdef123456"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("d1c1c31e-1351-4fae-8c1c-abcdef123456"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("d1c1c99e-1351-4fae-8c1c-abcdef123456"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1c1c31e-1234-4fae-8c1c-abcdef123456"));

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "OrderItems",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                newName: "IX_OrderItems_ItemId");

            migrationBuilder.AddColumn<string>(
                name: "Abona_approved",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Payment",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Items_ItemId",
                table: "OrderItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Items_ItemId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "Abona_approved",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Payment",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "OrderItems",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_ItemId",
                table: "OrderItems",
                newName: "IX_OrderItems_ProductId");

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Catalogue_Id", "Description", "ImgUrl", "Name", "Price", "Quantity", "inStock" },
                values: new object[,]
                {
                    { new Guid("d1c2c31e-1234-4fae-8c1c-abcdef123456"), 2, "7aga bt3wr", "url", "Swords", 100m, 9, true },
                    { new Guid("d2c1c31e-1234-4fae-8c1c-abcdef123456"), 2, "7aga 5shb", "url", "Sticks", 100m, 9, true }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Password", "PhoneNumber", "RoleID" },
                values: new object[] { new Guid("d1c1c31e-1234-4fae-8c1c-abcdef123456"), "Marco", "FeKw08M4keuw8e9gnsQZQgwg4yDOlMZfvIwzEkSOsiU=", "01282771887", 1 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "EndDate", "IsApproved", "IsPaid", "StartDate", "User_Id" },
                values: new object[,]
                {
                    { new Guid("d1c1c31e-1351-4fae-8c1c-abcdef123456"), new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d1c1c31e-1234-4fae-8c1c-abcdef123456") },
                    { new Guid("d1c1c99e-1351-4fae-8c1c-abcdef123456"), new DateTime(2025, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(2025, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d1c1c31e-1234-4fae-8c1c-abcdef123456") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Items_ProductId",
                table: "OrderItems",
                column: "ProductId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
