﻿// <auto-generated />
using System;
using DeviceDashboard.API.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DeviceDasboard.API.Migrations
{
    [DbContext(typeof(DeviceDashboardContext))]
    [Migration("20201103162251_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DeviceDashboard.API.Entities.Device", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Devices");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            Address = "Gaje Alage 8, Zagreb, Hrvatska"
                        },
                        new
                        {
                            Id = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                            Address = "Kobiljacka 50, Zagreb, Hrvatska"
                        },
                        new
                        {
                            Id = new Guid("2902b665-1190-4c70-9915-b9c2d7680450"),
                            Address = "Pete Poljanice 12, Zagreb, Hrvatska"
                        },
                        new
                        {
                            Id = new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                            Address = "Maksimirska 23, Zagreb, Hrvatska"
                        },
                        new
                        {
                            Id = new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                            Address = "Sesvete 45, Zagreb, Hrvatska"
                        });
                });

            modelBuilder.Entity("DeviceDashboard.API.Entities.Reading", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CO2Consumption")
                        .HasColumnType("int");

                    b.Property<long>("CreatedAt")
                        .HasColumnType("bigint");

                    b.Property<Guid>("DeviceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("O2Production")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.ToTable("Readings");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                            CO2Consumption = 12,
                            CreatedAt = 1603540800000L,
                            DeviceId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            O2Production = 10
                        },
                        new
                        {
                            Id = new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7d4"),
                            CO2Consumption = 15,
                            CreatedAt = 1603368000000L,
                            DeviceId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            O2Production = 8
                        },
                        new
                        {
                            Id = new Guid("d8663e5e-7494-4f81-8739-6e0de1bea737"),
                            CO2Consumption = 10,
                            CreatedAt = 1603454400000L,
                            DeviceId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            O2Production = 4
                        },
                        new
                        {
                            Id = new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7a6"),
                            CO2Consumption = 12,
                            CreatedAt = 1603540800000L,
                            DeviceId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            O2Production = 10
                        },
                        new
                        {
                            Id = new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7b7"),
                            CO2Consumption = 11,
                            CreatedAt = 1603371600000L,
                            DeviceId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            O2Production = 6
                        },
                        new
                        {
                            Id = new Guid("d8663e5e-7494-4f81-8739-6e0de1bea766"),
                            CO2Consumption = 14,
                            CreatedAt = 1603540800000L,
                            DeviceId = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                            O2Production = 8
                        },
                        new
                        {
                            Id = new Guid("d8663e5e-7494-4f81-8739-6e0de1bea76b"),
                            CO2Consumption = 16,
                            CreatedAt = 1603368000000L,
                            DeviceId = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                            O2Production = 9
                        },
                        new
                        {
                            Id = new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7b5"),
                            CO2Consumption = 5,
                            CreatedAt = 1603454400000L,
                            DeviceId = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                            O2Production = 1
                        },
                        new
                        {
                            Id = new Guid("d8663e5e-7494-4f81-8739-6e0de1bea655"),
                            CO2Consumption = 14,
                            CreatedAt = 1603540800000L,
                            DeviceId = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                            O2Production = 8
                        },
                        new
                        {
                            Id = new Guid("d8663e5e-7494-4f81-8739-6e0de1bea7a5"),
                            CO2Consumption = 11,
                            CreatedAt = 1603371600000L,
                            DeviceId = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                            O2Production = 6
                        },
                        new
                        {
                            Id = new Guid("d8663e5e-7494-4f81-8739-6e0de1bea754"),
                            CO2Consumption = 12,
                            CreatedAt = 1603540800000L,
                            DeviceId = new Guid("2902b665-1190-4c70-9915-b9c2d7680450"),
                            O2Production = 7
                        },
                        new
                        {
                            Id = new Guid("d8663e5e-7494-4f81-8739-6e0de1bea745"),
                            CO2Consumption = 14,
                            CreatedAt = 1603368000000L,
                            DeviceId = new Guid("2902b665-1190-4c70-9915-b9c2d7680450"),
                            O2Production = 6
                        },
                        new
                        {
                            Id = new Guid("d8663e5e-7494-4f81-8739-6e0de1bea744"),
                            CO2Consumption = 9,
                            CreatedAt = 1603454400000L,
                            DeviceId = new Guid("2902b665-1190-4c70-9915-b9c2d7680450"),
                            O2Production = 3
                        },
                        new
                        {
                            Id = new Guid("d8663e5e-7494-4f81-8739-6e0de1bea743"),
                            CO2Consumption = 12,
                            CreatedAt = 1603540800000L,
                            DeviceId = new Guid("2902b665-1190-4c70-9915-b9c2d7680450"),
                            O2Production = 7
                        },
                        new
                        {
                            Id = new Guid("d8663e5e-7494-4f81-8739-6e0de1bea734"),
                            CO2Consumption = 13,
                            CreatedAt = 1603371600000L,
                            DeviceId = new Guid("2902b665-1190-4c70-9915-b9c2d7680450"),
                            O2Production = 5
                        },
                        new
                        {
                            Id = new Guid("d8663e5e-7494-4f81-8739-6e0de1bea633"),
                            CO2Consumption = 17,
                            CreatedAt = 1603540800000L,
                            DeviceId = new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                            O2Production = 10
                        },
                        new
                        {
                            Id = new Guid("d8663e5e-7494-4f81-8739-6e0de1bea733"),
                            CO2Consumption = 13,
                            CreatedAt = 1603368000000L,
                            DeviceId = new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                            O2Production = 7
                        },
                        new
                        {
                            Id = new Guid("d8663e5e-7494-4f81-8739-6e0de1bea721"),
                            CO2Consumption = 18,
                            CreatedAt = 1603454400000L,
                            DeviceId = new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                            O2Production = 11
                        },
                        new
                        {
                            Id = new Guid("d8663e5e-7494-4f81-8739-6e0de1bea723"),
                            CO2Consumption = 17,
                            CreatedAt = 1603540800000L,
                            DeviceId = new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                            O2Production = 10
                        },
                        new
                        {
                            Id = new Guid("d8663e5e-7494-4f81-8739-6e0de1bea722"),
                            CO2Consumption = 12,
                            CreatedAt = 1603371600000L,
                            DeviceId = new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"),
                            O2Production = 5
                        },
                        new
                        {
                            Id = new Guid("d8663e5e-7494-4f81-8739-6e0de1bea711"),
                            CO2Consumption = 19,
                            CreatedAt = 1603540800000L,
                            DeviceId = new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                            O2Production = 12
                        },
                        new
                        {
                            Id = new Guid("d8663e5e-7494-4f81-8739-6e0de1bea712"),
                            CO2Consumption = 23,
                            CreatedAt = 1603368000000L,
                            DeviceId = new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                            O2Production = 17
                        },
                        new
                        {
                            Id = new Guid("d8663e5e-7494-4f81-8739-6e0de1bea77a"),
                            CO2Consumption = 9,
                            CreatedAt = 1603454400000L,
                            DeviceId = new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                            O2Production = 2
                        },
                        new
                        {
                            Id = new Guid("d8663e5e-7494-4f81-8739-6e0de1bea778"),
                            CO2Consumption = 19,
                            CreatedAt = 1603540800000L,
                            DeviceId = new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                            O2Production = 12
                        },
                        new
                        {
                            Id = new Guid("d8663e5e-7494-4f81-8739-6e0de1bea777"),
                            CO2Consumption = 14,
                            CreatedAt = 1603371600000L,
                            DeviceId = new Guid("5b3621c0-7b12-4e80-9c8b-3398cba7ee05"),
                            O2Production = 7
                        });
                });

            modelBuilder.Entity("DeviceDashboard.API.Entities.Reading", b =>
                {
                    b.HasOne("DeviceDashboard.API.Entities.Device", "Device")
                        .WithMany("Readings")
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
