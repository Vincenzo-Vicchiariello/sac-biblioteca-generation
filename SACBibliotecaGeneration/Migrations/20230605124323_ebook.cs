using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SACBibliotecaGeneration.Migrations
{
    /// <inheritdoc />
    public partial class ebook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EBook",
                table: "books",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EBook",
                table: "books");
        }
    }
}
