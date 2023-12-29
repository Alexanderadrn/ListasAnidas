using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ListasAnidas.Models;

public partial class ListasanidadasContext : DbContext
{
    public ListasanidadasContext()
    {
    }

    public ListasanidadasContext(DbContextOptions<ListasanidadasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ciudad> Ciudads { get; set; }

    public virtual DbSet<Parroquium> Parroquia { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Provincium> Provincia { get; set; }

    public virtual DbSet<RelacionCiudadParroquium> RelacionCiudadParroquia { get; set; }

    public virtual DbSet<RelacionProviciaCiudad> RelacionProviciaCiudads { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-S78SCGN;Database=listasanidadas;Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ciudad>(entity =>
        {
            entity.HasKey(e => e.IdCiudad).HasName("PK__Ciudad__D4D3CCB08B4E4C67");

            entity.ToTable("Ciudad");

            entity.Property(e => e.NombreCiudad)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdProvinciaNavigation).WithMany(p => p.Ciudads)
                .HasForeignKey(d => d.IdProvincia)
                .HasConstraintName("FK_IdProvincia");
        });

        modelBuilder.Entity<Parroquium>(entity =>
        {
            entity.HasKey(e => e.IdParroquia).HasName("PK__Parroqui__F2C93B4375F5D4C3");

            entity.Property(e => e.NombreParroquia)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCiudadNavigation).WithMany(p => p.Parroquia)
                .HasForeignKey(d => d.IdCiudad)
                .HasConstraintName("FK_IdCiudadParroquia");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPersonas).HasName("PK__persona__05A9201240BD66EF");

            entity.ToTable("persona");

            entity.Property(e => e.CedulaPersonas)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NombrePersona)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCiudadNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdCiudad)
                .HasConstraintName("Fk_IdCiudad");

            entity.HasOne(d => d.IdParroquiaNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdParroquia)
                .HasConstraintName("Fk_IdParroquia");

            entity.HasOne(d => d.IdProvinciaNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdProvincia)
                .HasConstraintName("Fk_IdProvincias");
        });

        modelBuilder.Entity<Provincium>(entity =>
        {
            entity.HasKey(e => e.IdProvincias).HasName("PK__Provinci__3E17B85DB65FA29A");

            entity.Property(e => e.NombreProvincia)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RelacionCiudadParroquium>(entity =>
        {
            entity.HasKey(e => e.IdRelCiuParr).HasName("PK__Relacion__5887D6939DBD4BA4");

            entity.Property(e => e.NombreCiudad)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NombreParroquia)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NombreProvincia)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RelacionProviciaCiudad>(entity =>
        {
            entity.HasKey(e => e.IdRelProvCiu).HasName("PK__Relacion__3992D9F1DB3A17B4");

            entity.ToTable("RelacionProviciaCiudad");

            entity.Property(e => e.NombreCiudad)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NombreProvincia)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
