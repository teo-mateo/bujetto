using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bujetto.webapi.Migrations
{
    public partial class BudgetToCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "budgets_categories_m2m",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    budgetid = table.Column<int>(nullable: false),
                    categoryid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_budgets_categories_m2m", x => x.id);
                    table.ForeignKey(
                        name: "FK_budgets_categories_m2m_budget_budgetid",
                        column: x => x.budgetid,
                        principalTable: "budget",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_budgets_categories_m2m_expense_category_categoryid",
                        column: x => x.categoryid,
                        principalTable: "expense_category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_budgets_categories_m2m_budgetid",
                table: "budgets_categories_m2m",
                column: "budgetid");

            migrationBuilder.CreateIndex(
                name: "IX_budgets_categories_m2m_categoryid",
                table: "budgets_categories_m2m",
                column: "categoryid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "budgets_categories_m2m");
        }
    }
}
