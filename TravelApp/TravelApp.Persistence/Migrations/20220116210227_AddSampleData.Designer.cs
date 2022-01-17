﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelApp.Persistence;

namespace TravelApp.Persistence.Migrations
{
    [DbContext(typeof(TravelAppContext))]
    [Migration("20220116210227_AddSampleData")]
    partial class AddSampleData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TravelApp.Domain.Entities.FareDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Destination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Fare")
                        .HasColumnType("int");

                    b.Property<DateTime>("FareDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TransportTypeDetailsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TransportTypeDetailsId");

                    b.ToTable("FareDetails");
                });

            modelBuilder.Entity("TravelApp.Domain.Entities.TransportType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TransportTypes");
                });

            modelBuilder.Entity("TravelApp.Domain.Entities.TransportTypeDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("TransportNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TransportTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TransportTypeId");

                    b.ToTable("TransportTypeDetails");
                });

            modelBuilder.Entity("TravelApp.Domain.Entities.TravelDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArrivalTerminal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepartureTerminal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FareDetailsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FareDetailsId");

                    b.ToTable("TravelDetails");
                });

            modelBuilder.Entity("TravelApp.Domain.Entities.FareDetails", b =>
                {
                    b.HasOne("TravelApp.Domain.Entities.TransportTypeDetails", null)
                        .WithMany("FareDetails")
                        .HasForeignKey("TransportTypeDetailsId");
                });

            modelBuilder.Entity("TravelApp.Domain.Entities.TransportTypeDetails", b =>
                {
                    b.HasOne("TravelApp.Domain.Entities.TransportType", "TransportType")
                        .WithMany("TransportTypeDetails")
                        .HasForeignKey("TransportTypeId");
                });

            modelBuilder.Entity("TravelApp.Domain.Entities.TravelDetails", b =>
                {
                    b.HasOne("TravelApp.Domain.Entities.FareDetails", "FareDetails")
                        .WithMany("TravelDetails")
                        .HasForeignKey("FareDetailsId");
                });
#pragma warning restore 612, 618
        }
    }
}
