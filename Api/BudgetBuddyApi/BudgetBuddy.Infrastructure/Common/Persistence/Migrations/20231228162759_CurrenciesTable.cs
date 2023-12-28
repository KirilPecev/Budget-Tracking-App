using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetBuddy.Infrastructure.Common.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CurrenciesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurrencyCode",
                table: "Expenses",
                type: "nvarchar(3)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CurrencyCode",
                table: "Budgets",
                type: "nvarchar(3)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Code);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CurrencyCode",
                table: "Expenses",
                column: "CurrencyCode");

            migrationBuilder.CreateIndex(
                name: "IX_Budgets_CurrencyCode",
                table: "Budgets",
                column: "CurrencyCode");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_Code",
                table: "Currencies",
                column: "Code",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Budgets_Currencies_CurrencyCode",
                table: "Budgets",
                column: "CurrencyCode",
                principalTable: "Currencies",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Currencies_CurrencyCode",
                table: "Expenses",
                column: "CurrencyCode",
                principalTable: "Currencies",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Budgets_Currencies_CurrencyCode",
                table: "Budgets");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Currencies_CurrencyCode",
                table: "Expenses");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_CurrencyCode",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Budgets_CurrencyCode",
                table: "Budgets");

            migrationBuilder.DropColumn(
                name: "CurrencyCode",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "CurrencyCode",
                table: "Budgets");
        }
    }
}
