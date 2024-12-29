﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Plugins.DataStore.SQL;

#nullable disable

namespace Plugins.DataStore.SQL.Migrations
{
    [DbContext(typeof(InventoryContext))]
    [Migration("20240419153347_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CoreBusiness.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Description = "Modern gadgets for communication and entertainment",
                            Name = "Electronics"
                        },
                        new
                        {
                            CategoryId = 2,
                            Description = "Apparel and accessories for personal style",
                            Name = "Clothing"
                        },
                        new
                        {
                            CategoryId = 3,
                            Description = "Tools for household chores and convenience",
                            Name = "Home Appliances"
                        },
                        new
                        {
                            CategoryId = 4,
                            Description = "Functional pieces for comfortable living spaces",
                            Name = "Furniture"
                        },
                        new
                        {
                            CategoryId = 5,
                            Description = "Everyday food and household essentials",
                            Name = "Groceries"
                        });
                });

            modelBuilder.Entity("CoreBusiness.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int?>("CategoryId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Price")
                        .IsRequired()
                        .HasColumnType("float");

                    b.Property<int?>("Quantity")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 1,
                            Name = "Smartphone",
                            Price = 500.0,
                            Quantity = 50
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 1,
                            Name = "Laptop",
                            Price = 800.0,
                            Quantity = 30
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 2,
                            Name = "T-Shirts",
                            Price = 9.4900000000000002,
                            Quantity = 300
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 2,
                            Name = "Jeans",
                            Price = 19.989999999999998,
                            Quantity = 300
                        },
                        new
                        {
                            ProductId = 5,
                            CategoryId = 3,
                            Name = "Washing Machine",
                            Price = 449.99000000000001,
                            Quantity = 20
                        },
                        new
                        {
                            ProductId = 6,
                            CategoryId = 3,
                            Name = "Fridge",
                            Price = 700.0,
                            Quantity = 30
                        },
                        new
                        {
                            ProductId = 7,
                            CategoryId = 4,
                            Name = "Beds",
                            Price = 600.0,
                            Quantity = 10
                        },
                        new
                        {
                            ProductId = 8,
                            CategoryId = 4,
                            Name = "Bookshelves",
                            Price = 74.989999999999995,
                            Quantity = 15
                        });
                });

            modelBuilder.Entity("CoreBusiness.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionId"));

                    b.Property<int>("BeforeQty")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SellerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoldQty")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("TransactionId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("CoreBusiness.Product", b =>
                {
                    b.HasOne("CoreBusiness.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("CoreBusiness.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}