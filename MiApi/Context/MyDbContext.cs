using System;
using System.Collections.Generic;
using MiApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MiApi.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Blog> Blogs { get; set; }
    public virtual DbSet<Eleccion> Eleccion { get; set; }
    public virtual DbSet<EleccionDTO> VistaElecciones { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=CC5-05\\SQLEXPRESS;Database=SR100919;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__blog__3213E83FB399F40B");

            entity.ToTable("blog");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Author)
                .HasMaxLength(55)
                .IsUnicode(false)
                .HasColumnName("author");
            entity.Property(e => e.Likes)
                .HasDefaultValueSql("((0))")
                .HasColumnName("likes");
            entity.Property(e => e.Title)
                .HasMaxLength(55)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.Url)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("url");
        });

        modelBuilder.Entity<Eleccion>(entity =>
        {
            entity.ToTable("elecciones_2019"); // Nombre de la tabla en la base de datos

            entity.HasKey(e => e.Id); // Establece la clave principal
            entity.Property(e => e.Id).HasColumnName("id"); // Mapea la columna "id"
            entity.Property(e => e.Departamento)
                .HasMaxLength(255) // Ajusta el tamaño máximo según tu esquema de base de datos
                .HasColumnName("departamento"); // Mapea la columna "departamento"
            entity.Property(e => e.Candidato)
                .HasMaxLength(255) // Ajusta el tamaño máximo según tu esquema de base de datos
                .HasColumnName("candidato"); // Mapea la columna "candidato"
            entity.Property(e => e.Votos).HasColumnName("votos"); // Mapea la columna "votos"
        });

        // Mapeo de la vista "VistaElecciones" a la entidad "EleccionDTO"
        modelBuilder.Entity<EleccionDTO>(entity =>
        {
            entity.ToView("vista_eleccion_2019"); // Nombre de la vista en la base de datos

            // Mapea las propiedades de la entidad con las columnas de la vista
            entity.Property(e => e.Candidato).HasColumnName("candidato");
            entity.Property(e => e.CantidadDeVotos).HasColumnName("CantidadDeVotos");
            entity.Property(e => e.Porcentaje).HasColumnName("Porcentaje");
            entity.Property(e => e.Porcentaje).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<EleccionDTO>().HasNoKey();

        OnModelCreatingPartial(modelBuilder);
    }






    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
