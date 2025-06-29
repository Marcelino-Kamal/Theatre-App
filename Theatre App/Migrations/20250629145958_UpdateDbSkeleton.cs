using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Theatre_App.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDbSkeleton : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Catalogues_CataId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Items_ItemId",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "OrderItems");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "OrderItems",
                newName: "Count");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "OrderItems",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_ItemId",
                table: "OrderItems",
                newName: "IX_OrderItems_ProductId");

            migrationBuilder.RenameColumn(
                name: "Imgurl",
                table: "Items",
                newName: "ImgUrl");

            migrationBuilder.RenameColumn(
                name: "CataId",
                table: "Items",
                newName: "Catalogue_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Items_CataId",
                table: "Items",
                newName: "IX_Items_Catalogue_Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "ImgUrl",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems",
                columns: new[] { "OrderId", "ProductId" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Catalogue_Id", "Description", "ImgUrl", "Name", "Price", "Quantity", "inStock" },
                values: new object[,]
                {
                    { new Guid("d1c2c31e-1234-4fae-8c1c-abcdef123456"), 2, "7aga bt3wr", "url", "Swords", 100m, 9, true },
                    { new Guid("d2c1c31e-1234-4fae-8c1c-abcdef123456"), 2, "7aga 5shb", "url", "Sticks", 100m, 9, true }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "EndDate", "IsApproved", "IsPaid", "StartDate", "User_Id" },
                values: new object[,]
                {
                    { new Guid("d1c1c31e-1351-4fae-8c1c-abcdef123456"), new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d1c1c31e-1234-4fae-8c1c-abcdef123456") },
                    { new Guid("d1c1c99e-1351-4fae-8c1c-abcdef123456"), new DateTime(2025, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(2025, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d1c1c31e-1234-4fae-8c1c-abcdef123456") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Catalogues_Catalogue_Id",
                table: "Items",
                column: "Catalogue_Id",
                principalTable: "Catalogues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Items_ProductId",
                table: "OrderItems",
                column: "ProductId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Catalogues_Catalogue_Id",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Items_ProductId",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItems",
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

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Count",
                table: "OrderItems",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "OrderItems",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                newName: "IX_OrderItems_ItemId");

            migrationBuilder.RenameColumn(
                name: "ImgUrl",
                table: "Items",
                newName: "Imgurl");

            migrationBuilder.RenameColumn(
                name: "Catalogue_Id",
                table: "Items",
                newName: "CataId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_Catalogue_Id",
                table: "Items",
                newName: "IX_Items_CataId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Imgurl",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Catalogues_CataId",
                table: "Items",
                column: "CataId",
                principalTable: "Catalogues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Items_ItemId",
                table: "OrderItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
