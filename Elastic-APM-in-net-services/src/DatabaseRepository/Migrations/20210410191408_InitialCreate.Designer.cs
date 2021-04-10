﻿// <auto-generated />
using System;
using DatabaseRepository.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DatabaseRepository.Migrations
{
    [DbContext(typeof(PlaceContext))]
    [Migration("20210410191408_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("DatabaseRepository.EfCore.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("longtext");

                    b.Property<string>("Country")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("HouseNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("Street")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Zip")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("addresses");
                });

            modelBuilder.Entity("DatabaseRepository.EfCore.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DisplayName")
                        .HasColumnType("longtext");

                    b.Property<double?>("Lat")
                        .HasColumnType("double");

                    b.Property<double?>("Lon")
                        .HasColumnType("double");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("places");
                });

            modelBuilder.Entity("DatabaseRepository.EfCore.Place", b =>
                {
                    b.HasOne("DatabaseRepository.EfCore.Address", "Address")
                        .WithMany("Place")
                        .HasForeignKey("AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("DatabaseRepository.EfCore.Address", b =>
                {
                    b.Navigation("Place");
                });
#pragma warning restore 612, 618
        }
    }
}
