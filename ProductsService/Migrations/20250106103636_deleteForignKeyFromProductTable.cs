using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsService.Migrations
{
    /// <inheritdoc />
    public partial class deleteForignKeyFromProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductData_CategoryData_Category_Id",
                table: "ProductData");

            migrationBuilder.DropIndex(
                name: "IX_ProductData_Category_Id",
                table: "ProductData");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProductData_Category_Id",
                table: "ProductData",
                column: "Category_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductData_CategoryData_Category_Id",
                table: "ProductData",
                column: "Category_Id",
                principalTable: "CategoryData",
                principalColumn: "Category_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
