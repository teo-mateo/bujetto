using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bujetto.webapi.Migrations
{
    public partial class t1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "expense_category",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_expense_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "expense",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    budgetid = table.Column<int>(nullable: true),
                    categoryid = table.Column<int>(nullable: true),
                    value = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_expense", x => x.id);
                    table.ForeignKey(
                        name: "FK_expense_budget_budgetid",
                        column: x => x.budgetid,
                        principalTable: "budget",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_expense_expense_category_categoryid",
                        column: x => x.categoryid,
                        principalTable: "expense_category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_expense_budgetid",
                table: "expense",
                column: "budgetid");

            migrationBuilder.CreateIndex(
                name: "IX_expense_categoryid",
                table: "expense",
                column: "categoryid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "expense");

            migrationBuilder.DropTable(
                name: "expense_category");
        }
    }
}
