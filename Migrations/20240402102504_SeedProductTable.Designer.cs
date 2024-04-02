﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Product_Inventory.Data;

#nullable disable

namespace Product_Inventory.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240402102504_SeedProductTable")]
    partial class SeedProductTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Product_Inventory.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Brand New Car",
                            Name = "Car",
                            Price = 20000m,
                            Quantity = 20
                        },
                        new
                        {
                            Id = 2,
                            Description = "Brand New Bike",
                            Name = "Bike",
                            Price = 20000m,
                            Quantity = 20
                        },
                        new
                        {
                            Id = 3,
                            Description = "Brand New Bicycle",
                            Name = "Bicycle",
                            Price = 20000m,
                            Quantity = 20
                        },
                        new
                        {
                            Id = 4,
                            Description = "Brand New Truck",
                            Name = "Truck",
                            Price = 20000m,
                            Quantity = 20
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
