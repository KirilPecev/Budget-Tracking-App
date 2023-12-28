using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetBuddy.Infrastructure.Common.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ExchangeRatesTableAndBudgetsExpensesRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BudgetId",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ExchangeRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromCurrencyCode = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    ToCurrencyCode = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExchangeRates_Currencies_FromCurrencyCode",
                        column: x => x.FromCurrencyCode,
                        principalTable: "Currencies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExchangeRates_Currencies_ToCurrencyCode",
                        column: x => x.ToCurrencyCode,
                        principalTable: "Currencies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_BudgetId",
                table: "Expenses",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRates_FromCurrencyCode",
                table: "ExchangeRates",
                column: "FromCurrencyCode");

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRates_ToCurrencyCode",
                table: "ExchangeRates",
                column: "ToCurrencyCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Budgets_BudgetId",
                table: "Expenses",
                column: "BudgetId",
                principalTable: "Budgets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Budgets_BudgetId",
                table: "Expenses");

            migrationBuilder.DropTable(
                name: "ExchangeRates");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_BudgetId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "BudgetId",
                table: "Expenses");
        }
    }
}
