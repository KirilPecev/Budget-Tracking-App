using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetBuddy.Infrastructure.Common.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FkNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetExpenseTypesLimits_ExpenseTypes_TypeName",
                table: "BudgetExpenseTypesLimits");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_ExpenseTypes_ExpenseTypeId",
                table: "Expenses");

            migrationBuilder.RenameColumn(
                name: "ExpenseTypeId",
                table: "Expenses",
                newName: "ExpenseType");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_ExpenseTypeId",
                table: "Expenses",
                newName: "IX_Expenses_ExpenseType");

            migrationBuilder.RenameColumn(
                name: "TypeName",
                table: "BudgetExpenseTypesLimits",
                newName: "ExpenseType");

            migrationBuilder.RenameIndex(
                name: "IX_BudgetExpenseTypesLimits_TypeName",
                table: "BudgetExpenseTypesLimits",
                newName: "IX_BudgetExpenseTypesLimits_ExpenseType");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetExpenseTypesLimits_ExpenseTypes_ExpenseType",
                table: "BudgetExpenseTypesLimits",
                column: "ExpenseType",
                principalTable: "ExpenseTypes",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ExpenseTypes_ExpenseType",
                table: "Expenses",
                column: "ExpenseType",
                principalTable: "ExpenseTypes",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetExpenseTypesLimits_ExpenseTypes_ExpenseType",
                table: "BudgetExpenseTypesLimits");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_ExpenseTypes_ExpenseType",
                table: "Expenses");

            migrationBuilder.RenameColumn(
                name: "ExpenseType",
                table: "Expenses",
                newName: "ExpenseTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_ExpenseType",
                table: "Expenses",
                newName: "IX_Expenses_ExpenseTypeId");

            migrationBuilder.RenameColumn(
                name: "ExpenseType",
                table: "BudgetExpenseTypesLimits",
                newName: "TypeName");

            migrationBuilder.RenameIndex(
                name: "IX_BudgetExpenseTypesLimits_ExpenseType",
                table: "BudgetExpenseTypesLimits",
                newName: "IX_BudgetExpenseTypesLimits_TypeName");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetExpenseTypesLimits_ExpenseTypes_TypeName",
                table: "BudgetExpenseTypesLimits",
                column: "TypeName",
                principalTable: "ExpenseTypes",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ExpenseTypes_ExpenseTypeId",
                table: "Expenses",
                column: "ExpenseTypeId",
                principalTable: "ExpenseTypes",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
