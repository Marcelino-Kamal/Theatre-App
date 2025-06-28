using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Theatre_App.Migrations
{
    /// <inheritdoc />
    public partial class seeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Catalogue_Id", "Description", "ImgUrl", "Name", "Price", "Quantity", "inStock" },
                values: new object[,]
                {
                    { new Guid("d1c1c31e-1234-4fae-8c1c-abcdef123456"), 2, "7aga bt3wr", "url", "Swords", 100m, 9, true },
                    { new Guid("d2c1c31e-1234-4fae-8c1c-abcdef123456"), 2, "7aga 5shb", "url", "Sticks", 100m, 9, true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d1c1c31e-1234-4fae-8c1c-abcdef123456"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("d2c1c31e-1234-4fae-8c1c-abcdef123456"));
        }
    }
}
