using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BalanceCoinAPI.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyCategoryId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Incomes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_CategoryId",
                table: "Incomes",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Incomes_Categories_CategoryId",
                table: "Incomes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incomes_Categories_CategoryId",
                table: "Incomes");

            migrationBuilder.DropIndex(
                name: "IX_Incomes_CategoryId",
                table: "Incomes");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Incomes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
