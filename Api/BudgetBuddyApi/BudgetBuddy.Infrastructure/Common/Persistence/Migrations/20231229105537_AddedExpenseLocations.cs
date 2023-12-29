using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetBuddy.Infrastructure.Common.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedExpenseLocations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExpenseLocationId",
                table: "Expenses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ExpenseLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseLocations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ExpenseLocationId",
                table: "Expenses",
                column: "ExpenseLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ExpenseLocations_ExpenseLocationId",
                table: "Expenses",
                column: "ExpenseLocationId",
                principalTable: "ExpenseLocations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_ExpenseLocations_ExpenseLocationId",
                table: "Expenses");

            migrationBuilder.DropTable(
                name: "ExpenseLocations");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_ExpenseLocationId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "ExpenseLocationId",
                table: "Expenses");
        }
    }
}
