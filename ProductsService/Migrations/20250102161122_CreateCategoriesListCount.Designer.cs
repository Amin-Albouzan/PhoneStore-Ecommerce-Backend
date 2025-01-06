﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductsService.Repositories;

#nullable disable

namespace ProductsService.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250102161122_CreateCategoriesListCount")]
    partial class CreateCategoriesListCount
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("ProductsService.DTO.CategoriesListCount", b =>
                {
                    b.Property<int>("CategoriesCount")
                        .HasColumnType("int");

                    b.ToTable((string)null);

                    b.ToView("categorieslistcount", (string)null);
                });

            modelBuilder.Entity("ProductsService.DTO.categoryView", b =>
                {
                    b.Property<int>("Category_ID")
                        .HasColumnType("int");

                    b.Property<string>("Category_Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.ToTable((string)null);

                    b.ToView("categorieslist", (string)null);
                });

            modelBuilder.Entity("ProductsService.Models.Category", b =>
                {
                    b.Property<int>("Category_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Category_ID"));

                    b.Property<string>("Category_Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Category_ID");

                    b.HasIndex("Category_Name")
                        .IsUnique();

                    b.ToTable("CategoryData");
                });

            modelBuilder.Entity("ProductsService.Models.Product", b =>
                {
                    b.Property<int>("Product_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Product_ID"));

                    b.Property<int>("Category_Id")
                        .HasColumnType("int");

                    b.Property<string>("Product_Discription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Product_ImageUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Product_Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<double>("Product_Price")
                        .HasColumnType("double");

                    b.HasKey("Product_ID");

                    b.HasIndex("Product_Name")
                        .IsUnique();

                    b.ToTable("ProductData");
                });
#pragma warning restore 612, 618
        }
    }
}
