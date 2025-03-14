﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DbContext.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DbContext.Entities.RideData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DOLocationID")
                        .HasColumnType("int");

                    b.Property<decimal>("FareAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PULocationID")
                        .HasColumnType("int");

                    b.Property<int>("PassengerCount")
                        .HasColumnType("int");

                    b.Property<string>("StoreAndFwdFlag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TipAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("TpepDropoffDatetime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TpepPickupDatetime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TripDistance")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("PULocationID")
                        .HasDatabaseName("IDX_PULocationID");

                    b.HasIndex("TripDistance")
                        .HasDatabaseName("IDX_TripDistance");

                    b.HasIndex("TpepPickupDatetime", "TpepDropoffDatetime")
                        .HasDatabaseName("IDX_TravelTime");

                    b.ToTable("RideData");
                });
#pragma warning restore 612, 618
        }
    }
}
