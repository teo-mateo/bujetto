using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bujetto.webapi.Migrations
{
    public partial class x3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_expense_budget_budgetid",
                table: "expense");

            migrationBuilder.DropForeignKey(
                name: "FK_expense_expense_category_categoryid",
                table: "expense");

            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "expense",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "expense",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "categoryid",
                table: "expense",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "budgetid",
                table: "expense",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_expense_budget_budgetid",
                table: "expense",
                column: "budgetid",
                principalTable: "budget",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_expense_expense_category_categoryid",
                table: "expense",
                column: "categoryid",
                principalTable: "expense_category",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_expense_budget_budgetid",
                table: "expense");

            migrationBuilder.DropForeignKey(
                name: "FK_expense_expense_category_categoryid",
                table: "expense");

            migrationBuilder.DropColumn(
                name: "date",
                table: "expense");

            migrationBuilder.DropColumn(
                name: "description",
                table: "expense");

            migrationBuilder.AlterColumn<int>(
                name: "categoryid",
                table: "expense",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "budgetid",
                table: "expense",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_expense_budget_budgetid",
                table: "expense",
                column: "budgetid",
                principalTable: "budget",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_expense_expense_category_categoryid",
                table: "expense",
                column: "categoryid",
                principalTable: "expense_category",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
