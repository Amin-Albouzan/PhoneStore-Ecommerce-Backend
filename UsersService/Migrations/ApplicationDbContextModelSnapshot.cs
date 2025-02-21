﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UsersService.Repositories;

#nullable disable

namespace UsersService.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("UsersService.DTO.PaymentView", b =>
                {
                    b.Property<string>("Product_ImageUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Product_Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("User_Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("User_Surname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("payment_Date")
                        .HasColumnType("datetime(6)");

                    b.ToTable((string)null);

                    b.ToView("payment", (string)null);
                });

            modelBuilder.Entity("UsersService.DTO.TotalFollowers", b =>
                {
                    b.Property<int>("totalfollowers")
                        .HasColumnType("int");

                    b.ToTable((string)null);

                    b.ToView("totalfollowers", (string)null);
                });

            modelBuilder.Entity("UsersService.Models.CartData", b =>
                {
                    b.Property<int>("Cart_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Cart_ID"));

                    b.Property<string>("Product_Discription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Product_ID")
                        .HasColumnType("int");

                    b.Property<string>("Product_ImageUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Product_Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Product_Price")
                        .HasColumnType("double");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("User_ID")
                        .HasColumnType("int");

                    b.HasKey("Cart_ID");

                    b.HasIndex("User_ID")
                        .HasDatabaseName("IDX_CartData_UserID_Search");

                    b.ToTable("CartData", (string)null);
                });

            modelBuilder.Entity("UsersService.Models.PaymentData", b =>
                {
                    b.Property<int>("Payment_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Payment_ID"));

                    b.Property<int>("Cart_ID")
                        .HasColumnType("int");

                    b.Property<string>("Product_Discription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Product_ID")
                        .HasColumnType("int");

                    b.Property<string>("Product_ImageUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Product_Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Product_Price")
                        .HasColumnType("double");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("User_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("payment_Date")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Payment_ID");

                    b.ToTable("PaymentData", (string)null);
                });

            modelBuilder.Entity("UsersService.Models.ShoppingListSP", b =>
                {
                    b.Property<int>("Cart_ID")
                        .HasColumnType("int");

                    b.Property<int>("Payment_ID")
                        .HasColumnType("int");

                    b.Property<string>("Product_Discription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Product_ID")
                        .HasColumnType("int");

                    b.Property<string>("Product_ImageUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Product_Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Product_Price")
                        .HasColumnType("double");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("User_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("payment_Date")
                        .HasColumnType("datetime(6)");

                    b.ToTable("ShoppingListSP", (string)null);
                });

            modelBuilder.Entity("UsersService.Models.TotalPrice", b =>
                {
                    b.Property<double>("total_price")
                        .HasColumnType("double");

                    b.ToTable("totalPrice", (string)null);
                });

            modelBuilder.Entity("UsersService.Models.UserData", b =>
                {
                    b.Property<int>("User_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("User_ID"));

                    b.Property<string>("User_Adress")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("User_Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("User_Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("User_Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("User_PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("User_Surname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("User_ID");

                    b.HasIndex("User_Email")
                        .IsUnique();

                    b.ToTable("UserData", null, t =>
                        {
                            t.HasCheckConstraint("CK_UserData_User_PhoneNumber", "User_PhoneNumber REGEXP '^[0-9]{11}$'");
                        });
                });

            modelBuilder.Entity("UsersService.Models.UserDataView", b =>
                {
                    b.Property<string>("User_Adress")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("User_Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("User_ID")
                        .HasColumnType("int");

                    b.Property<string>("User_Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("User_Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("User_PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("User_Surname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.ToTable((string)null);

                    b.ToView("userdatatodashboard", (string)null);
                });

            modelBuilder.Entity("UsersService.Models.cartSummary", b =>
                {
                    b.Property<int>("product_count")
                        .HasColumnType("int");

                    b.ToTable("cartSummary", (string)null);
                });

            modelBuilder.Entity("UsersService.Models.manager", b =>
                {
                    b.Property<int>("manager_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("manager_ID"));

                    b.Property<string>("manager_Adress")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("manager_Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("manager_Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("manager_Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("manager_PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("manager_Surname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("manager_ID");

                    b.HasIndex("manager_Email")
                        .IsUnique();

                    b.ToTable("managerData", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
