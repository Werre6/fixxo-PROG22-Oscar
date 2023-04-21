using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class DataDBTableChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryEntity",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_ProductEntity",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductEntity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductEntity",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CategoryEntity",
                table: "Products",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryEntity",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Products",
                newName: "CategoryEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                newName: "IX_Products_CategoryEntity");

            migrationBuilder.AddColumn<int>(
                name: "ProductEntity",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductEntity",
                table: "Products",
                column: "ProductEntity");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryEntity",
                table: "Products",
                column: "CategoryEntity",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_ProductEntity",
                table: "Products",
                column: "ProductEntity",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
