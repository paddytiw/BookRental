using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookRental.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BookRentals_BookId",
                table: "BookRentals");

            migrationBuilder.DropIndex(
                name: "IX_BookRentals_UserId",
                table: "BookRentals");

            migrationBuilder.CreateIndex(
                name: "IX_BookRentals_BookId",
                table: "BookRentals",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookRentals_UserId",
                table: "BookRentals",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BookRentals_BookId",
                table: "BookRentals");

            migrationBuilder.DropIndex(
                name: "IX_BookRentals_UserId",
                table: "BookRentals");

            migrationBuilder.CreateIndex(
                name: "IX_BookRentals_BookId",
                table: "BookRentals",
                column: "BookId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookRentals_UserId",
                table: "BookRentals",
                column: "UserId",
                unique: true);
        }
    }
}
