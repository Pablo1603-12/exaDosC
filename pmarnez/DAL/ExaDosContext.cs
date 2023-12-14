using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace pmarnez.DAL;

public partial class ExaDosContext : DbContext
{
    public ExaDosContext()
    {
    }

    public ExaDosContext(DbContextOptions<ExaDosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<ReservaElementovajilla> ReservaElementovajillas { get; set; }

    public virtual DbSet<ReservaVajilla> ReservaVajillas { get; set; }

    public virtual DbSet<Vajilla> Vajillas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;DataBase=exaDos; UserId=postgres;Password=1234;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.IdReserva).HasName("reserva_pkey");

            entity.ToTable("reserva", "esqexados");

            entity.Property(e => e.IdReserva).HasColumnName("id_reserva");
            entity.Property(e => e.FchReserva)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fch_reserva");
        });

        modelBuilder.Entity<ReservaElementovajilla>(entity =>
        {
            entity.HasKey(e => new { e.IdReserva, e.IdElementoVajilla }).HasName("reserva_elementovajilla_pkey");

            entity.ToTable("reserva_elementovajilla");

            entity.Property(e => e.IdReserva).HasColumnName("id_reserva");
            entity.Property(e => e.IdElementoVajilla).HasColumnName("id_elemento_vajilla");
        });

        modelBuilder.Entity<ReservaVajilla>(entity =>
        {
            entity.HasKey(e => new { e.IdReserva, e.IdElementoVajilla }).HasName("reserva_vajilla_pkey");

            entity.ToTable("reserva_vajilla");

            entity.Property(e => e.IdReserva).HasColumnName("id_reserva");
            entity.Property(e => e.IdElementoVajilla).HasColumnName("id_elemento_vajilla");
        });

        modelBuilder.Entity<Vajilla>(entity =>
        {
            entity.HasKey(e => e.IdElementoVajilla).HasName("vajilla_pkey");

            entity.ToTable("vajilla", "esqexados");

            entity.Property(e => e.IdElementoVajilla).HasColumnName("id_elemento_vajilla");
            entity.Property(e => e.CantidadElemento).HasColumnName("cantidad_elemento");
            entity.Property(e => e.CodigoElemento)
                .HasMaxLength(255)
                .HasColumnName("codigo_elemento");
            entity.Property(e => e.DescripcionElemento)
                .HasMaxLength(255)
                .HasColumnName("descripcion_elemento");
            entity.Property(e => e.NombreElemento)
                .HasMaxLength(255)
                .HasColumnName("nombre_elemento");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
