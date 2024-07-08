using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teklican.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixDb11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_LineItems_ProductId",
                table: "LineItems",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_Products_ProductId",
                table: "LineItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Products_ProductId",
                table: "LineItems");

            migrationBuilder.DropIndex(
                name: "IX_LineItems_ProductId",
                table: "LineItems");
        }
    }
}
