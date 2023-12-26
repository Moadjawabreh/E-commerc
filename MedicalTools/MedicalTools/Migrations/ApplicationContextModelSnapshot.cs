﻿// <auto-generated />
using System;
using MedicalTools.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MedicalTools.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MedicalTools.Models.Cart", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("productId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserId");

                    b.HasIndex("productId");

                    b.ToTable("cart");
                });

            modelBuilder.Entity("MedicalTools.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("MedicalTools.Models.FeedbackForProduct", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("productID")
                        .HasColumnType("int");

                    b.Property<int>("userID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("productID");

                    b.HasIndex("userID");

                    b.ToTable("feedbackForProducts");
                });

            modelBuilder.Entity("MedicalTools.Models.FeedbackForWeb", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("userID");

                    b.ToTable("feedbackForWebs");
                });

            modelBuilder.Entity("MedicalTools.Models.Payment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("payments");
                });

            modelBuilder.Entity("MedicalTools.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("UrlImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("categoryID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<double>("percentageOfDiscount")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("categoryID");

                    b.ToTable("products");
                });

            modelBuilder.Entity("MedicalTools.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("locationUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("users");
                });

            modelBuilder.Entity("MedicalTools.Models.Cart", b =>
                {
                    b.HasOne("MedicalTools.Models.User", "User")
                        .WithMany("carts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MedicalTools.Models.Product", "product")
                        .WithMany("carts")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("product");
                });

            modelBuilder.Entity("MedicalTools.Models.FeedbackForProduct", b =>
                {
                    b.HasOne("MedicalTools.Models.Product", "Product")
                        .WithMany("FeedbackForProducts")
                        .HasForeignKey("productID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedicalTools.Models.User", "User")
                        .WithMany("FeedbackForProducts")
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MedicalTools.Models.FeedbackForWeb", b =>
                {
                    b.HasOne("MedicalTools.Models.User", "User")
                        .WithMany("FeedbackForWebs")
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MedicalTools.Models.Product", b =>
                {
                    b.HasOne("MedicalTools.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("categoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MedicalTools.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("MedicalTools.Models.Product", b =>
                {
                    b.Navigation("FeedbackForProducts");

                    b.Navigation("carts");
                });

            modelBuilder.Entity("MedicalTools.Models.User", b =>
                {
                    b.Navigation("FeedbackForProducts");

                    b.Navigation("FeedbackForWebs");

                    b.Navigation("carts");
                });
#pragma warning restore 612, 618
        }
    }
}
