﻿// <auto-generated />
using System;
using Food_Order_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Food_Order_System.Migrations
{
    [DbContext(typeof(ProjectContext))]
    [Migration("20241030100548_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Food_Order_System.Models.Category", b =>
                {
                    b.Property<int>("Category_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Category_ID"));

                    b.Property<string>("Category_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Category_ID");

                    b.ToTable("TblCategory");

                    b.HasData(
                        new
                        {
                            Category_ID = 1,
                            Category_Name = "Veg"
                        },
                        new
                        {
                            Category_ID = 2,
                            Category_Name = "Non-Veg"
                        });
                });

            modelBuilder.Entity("Food_Order_System.Models.Item", b =>
                {
                    b.Property<int>("Item_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Item_ID"));

                    b.Property<int?>("Category_ID")
                        .HasColumnType("int");

                    b.Property<string>("Item_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Item_Price")
                        .HasColumnType("int");

                    b.Property<string>("Item_image")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Item_ID");

                    b.ToTable("TblItem");
                });

            modelBuilder.Entity("Food_Order_System.Models.Owner", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Email");

                    b.ToTable("TblOwner");

                    b.HasData(
                        new
                        {
                            Email = "dtm2024@gmail.com",
                            Password = "12345"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
