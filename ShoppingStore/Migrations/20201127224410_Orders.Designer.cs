﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ShoppingStore.Models;

namespace ShoppingStore.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    [Migration("20201127224410_Orders")]
    partial class Orders
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("ShoppingStore.Models.CartLine", b =>
                {
                    b.Property<int>("CartLineID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("OrderID")
                        .HasColumnType("integer");

                    b.Property<long?>("ProductID")
                        .HasColumnType("bigint");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("CartLineID");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductID");

                    b.ToTable("CartLine");
                });

            modelBuilder.Entity("ShoppingStore.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("GiftWrap")
                        .HasColumnType("boolean");

                    b.Property<string>("Line1")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Line2")
                        .HasColumnType("text");

                    b.Property<string>("Line3")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Zip")
                        .HasColumnType("text");

                    b.HasKey("OrderID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ShoppingStore.Models.Product", b =>
                {
                    b.Property<long>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Category")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(8, 2)");

                    b.HasKey("ProductID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ShoppingStore.Models.CartLine", b =>
                {
                    b.HasOne("ShoppingStore.Models.Order", null)
                        .WithMany("Lines")
                        .HasForeignKey("OrderID");

                    b.HasOne("ShoppingStore.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID");
                });
#pragma warning restore 612, 618
        }
    }
}