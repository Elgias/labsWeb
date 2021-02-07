﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using labs.Models;

namespace labs.Migrations
{
    [DbContext(typeof(labsAWContext))]
    [Migration("20210131170502_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("labs.Models.EF_Models.ClientModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.Property<int>("SequentialNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ClientModel");
                });

            modelBuilder.Entity("labs.Models.EF_Models.LaboratoryWorkModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("LaboratoryWorkModel");
                });

            modelBuilder.Entity("labs.Models.EF_Models.OrderModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CompleteDateTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("Discount")
                        .HasColumnType("float");

                    b.Property<int>("LaboratoryWorkId")
                        .HasColumnType("int");

                    b.Property<double>("Payed")
                        .HasColumnType("float");

                    b.Property<DateTime>("RegisterDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("LaboratoryWorkId");

                    b.ToTable("OrderModel");
                });

            modelBuilder.Entity("labs.Models.EF_Models.SubjectModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("SubjectModel");
                });

            modelBuilder.Entity("labs.Models.EF_Models.LaboratoryWorkModel", b =>
                {
                    b.HasOne("labs.Models.EF_Models.SubjectModel", "SubjectModel")
                        .WithMany("LaboratoryWorkModel")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubjectModel");
                });

            modelBuilder.Entity("labs.Models.EF_Models.OrderModel", b =>
                {
                    b.HasOne("labs.Models.EF_Models.ClientModel", "ClientModel")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("labs.Models.EF_Models.LaboratoryWorkModel", "LaboratoryWorkModel")
                        .WithMany("Orders")
                        .HasForeignKey("LaboratoryWorkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClientModel");

                    b.Navigation("LaboratoryWorkModel");
                });

            modelBuilder.Entity("labs.Models.EF_Models.ClientModel", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("labs.Models.EF_Models.LaboratoryWorkModel", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("labs.Models.EF_Models.SubjectModel", b =>
                {
                    b.Navigation("LaboratoryWorkModel");
                });
#pragma warning restore 612, 618
        }
    }
}
