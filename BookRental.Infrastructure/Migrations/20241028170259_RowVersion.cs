using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookRental.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RowVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "BookRentals",
                type: "rowversion",
                rowVersion: true,
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_BookRentals_Books_BookId",
                table: "BookRentals",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookRentals_Users_UserId",
                table: "BookRentals",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookRentals_Books_BookId",
                table: "BookRentals");

            migrationBuilder.DropForeignKey(
                name: "FK_BookRentals_Users_UserId",
                table: "BookRentals");

            migrationBuilder.DropIndex(
                name: "IX_BookRentals_BookId",
                table: "BookRentals");

            migrationBuilder.DropIndex(
                name: "IX_BookRentals_UserId",
                table: "BookRentals");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "BookRentals");
        }
    }
}
