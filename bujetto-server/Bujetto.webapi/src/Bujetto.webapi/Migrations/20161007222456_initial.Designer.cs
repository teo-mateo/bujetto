﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Bujetto.webapi.BujettoDB;

namespace Bujetto.webapi.Migrations
{
    [DbContext(typeof(BujettoDbContext))]
    [Migration("20161007222456_initial")]
    partial class initial
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

                    b.Property<int?>("userid");

                    b.Property<decimal>("value");

                    b.HasKey("id");

                    b.HasIndex("userid");

                    b.ToTable("budget");
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
                        .HasForeignKey("userid");
                });
        }
    }
}
