using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Theatre_App.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d1c1c31e-1234-4fae-8c1c-abcdef123456"));

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Catalogue_Id", "Description", "ImgUrl", "Name", "Price", "Quantity", "inStock" },
                values: new object[] { new Guid("d1c2c31e-1234-4fae-8c1c-abcdef123456"), 2, "7aga bt3wr", "url", "Swords", 100m, 9, true });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "EndDate", "IsApproved", "IsPaid", "StartDate", "User_Id" },
                values: new object[,]
                {
                    { new Guid("d1c1c31e-1351-4fae-8c1c-abcdef123456"), new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d1c1c31e-1234-4fae-8c1c-abcdef123456") },
                    { new Guid("d1c1c99e-1351-4fae-8c1c-abcdef123456"), new DateTime(2025, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(2025, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d1c1c31e-1234-4fae-8c1c-abcdef123456") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d1c2c31e-1234-4fae-8c1c-abcdef123456"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("d1c1c31e-1351-4fae-8c1c-abcdef123456"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("d1c1c99e-1351-4fae-8c1c-abcdef123456"));

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Catalogue_Id", "Description", "ImgUrl", "Name", "Price", "Quantity", "inStock" },
                values: new object[] { new Guid("d1c1c31e-1234-4fae-8c1c-abcdef123456"), 2, "7aga bt3wr", "url", "Swords", 100m, 9, true });
        }
    }
}
