﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestTask.Infrastructure.Data;

#nullable disable

namespace TestTask.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.33")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TestTask.ApplicationCore.Models.Areas", b =>
                {
                    b.Property<string>("areasId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("areasNumber")
                        .HasColumnType("int");

                    b.HasKey("areasId");

                    b.HasIndex("areasNumber")
                        .IsUnique();

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("TestTask.ApplicationCore.Models.Cabinets", b =>
                {
                    b.Property<string>("cabinetId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("cabinetNumber")
                        .HasColumnType("int");

                    b.HasKey("cabinetId");

                    b.HasIndex("cabinetNumber")
                        .IsUnique();

                    b.ToTable("Cabinets");
                });

            modelBuilder.Entity("TestTask.ApplicationCore.Models.Doctors", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("areasId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("cabinetsId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("fullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("specializationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("areasId");

                    b.HasIndex("cabinetsId");

                    b.HasIndex("fullName");

                    b.HasIndex("specializationId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("TestTask.ApplicationCore.Models.Patients", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("areasId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("date_of_birth")
                        .HasColumnType("datetime2");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("middleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("areasId");

                    b.HasIndex("firstName", "lastName", "middleName");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("TestTask.ApplicationCore.Models.Specialization", b =>
                {
                    b.Property<string>("specializationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("specializationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("specializationId");

                    b.HasIndex("specializationName")
                        .IsUnique();

                    b.ToTable("Specialization");
                });

            modelBuilder.Entity("TestTask.ApplicationCore.Models.Doctors", b =>
                {
                    b.HasOne("TestTask.ApplicationCore.Models.Areas", "areas")
                        .WithMany()
                        .HasForeignKey("areasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestTask.ApplicationCore.Models.Cabinets", "cabinets")
                        .WithMany()
                        .HasForeignKey("cabinetsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestTask.ApplicationCore.Models.Specialization", "specialization")
                        .WithMany()
                        .HasForeignKey("specializationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("areas");

                    b.Navigation("cabinets");

                    b.Navigation("specialization");
                });

            modelBuilder.Entity("TestTask.ApplicationCore.Models.Patients", b =>
                {
                    b.HasOne("TestTask.ApplicationCore.Models.Areas", "areas")
                        .WithMany()
                        .HasForeignKey("areasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("areas");
                });
#pragma warning restore 612, 618
        }
    }
}
