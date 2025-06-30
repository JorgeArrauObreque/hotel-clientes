using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace hotel_clientes.Models;

public partial class FacturacionHotelContext : DbContext
{


    public FacturacionHotelContext(DbContextOptions<FacturacionHotelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ciudad> Ciudads { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<ClienteEstado> ClienteEstados { get; set; }

    public virtual DbSet<ClienteNivelMembresium> ClienteNivelMembresia { get; set; }

    public virtual DbSet<Comuna> Comunas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ciudad>(entity =>
        {
            entity.HasKey(e => e.IdCiudad);

            entity.ToTable("ciudad");

            entity.Property(e => e.IdCiudad).HasColumnName("id_ciudad");
            entity.Property(e => e.NombreCiudad)
                .HasMaxLength(90)
                .IsUnicode(false)
                .HasColumnName("nombre_ciudad");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.RutCliente).HasName("PK_Empresas");

            entity.ToTable("clientes");

            entity.Property(e => e.RutCliente)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("rut_cliente");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.ClienteFrecuente).HasColumnName("cliente_frecuente");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Creadopor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("creadopor");
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaActualizacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_actualizacion");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Genero)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("genero");
            entity.Property(e => e.IdComuna).HasColumnName("id_comuna");
            entity.Property(e => e.IdNivelMembresia).HasColumnName("id_nivel_membresia");
            entity.Property(e => e.Modificadopor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modificadopor");
            entity.Property(e => e.Nacionalidad)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nacionalidad");
            entity.Property(e => e.Nombres)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("nombres");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("observaciones");
            entity.Property(e => e.PaisOrigen)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("pais_origen");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdComunaNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdComuna)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Clientes_comuna");

            entity.HasOne(d => d.IdNivelMembresiaNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdNivelMembresia)
                .HasConstraintName("FK_Clientes_cliente_nivel_membresia");
        });

        modelBuilder.Entity<ClienteEstado>(entity =>
        {
            entity.HasKey(e => e.IdClienteEstado);

            entity.ToTable("cliente_estado");

            entity.Property(e => e.IdClienteEstado).HasColumnName("id_cliente_estado");
            entity.Property(e => e.DescripcionClienteEstado)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("descripcion_cliente_estado");
            entity.Property(e => e.FechaActualizacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_actualizacion");
            entity.Property(e => e.FechaIngreso)
                .HasColumnType("datetime")
                .HasColumnName("fecha_ingreso");
        });

        modelBuilder.Entity<ClienteNivelMembresium>(entity =>
        {
            entity.HasKey(e => e.IdClienteMembresia);

            entity.ToTable("cliente_nivel_membresia");

            entity.Property(e => e.IdClienteMembresia).HasColumnName("id_cliente_membresia");
            entity.Property(e => e.DescripcionClienteMembresia)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("descripcion_cliente_membresia");
        });

        modelBuilder.Entity<Comuna>(entity =>
        {
            entity.HasKey(e => e.IdComuna);

            entity.ToTable("comuna");

            entity.Property(e => e.IdComuna).HasColumnName("id_comuna");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdCiudad).HasColumnName("id_ciudad");
            entity.Property(e => e.NombreComuna)
                .HasMaxLength(90)
                .IsUnicode(false)
                .HasColumnName("nombre_comuna");

            entity.HasOne(d => d.IdCiudadNavigation).WithMany(p => p.Comunas)
                .HasForeignKey(d => d.IdCiudad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_comuna_ciudad");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
