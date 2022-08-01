﻿// <auto-generated />
using System;
using LegitimatieStudentDigitala.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LegitimatieStudentDigitala.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220801114848_Updated domeniu and facultate")]
    partial class Updateddomeniuandfacultate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LegitimatieStudentDigitala.Models.Domeniu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cod_Domeniu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cod_Facultate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DataCreat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataModificat")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<int>("Forma_Invatamant")
                        .HasColumnType("int");

                    b.Property<long>("Numar_Ani")
                        .HasColumnType("bigint");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Studiu_Universitar")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Domenii");
                });

            modelBuilder.Entity("LegitimatieStudentDigitala.Models.Facultate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Cod_Facultate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DataCreat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataModificat")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numar_FAX")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Numar_Telefon")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Facultati");
                });

            modelBuilder.Entity("LegitimatieStudentDigitala.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("An_Curent")
                        .HasColumnType("bigint");

                    b.Property<string>("CNP")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Cod_Domeniu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cod_Legitimatie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DataCreat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataModificat")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("FacultateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Forma_Finantare")
                        .HasColumnType("int");

                    b.Property<string>("Initiala_Tata")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Parola")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Path_Poza")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Rol")
                        .HasColumnType("int");

                    b.Property<string>("Serie_Legitimatie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stare_Inmatriculare")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FacultateId");

                    b.ToTable("Useri");
                });

            modelBuilder.Entity("LegitimatieStudentDigitala.Models.User", b =>
                {
                    b.HasOne("LegitimatieStudentDigitala.Models.Facultate", null)
                        .WithMany("Administratori")
                        .HasForeignKey("FacultateId");
                });

            modelBuilder.Entity("LegitimatieStudentDigitala.Models.Facultate", b =>
                {
                    b.Navigation("Administratori");
                });
#pragma warning restore 612, 618
        }
    }
}