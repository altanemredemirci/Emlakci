using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emlakci.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AgencyProductRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgencyId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_AgencyId",
                table: "Products",
                column: "AgencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Agencies_AgencyId",
                table: "Products",
                column: "AgencyId",
                principalTable: "Agencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Agencies_AgencyId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_AgencyId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AgencyId",
                table: "Products");
        }
    }
}
