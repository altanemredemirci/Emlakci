using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emlakci.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CityId",
                table: "Products",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Cities_CityId",
                table: "Products",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Cities_CityId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CityId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
