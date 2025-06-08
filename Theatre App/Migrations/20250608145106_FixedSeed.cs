using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Theatre_App.Migrations
{
    /// <inheritdoc />
    public partial class FixedSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d8f4f618-e790-4cbb-b2da-ada376e12799"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "PhoneNumber", "RoleID", "password" },
                values: new object[] { new Guid("d1c1c31e-1234-4fae-8c1c-abcdef123456"), "Marco", 1282771887, 1, "FeKw08M4keuw8e9gnsQZQgwg4yDOlMZfvIwzEkSOsiU=" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d1c1c31e-1234-4fae-8c1c-abcdef123456"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "PhoneNumber", "RoleID", "password" },
                values: new object[] { new Guid("d8f4f618-e790-4cbb-b2da-ada376e12799"), "Marco", 1282771887, 1, "FeKw08M4keuw8e9gnsQZQgwg4yDOlMZfvIwzEkSOsiU=" });
        }
    }
}
