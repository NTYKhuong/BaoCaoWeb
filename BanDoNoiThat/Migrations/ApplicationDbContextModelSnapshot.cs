﻿// <auto-generated />
using System;
using BanDoNoiThat.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BanDoNoiThat.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BanDoNoiThat.Models.Account", b =>
                {
                    b.Property<int>("account_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("account_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("account_id"));

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("role_id")
                        .HasColumnType("int");

                    b.HasKey("account_id");

                    b.HasIndex("role_id");

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("BanDoNoiThat.Models.Category", b =>
                {
                    b.Property<int>("category_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("category_id"));

                    b.Property<string>("category_name")
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customer_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone_number")
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("image_path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("inventory_quantity")
                        .HasColumnType("int");

                    b.Property<double?>("original_price")
                        .HasColumnType("float");

                    b.Property<string>("product_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("unit_price")
                        .HasColumnType("float");

                    b.Property<DateTime?>("update_time")
                        .HasColumnType("datetime2");

                    b.HasKey("product_id");

                    b.HasIndex("category_id");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("BanDoNoiThat.Models.Role", b =>
                {
                    b.Property<int>("role_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("role_id"));

                    b.Property<string>("roleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("role_id");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BanDoNoiThat.Models.Account", b =>
                {
                    b.HasOne("BanDoNoiThat.Models.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("role_id");

                    b.Navigation("Role");
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

            modelBuilder.Entity("BanDoNoiThat.Models.Role", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
