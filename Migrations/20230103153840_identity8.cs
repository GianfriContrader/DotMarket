using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotMarket.Migrations
{
    /// <inheritdoc />
    public partial class identity8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Payments_Id",
                table: "Payments",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Id",
                table: "Orders",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Payments_Id",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Orders_Id",
                table: "Orders");
        }
    }
}
