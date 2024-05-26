using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emlakci.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductDetailViewCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "ProductDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "ProductDetails");
        }
    }
}
