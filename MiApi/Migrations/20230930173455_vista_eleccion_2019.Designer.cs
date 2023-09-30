﻿// <auto-generated />
using System;
using MiApi.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MiApi.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20230930173455_vista_eleccion_2019")]
    partial class vista_eleccion_2019
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MiApi.Models.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .HasMaxLength(55)
                        .IsUnicode(false)
                        .HasColumnType("varchar(55)")
                        .HasColumnName("author");

                    b.Property<int?>("Likes")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("likes")
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("Title")
                        .HasMaxLength(55)
                        .IsUnicode(false)
                        .HasColumnType("varchar(55)")
                        .HasColumnName("title");

                    b.Property<string>("Url")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("url");

                    b.HasKey("Id")
                        .HasName("PK__blog__3213E83FB399F40B");

                    b.ToTable("blog", (string)null);
                });

            modelBuilder.Entity("MiApi.Models.Eleccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Candidato")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("candidato");

                    b.Property<string>("Departamento")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("departamento");

                    b.Property<int>("Votos")
                        .HasColumnType("int")
                        .HasColumnName("votos");

                    b.HasKey("Id");

                    b.ToTable("elecciones_2019", (string)null);
                });

            modelBuilder.Entity("MiApi.Models.EleccionDTO", b =>
                {
                    b.Property<string>("Candidato")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("candidato");

                    b.Property<int>("CantidadDeVotos")
                        .HasColumnType("int")
                        .HasColumnName("CantidadDeVotos");

                    b.Property<decimal>("Porcentaje")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Porcentaje");

                    b.ToTable((string)null);

                    b.ToView("VistaElecciones", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}