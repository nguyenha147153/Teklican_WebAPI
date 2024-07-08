using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teklican.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixDb10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "LineItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "SubTotal",
                table: "LineItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "LineItems");

            migrationBuilder.DropColumn(
                name: "SubTotal",
                table: "LineItems");
        }
    }
}
