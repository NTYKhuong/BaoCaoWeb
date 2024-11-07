﻿// <auto-generated />
using System;
using BanDoNoiThat.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BanDoNoiThat.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241105020925_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BanDoNoiThat.Models.Category", b =>
                {
                    b.Property<int>("category_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("category_id"));

                    b.Property<string>("category_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("category_id");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("BanDoNoiThat.Models.Customers", b =>
                {
                    b.Property<int>("customer_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("customer_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("customer_id"));

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customer_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("customer_id");

                    b.ToTable("Customers", (string)null);
                });

            modelBuilder.Entity("BanDoNoiThat.Models.OrderDetails", b =>
                {
                    b.Property<int>("detail_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("detail_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("detail_id"));

                    b.Property<int>("order_id")
                        .HasColumnType("int");

                    b.Property<int>("product_id")
                        .HasColumnType("int");

                    b.Property<double?>("sale_price")
                        .HasColumnType("float");

                    b.Property<int?>("total_quantity")
                        .HasColumnType("int");

                    b.HasKey("detail_id");

                    b.HasIndex("order_id");

                    b.HasIndex("product_id");

                    b.ToTable("OrderDetails", (string)null);
                });

            modelBuilder.Entity("BanDoNoiThat.Models.Orders", b =>
                {
                    b.Property<int>("order_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("order_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("order_id"));

                    b.Property<int>("customer_id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("order_date")
                        .HasColumnType("datetime2");

                    b.Property<double?>("total_price")
                        .HasColumnType("float");

                    b.HasKey("order_id");

                    b.HasIndex("customer_id");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("BanDoNoiThat.Models.Products", b =>
                {
                    b.Property<int>("product_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("product_id"));

                    b.Property<int>("category_id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("create_time")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("image_path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("inventory_quantity")
                        .HasColumnType("int");

                    b.Property<double?>("original_price")
                        .HasColumnType("float");

                    b.Property<string>("product_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("unit_price")
                        .HasColumnType("float");

                    b.Property<DateTime?>("update_time")
                        .HasColumnType("datetime2");

                    b.HasKey("product_id");

                    b.HasIndex("category_id");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("BanDoNoiThat.Models.OrderDetails", b =>
                {
                    b.HasOne("BanDoNoiThat.Models.Orders", "Orders")
                        .WithMany("Order_details")
                        .HasForeignKey("order_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BanDoNoiThat.Models.Products", "Products")
                        .WithMany("Order_details")
                        .HasForeignKey("product_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orders");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("BanDoNoiThat.Models.Orders", b =>
                {
                    b.HasOne("BanDoNoiThat.Models.Customers", "Customers")
                        .WithMany("Orders")
                        .HasForeignKey("customer_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customers");
                });

            modelBuilder.Entity("BanDoNoiThat.Models.Products", b =>
                {
                    b.HasOne("BanDoNoiThat.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("category_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BanDoNoiThat.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("BanDoNoiThat.Models.Customers", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("BanDoNoiThat.Models.Orders", b =>
                {
                    b.Navigation("Order_details");
                });

            modelBuilder.Entity("BanDoNoiThat.Models.Products", b =>
                {
                    b.Navigation("Order_details");
                });
#pragma warning restore 612, 618
        }
    }
}
