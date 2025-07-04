﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Theatre_App.Data;

#nullable disable

namespace Theatre_App.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250628100610_updateUserTable")]
    partial class updateUserTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Theatre_App.Models.Catalogue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Catalogues");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Customs"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Props"
                        });
                });

            modelBuilder.Entity("Theatre_App.Models.Items", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CataId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imgurl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<bool>("inStock")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CataId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Theatre_App.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Theatre_App.Models.Orders", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<Guid>("User_Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("User_Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Theatre_App.Models.Roles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "user"
                        });
                });

            modelBuilder.Entity("Theatre_App.Models.Users", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d1c1c31e-1234-4fae-8c1c-abcdef123456"),
                            Name = "Marco",
                            PhoneNumber = "01282771887",
                            RoleID = 1,
                            password = "FeKw08M4keuw8e9gnsQZQgwg4yDOlMZfvIwzEkSOsiU="
                        });
                });

            modelBuilder.Entity("Theatre_App.Models.Items", b =>
                {
                    b.HasOne("Theatre_App.Models.Catalogue", "Catalogue")
                        .WithMany()
                        .HasForeignKey("CataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Catalogue");
                });

            modelBuilder.Entity("Theatre_App.Models.OrderItem", b =>
                {
                    b.HasOne("Theatre_App.Models.Items", "Items")
                        .WithMany("OrderItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Theatre_App.Models.Orders", "Orders")
                        .WithMany("Contents")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Items");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Theatre_App.Models.Orders", b =>
                {
                    b.HasOne("Theatre_App.Models.Users", "Users")
                        .WithMany()
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Theatre_App.Models.Users", b =>
                {
                    b.HasOne("Theatre_App.Models.Roles", "Role")
                        .WithMany()
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Theatre_App.Models.Items", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("Theatre_App.Models.Orders", b =>
                {
                    b.Navigation("Contents");
                });
#pragma warning restore 612, 618
        }
    }
}
