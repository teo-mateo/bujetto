using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bujetto.webapi.Migrations
{
    public partial class x1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_budget_user_userid",
                table: "budget");

            migrationBuilder.AlterColumn<int>(
                name: "userid",
                table: "budget",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_budget_user_userid",
                table: "budget",
                column: "userid",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_budget_user_userid",
                table: "budget");

            migrationBuilder.AlterColumn<int>(
                name: "userid",
                table: "budget",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_budget_user_userid",
                table: "budget",
                column: "userid",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
