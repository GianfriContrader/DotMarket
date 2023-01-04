using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotMarket.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Karts_Orders_OrderId",
                table: "Karts");

            migrationBuilder.DropIndex(
                name: "IX_Karts_OrderId",
                table: "Karts");

            migrationBuilder.CreateIndex(
                name: "IX_Karts_OrderId",
                table: "Karts",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Karts_Orders_OrderId",
                table: "Karts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Karts_Orders_OrderId",
                table: "Karts");

            migrationBuilder.DropIndex(
                name: "IX_Karts_OrderId",
                table: "Karts");

            migrationBuilder.CreateIndex(
                name: "IX_Karts_OrderId",
                table: "Karts",
                column: "OrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Karts_Orders_OrderId",
                table: "Karts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
