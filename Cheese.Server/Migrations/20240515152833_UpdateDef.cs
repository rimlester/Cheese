using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cheese.Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDef : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Cheeses",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Cheeses");
        }
    }
}
