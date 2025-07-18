﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestTruckStore.Api.Data;

#nullable disable

namespace TestTruckStore.Api.Migrations
{
    [DbContext(typeof(TruckStoreContext))]
    partial class TruckStoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TestTruckStore.Api.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Mercedes"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Volvo"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Renault"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Scania"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Iveco"
                        });
                });

            modelBuilder.Entity("TestTruckStore.Api.Models.Truck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<DateOnly>("ReleaseSate")
                        .HasColumnType("date");

                    b.Property<int>("maxLiftingCapacity")
                        .HasColumnType("int");

                    b.Property<int>("maxSpeed")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Trucks");
                });

            modelBuilder.Entity("TestTruckStore.Api.Models.Truck", b =>
                {
                    b.HasOne("TestTruckStore.Api.Models.Brand", "BrandName")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BrandName");
                });
#pragma warning restore 612, 618
        }
    }
}
