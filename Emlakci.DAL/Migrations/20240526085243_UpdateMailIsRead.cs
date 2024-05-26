using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emlakci.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMailIsRead : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "Mails",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "Mails");
        }
    }
}
