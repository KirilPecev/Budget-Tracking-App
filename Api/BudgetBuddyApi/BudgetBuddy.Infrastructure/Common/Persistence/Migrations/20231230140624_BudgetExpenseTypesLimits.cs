using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetBuddy.Infrastructure.Common.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class BudgetExpenseTypesLimits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetSharing_Budgets_BudgetId",
                table: "BudgetSharing");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseAttachments_Expenses_ExpenseId",
                table: "ExpenseAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_ExpenseLocations_ExpenseLocationId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_ExpenseTypes_ExpenseTypeId",
                table: "Expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpenseTypes",
                table: "ExpenseTypes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ExpenseTypes");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "ExpenseTypes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "AmountType",
                table: "ExpenseTypes",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CurrencyCode",
                table: "ExpenseTypes",
                type: "nvarchar(3)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ExpenseTypeId",
                table: "Expenses",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpenseTypes",
                table: "ExpenseTypes",
                column: "Name");

            migrationBuilder.CreateTable(
                name: "BudgetExpenseTypesLimits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BudgetId = table.Column<int>(type: "int", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    AmountType = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetExpenseTypesLimits", x => x.Id);
                    table.CheckConstraint("CK_BudgetExpenseTypesLimits_AmountType", "AmountType in ('V', 'P')");
                    table.ForeignKey(
                        name: "FK_BudgetExpenseTypesLimits_Budgets_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BudgetExpenseTypesLimits_Currencies_CurrencyCode",
                        column: x => x.CurrencyCode,
                        principalTable: "Currencies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BudgetExpenseTypesLimits_ExpenseTypes_TypeName",
                        column: x => x.TypeName,
                        principalTable: "ExpenseTypes",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseTypes_CurrencyCode",
                table: "ExpenseTypes",
                column: "CurrencyCode");

            migrationBuilder.AddCheckConstraint(
                name: "CK_ExpenseTypes_AmountType",
                table: "ExpenseTypes",
                sql: "AmountType in ('V', 'P')");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetExpenseTypesLimits_BudgetId",
                table: "BudgetExpenseTypesLimits",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetExpenseTypesLimits_CurrencyCode",
                table: "BudgetExpenseTypesLimits",
                column: "CurrencyCode");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetExpenseTypesLimits_TypeName",
                table: "BudgetExpenseTypesLimits",
                column: "TypeName");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetSharing_Budgets_BudgetId",
                table: "BudgetSharing",
                column: "BudgetId",
                principalTable: "Budgets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseAttachments_Expenses_ExpenseId",
                table: "ExpenseAttachments",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ExpenseLocations_ExpenseLocationId",
                table: "Expenses",
                column: "ExpenseLocationId",
                principalTable: "ExpenseLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ExpenseTypes_ExpenseTypeId",
                table: "Expenses",
                column: "ExpenseTypeId",
                principalTable: "ExpenseTypes",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseTypes_Currencies_CurrencyCode",
                table: "ExpenseTypes",
                column: "CurrencyCode",
                principalTable: "Currencies",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BudgetSharing_Budgets_BudgetId",
                table: "BudgetSharing");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseAttachments_Expenses_ExpenseId",
                table: "ExpenseAttachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_ExpenseLocations_ExpenseLocationId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_ExpenseTypes_ExpenseTypeId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseTypes_Currencies_CurrencyCode",
                table: "ExpenseTypes");

            migrationBuilder.DropTable(
                name: "BudgetExpenseTypesLimits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpenseTypes",
                table: "ExpenseTypes");

            migrationBuilder.DropIndex(
                name: "IX_ExpenseTypes_CurrencyCode",
                table: "ExpenseTypes");

            migrationBuilder.DropCheckConstraint(
                name: "CK_ExpenseTypes_AmountType",
                table: "ExpenseTypes");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "ExpenseTypes");

            migrationBuilder.DropColumn(
                name: "AmountType",
                table: "ExpenseTypes");

            migrationBuilder.DropColumn(
                name: "CurrencyCode",
                table: "ExpenseTypes");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ExpenseTypes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ExpenseTypeId",
                table: "Expenses",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpenseTypes",
                table: "ExpenseTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BudgetSharing_Budgets_BudgetId",
                table: "BudgetSharing",
                column: "BudgetId",
                principalTable: "Budgets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseAttachments_Expenses_ExpenseId",
                table: "ExpenseAttachments",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ExpenseLocations_ExpenseLocationId",
                table: "Expenses",
                column: "ExpenseLocationId",
                principalTable: "ExpenseLocations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ExpenseTypes_ExpenseTypeId",
                table: "Expenses",
                column: "ExpenseTypeId",
                principalTable: "ExpenseTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
