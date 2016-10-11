using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Bujetto.webapi.BujettoDB;

namespace Bujetto.webapi.Migrations
{
    [DbContext(typeof(BujettoDbContext))]
    [Migration("20161010171849_budget-startdate")]
    partial class budgetstartdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("Bujetto.webapi.BujettoDB.Models.Budget", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("creationdate");

                    b.Property<DateTime?>("expirationdate");

                    b.Property<string>("name");

                    b.Property<DateTime?>("startdate");

                    b.Property<int>("userid");

                    b.Property<decimal>("value");

                    b.HasKey("id");

                    b.HasIndex("userid");

                    b.ToTable("budget");
                });

            modelBuilder.Entity("Bujetto.webapi.BujettoDB.Models.BudgetToCategory", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("budgetid");

                    b.Property<int>("categoryid");

                    b.HasKey("id");

                    b.HasIndex("budgetid");

                    b.HasIndex("categoryid");

                    b.ToTable("budgets_categories_m2m");
                });

            modelBuilder.Entity("Bujetto.webapi.BujettoDB.Models.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("name");

                    b.HasKey("id");

                    b.ToTable("expense_category");
                });

            modelBuilder.Entity("Bujetto.webapi.BujettoDB.Models.Expense", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("budgetid");

                    b.Property<int>("categoryid");

                    b.Property<DateTime?>("date");

                    b.Property<string>("description");

                    b.Property<decimal>("value");

                    b.HasKey("id");

                    b.HasIndex("budgetid");

                    b.HasIndex("categoryid");

                    b.ToTable("expense");
                });

            modelBuilder.Entity("Bujetto.webapi.BujettoDB.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("name");

                    b.HasKey("id");

                    b.ToTable("user");
                });

            modelBuilder.Entity("Bujetto.webapi.BujettoDB.Models.Budget", b =>
                {
                    b.HasOne("Bujetto.webapi.BujettoDB.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("userid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bujetto.webapi.BujettoDB.Models.BudgetToCategory", b =>
                {
                    b.HasOne("Bujetto.webapi.BujettoDB.Models.Budget", "budget")
                        .WithMany()
                        .HasForeignKey("budgetid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Bujetto.webapi.BujettoDB.Models.Category", "category")
                        .WithMany()
                        .HasForeignKey("categoryid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bujetto.webapi.BujettoDB.Models.Expense", b =>
                {
                    b.HasOne("Bujetto.webapi.BujettoDB.Models.Budget")
                        .WithMany("expenses")
                        .HasForeignKey("budgetid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Bujetto.webapi.BujettoDB.Models.Category", "category")
                        .WithMany()
                        .HasForeignKey("categoryid")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
