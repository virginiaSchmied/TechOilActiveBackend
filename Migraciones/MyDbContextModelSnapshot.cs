﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechOilActive;

#nullable disable

namespace TechOilActive.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TechOilActive.Models.Proyecto", b =>
                {
                    b.Property<int>("codProyecto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codProyecto"));

                    b.Property<string>("direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("estado")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("codProyecto");

                    b.ToTable("Proyecto");
                });

            modelBuilder.Entity("TechOilActive.Models.Servicio", b =>
                {
                    b.Property<int>("codServicio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codServicio"));

                    b.Property<string>("descr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("estado")
                        .HasColumnType("int");

                    b.Property<int?>("valorHora")
                        .HasColumnType("int");

                    b.HasKey("codServicio");

                    b.ToTable("Servicio");
                });

            modelBuilder.Entity("TechOilActive.Models.Trabajo", b =>
                {
                    b.Property<int>("codTrabajo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codTrabajo"));

                    b.Property<int?>("cantHoras")
                        .HasColumnType("int");

                    b.Property<int>("codProyecto")
                        .HasColumnType("int");

                    b.Property<int>("codServicio")
                        .HasColumnType("int");

                    b.Property<int?>("costo")
                        .HasColumnType("int");

                    b.Property<int?>("fecha")
                        .HasColumnType("int");

                    b.Property<int?>("valorHora")
                        .HasColumnType("int");

                    b.HasKey("codTrabajo");

                    b.ToTable("Trabajo");
                });

            modelBuilder.Entity("TechOilActive.Models.Usuario", b =>
                {
                    b.Property<int>("codUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codUsuario"));

                    b.Property<int?>("contraseña")
                        .HasColumnType("int");

                    b.Property<int?>("dni")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("tipo")
                        .HasColumnType("int");

                    b.HasKey("codUsuario");

                    b.ToTable("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
