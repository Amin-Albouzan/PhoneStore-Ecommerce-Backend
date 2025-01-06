using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsService.Migrations
{
    /// <inheritdoc />
    public partial class AddFKeyToProductFromCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddForeignKey(
                name: "FK_ProductData_CategoryData_Category_Id",
                table: "ProductData",
                column: "Category_Id",
                principalTable: "CategoryData",
                principalColumn: "Category_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductData_CategoryData_Category_Id",
                table: "ProductData");

            migrationBuilder.DropIndex(
                name: "IX_ProductData_Category_Id",
                table: "ProductData");
        }
    }
}
