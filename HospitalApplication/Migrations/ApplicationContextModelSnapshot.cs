﻿// <auto-generated />
using System;
using HospitalApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HospitalApplication.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HospitalApplication.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("carPaymentValue")
                        .HasColumnType("int");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("HospitalApplication.Models.Floor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Section")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("numHab")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Floors");
                });

            modelBuilder.Entity("HospitalApplication.Models.Parking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("carId")
                        .HasColumnType("int");

                    b.Property<DateTime>("from")
                        .HasColumnType("datetime2");

                    b.Property<int>("idPerson")
                        .HasColumnType("int");

                    b.Property<string>("licensePlate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("to")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ParkingEntries");
                });

            modelBuilder.Entity("HospitalApplication.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DNI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastnames")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("hasCar")
                        .HasColumnType("bit");

                    b.Property<int>("parkingSlot")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("People");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("HospitalApplication.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("active")
                        .HasColumnType("bit");

                    b.Property<int>("floorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("HospitalApplication.Models.WorkersFloorsRelated", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("floorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("from")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("to")
                        .HasColumnType("datetime2");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("WorkersFloorsRelateds");
                });

            modelBuilder.Entity("HospitalApplication.Models.Administrator", b =>
                {
                    b.HasBaseType("HospitalApplication.Models.Person");

                    b.Property<string>("admin_accreditation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Administrator");
                });

            modelBuilder.Entity("HospitalApplication.Models.Doctor", b =>
                {
                    b.HasBaseType("HospitalApplication.Models.Person");

                    b.Property<string>("doctor_accreditation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Doctor");
                });

            modelBuilder.Entity("HospitalApplication.Models.Nurse", b =>
                {
                    b.HasBaseType("HospitalApplication.Models.Person");

                    b.Property<string>("nurse_accreditation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Nurse");
                });

            modelBuilder.Entity("HospitalApplication.Models.Patient", b =>
                {
                    b.HasBaseType("HospitalApplication.Models.Person");

                    b.Property<DateTime>("arrivalDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dischargeDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("disease")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idRoomId")
                        .HasColumnType("int");

                    b.HasIndex("idRoomId");

                    b.HasDiscriminator().HasValue("Patient");
                });

            modelBuilder.Entity("HospitalApplication.Models.Patient", b =>
                {
                    b.HasOne("HospitalApplication.Models.Room", "idRoom")
                        .WithMany()
                        .HasForeignKey("idRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("idRoom");
                });
#pragma warning restore 612, 618
        }
    }
}
