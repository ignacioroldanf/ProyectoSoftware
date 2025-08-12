using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Modelo.Modelo;

public partial class DiplomaContext : DbContext
{
    public DiplomaContext()
    {
    }

    public DiplomaContext(DbContextOptions<DiplomaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DiasRutina> DiasRutinas { get; set; }

    public virtual DbSet<Ejercicio> Ejercicios { get; set; }

    public virtual DbSet<EjerciciosAsignado> EjerciciosAsignados { get; set; }

    public virtual DbSet<EstadoSuscripcion> EstadoSuscripcions { get; set; }

    public virtual DbSet<Plane> Planes { get; set; }

    public virtual DbSet<Progreso> Progresos { get; set; }

    public virtual DbSet<Rutina> Rutinas { get; set; }

    public virtual DbSet<Suscripcione> Suscripciones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LegionNachi\\SQLSERVER; Database=Diploma; Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Clientes__3DD0A8CB938D70B5");

            entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");
            entity.Property(e => e.ApellidoCliente)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Apellido_Cliente");
            entity.Property(e => e.DniCliente).HasColumnName("DNI_Cliente");
            entity.Property(e => e.FechaAlta).HasColumnName("Fecha_Alta");
            entity.Property(e => e.MailCliente)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Mail_Cliente");
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Nombre_Cliente");
        });

        modelBuilder.Entity<DiasRutina>(entity =>
        {
            entity.HasKey(e => e.IdDiaRutina).HasName("PK__DiasRuti__20BDF8ED74B8E3F9");

            entity.ToTable("DiasRutina");

            entity.Property(e => e.IdDiaRutina).HasColumnName("Id_DiaRutina");
            entity.Property(e => e.IdRutina).HasColumnName("Id_Rutina");

            entity.HasOne(d => d.IdRutinaNavigation).WithMany(p => p.DiasRutinas)
                .HasForeignKey(d => d.IdRutina)
                .HasConstraintName("FK__DiasRutin__Id_Ru__403A8C7D");
        });

        modelBuilder.Entity<Ejercicio>(entity =>
        {
            entity.HasKey(e => e.IdEjercicio).HasName("PK__Ejercici__D213A07F180E5FA0");

            entity.Property(e => e.IdEjercicio).HasColumnName("Id_Ejercicio");
            entity.Property(e => e.DescripEjercicio)
                .HasMaxLength(150)
                .HasColumnName("Descrip_Ejercicio");
            entity.Property(e => e.NombreEjercicio)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Nombre_Ejercicio");
        });

        modelBuilder.Entity<EjerciciosAsignado>(entity =>
        {
            entity.HasKey(e => e.IdEjercicioAsignado).HasName("PK__Ejercici__135B12F9D8C86323");

            entity.ToTable("EjerciciosAsignado");

            entity.Property(e => e.IdEjercicioAsignado).HasColumnName("Id_EjercicioAsignado");
            entity.Property(e => e.IdDiaRutina).HasColumnName("Id_DiaRutina");
            entity.Property(e => e.IdEjercicio).HasColumnName("Id_Ejercicio");

            entity.HasOne(d => d.IdDiaRutinaNavigation).WithMany(p => p.EjerciciosAsignados)
                .HasForeignKey(d => d.IdDiaRutina)
                .HasConstraintName("FK__Ejercicio__Id_Di__4AB81AF0");

            entity.HasOne(d => d.IdEjercicioNavigation).WithMany(p => p.EjerciciosAsignados)
                .HasForeignKey(d => d.IdEjercicio)
                .HasConstraintName("FK__Ejercicio__Id_Ej__49C3F6B7");
        });

        modelBuilder.Entity<EstadoSuscripcion>(entity =>
        {
            entity.HasKey(e => e.IdEstadoSuscripcion).HasName("PK__EstadoSu__50A12089E3E21DB0");

            entity.ToTable("EstadoSuscripcion");

            entity.Property(e => e.IdEstadoSuscripcion).HasColumnName("Id_EstadoSuscripcion");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Plane>(entity =>
        {
            entity.HasKey(e => e.IdPlan).HasName("PK__Planes__3BD89AB6C238ACB2");

            entity.Property(e => e.IdPlan).HasColumnName("Id_Plan");
            entity.Property(e => e.DescripPlan)
                .HasMaxLength(150)
                .HasColumnName("Descrip_Plan");
            entity.Property(e => e.NombrePlan)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Nombre_Plan");
            entity.Property(e => e.PrecioMensual).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Progreso>(entity =>
        {
            entity.HasKey(e => e.IdProgreso).HasName("PK__Progreso__B12D141097BF38F2");

            entity.Property(e => e.IdProgreso).HasColumnName("Id_Progreso");
            entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");
            entity.Property(e => e.IdEjercicioAsignado).HasColumnName("Id_EjercicioAsignado");
            entity.Property(e => e.Observaciones).HasMaxLength(150);
            entity.Property(e => e.PesoUsado)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Peso_Usado");
            entity.Property(e => e.RepesHechas).HasColumnName("Repes_Hechas");
            entity.Property(e => e.SeriesHechas).HasColumnName("Series_Hechas");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Progresos)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Progresos__Id_Cl__5441852A");

            entity.HasOne(d => d.IdEjercicioAsignadoNavigation).WithMany(p => p.Progresos)
                .HasForeignKey(d => d.IdEjercicioAsignado)
                .HasConstraintName("FK__Progresos__Id_Ej__5535A963");
        });

        modelBuilder.Entity<Rutina>(entity =>
        {
            entity.HasKey(e => e.IdRutina).HasName("PK__Rutinas__7C95EE4097602B0B");

            entity.Property(e => e.IdRutina).HasColumnName("Id_Rutina");
            entity.Property(e => e.CantDias).HasColumnName("Cant_Dias");
            entity.Property(e => e.FechaAsignacion).HasColumnName("Fecha_Asignacion");
            entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Rutinas)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Rutinas__Id_Clie__3D5E1FD2");
        });

        modelBuilder.Entity<Suscripcione>(entity =>
        {
            entity.HasKey(e => e.IdSuscripcion).HasName("PK__Suscripc__C0583DB0648A19CB");

            entity.Property(e => e.IdSuscripcion).HasColumnName("Id_Suscripcion");
            entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");
            entity.Property(e => e.IdEstadoSuscripcion).HasColumnName("Id_EstadoSuscripcion");
            entity.Property(e => e.IdPlan).HasColumnName("Id_Plan");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Suscripciones)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Suscripci__Id_Cl__4F7CD00D");

            entity.HasOne(d => d.IdEstadoSuscripcionNavigation).WithMany(p => p.Suscripciones)
                .HasForeignKey(d => d.IdEstadoSuscripcion)
                .HasConstraintName("FK__Suscripci__Id_Es__5165187F");

            entity.HasOne(d => d.IdPlanNavigation).WithMany(p => p.Suscripciones)
                .HasForeignKey(d => d.IdPlan)
                .HasConstraintName("FK__Suscripci__Id_Pl__5070F446");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
