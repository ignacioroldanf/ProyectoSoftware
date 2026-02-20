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

    public virtual DbSet<Accione> Acciones { get; set; }

    public virtual DbSet<Clase> Clases { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DiasRutina> DiasRutinas { get; set; }

    public virtual DbSet<DiasSemana> DiasSemanas { get; set; }

    public virtual DbSet<Ejercicio> Ejercicios { get; set; }

    public virtual DbSet<EjerciciosAsignado> EjerciciosAsignados { get; set; }

    public virtual DbSet<Especialidade> Especialidades { get; set; }

    public virtual DbSet<EstadoGrupo> EstadoGrupos { get; set; }

    public virtual DbSet<EstadoReserva> EstadoReservas { get; set; }

    public virtual DbSet<EstadoSuscripcion> EstadoSuscripcions { get; set; }

    public virtual DbSet<EstadoUsuario> EstadoUsuarios { get; set; }

    public virtual DbSet<Formulario> Formularios { get; set; }

    public virtual DbSet<Grupo> Grupos { get; set; }

    public virtual DbSet<HorarioClase> HorarioClases { get; set; }

    public virtual DbSet<Modulo> Modulos { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Plane> Planes { get; set; }

    public virtual DbSet<Profesore> Profesores { get; set; }

    public virtual DbSet<Progreso> Progresos { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<ReservaIndividual> ReservaIndividuals { get; set; }

    public virtual DbSet<ReservaRecurrente> ReservaRecurrentes { get; set; }

    public virtual DbSet<Rutina> Rutinas { get; set; }

    public virtual DbSet<Suscripcione> Suscripciones { get; set; }

    public virtual DbSet<TipoRecurrencium> TipoRecurrencia { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LegionNachi\\SQLSERVER; Database=Diploma; Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Accione>(entity =>
        {
            entity.HasKey(e => e.IdAccion).HasName("PK__Acciones__7BB9ED82E7D8E6C0");

            entity.Property(e => e.IdAccion).HasColumnName("Id_Accion");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IdFormulario).HasColumnName("Id_Formulario");
            entity.Property(e => e.NombreAccion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nombre_Accion");

            entity.HasOne(d => d.IdFormularioNavigation).WithMany(p => p.Acciones)
                .HasForeignKey(d => d.IdFormulario)
                .HasConstraintName("FK__Acciones__Id_For__787EE5A0");
        });

        modelBuilder.Entity<Clase>(entity =>
        {
            entity.HasKey(e => e.IdClase).HasName("PK__Clases__E30692F0F029CE5C");

            entity.Property(e => e.IdClase).HasColumnName("Id_Clase");
            entity.Property(e => e.CupoMaximo).HasColumnName("Cupo_Maximo");
            entity.Property(e => e.DescripcionClase)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Descripcion_Clase");
            entity.Property(e => e.IdProfesor).HasColumnName("Id_Profesor");
            entity.Property(e => e.NombreClase)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nombre_Clase");

            entity.HasOne(d => d.IdProfesorNavigation).WithMany(p => p.Clases)
                .HasForeignKey(d => d.IdProfesor)
                .HasConstraintName("FK__Clases__Id_Profe__1BC821DD");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Clientes__3DD0A8CB938D70B5");

            entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");
            entity.Property(e => e.FechaAlta).HasColumnName("Fecha_Alta");
            entity.Property(e => e.IdPersona).HasColumnName("Id_Persona");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("FK__Clientes__Id_Per__0D7A0286");
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

        modelBuilder.Entity<DiasSemana>(entity =>
        {
            entity.HasKey(e => e.IdDiaSemana).HasName("PK__DiasSema__4522D08ECF41F55F");

            entity.ToTable("DiasSemana");

            entity.Property(e => e.IdDiaSemana)
                .ValueGeneratedNever()
                .HasColumnName("Id_DiaSemana");
            entity.Property(e => e.NombreDia)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Nombre_Dia");
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

        modelBuilder.Entity<Especialidade>(entity =>
        {
            entity.HasKey(e => e.IdEspecialidad).HasName("PK__Especial__9B7935BFD9EC3342");

            entity.Property(e => e.IdEspecialidad).HasColumnName("Id_Especialidad");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EstadoGrupo>(entity =>
        {
            entity.HasKey(e => e.IdEstadoGrupo).HasName("PK__EstadoGr__262ECE8061570C00");

            entity.ToTable("EstadoGrupo");

            entity.Property(e => e.IdEstadoGrupo)
                .ValueGeneratedNever()
                .HasColumnName("Id_EstadoGrupo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EstadoReserva>(entity =>
        {
            entity.HasKey(e => e.IdEstadoReserva).HasName("PK__EstadoRe__F45B971A10DB9C79");

            entity.ToTable("EstadoReserva");

            entity.Property(e => e.IdEstadoReserva).HasColumnName("Id_EstadoReserva");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
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

        modelBuilder.Entity<EstadoUsuario>(entity =>
        {
            entity.HasKey(e => e.IdEstadoUsuario).HasName("PK__EstadoUs__BD86BE7465521879");

            entity.ToTable("EstadoUsuario");

            entity.Property(e => e.IdEstadoUsuario)
                .ValueGeneratedNever()
                .HasColumnName("Id_EstadoUsuario");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Formulario>(entity =>
        {
            entity.HasKey(e => e.IdFormulario).HasName("PK__Formular__0F1D3F13C2145FAA");

            entity.Property(e => e.IdFormulario).HasColumnName("Id_Formulario");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IdModulo).HasColumnName("Id_Modulo");
            entity.Property(e => e.NombreFormulario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nombre_Formulario");

            entity.HasOne(d => d.IdModuloNavigation).WithMany(p => p.Formularios)
                .HasForeignKey(d => d.IdModulo)
                .HasConstraintName("FK__Formulari__Id_Mo__75A278F5");
        });

        modelBuilder.Entity<Grupo>(entity =>
        {
            entity.HasKey(e => e.IdGrupo).HasName("PK__Grupos__ACDDD9781A55823F");

            entity.Property(e => e.IdGrupo).HasColumnName("Id_Grupo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IdEstadoGrupo).HasColumnName("Id_EstadoGrupo");
            entity.Property(e => e.NombreGrupo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nombre_Grupo");

            entity.HasOne(d => d.IdEstadoGrupoNavigation).WithMany(p => p.Grupos)
                .HasForeignKey(d => d.IdEstadoGrupo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Grupos__Id_Estad__7B5B524B");

            entity.HasMany(d => d.IdAccions).WithMany(p => p.IdGrupos)
                .UsingEntity<Dictionary<string, object>>(
                    "GruposAccione",
                    r => r.HasOne<Accione>().WithMany()
                        .HasForeignKey("IdAccion")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Grupos_Ac__Id_Ac__02FC7413"),
                    l => l.HasOne<Grupo>().WithMany()
                        .HasForeignKey("IdGrupo")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Grupos_Ac__Id_Gr__02084FDA"),
                    j =>
                    {
                        j.HasKey("IdGrupo", "IdAccion").HasName("PK__Grupos_A__9B6647A002729A6E");
                        j.ToTable("Grupos_Acciones");
                        j.IndexerProperty<int>("IdGrupo").HasColumnName("Id_Grupo");
                        j.IndexerProperty<int>("IdAccion").HasColumnName("Id_Accion");
                    });
        });

        modelBuilder.Entity<HorarioClase>(entity =>
        {
            entity.HasKey(e => e.IdHorarioClase).HasName("PK__HorarioC__8715BCB8B2434832");

            entity.ToTable("HorarioClase");

            entity.Property(e => e.IdHorarioClase).HasColumnName("Id_HorarioClase");
            entity.Property(e => e.HoraFin).HasColumnName("Hora_Fin");
            entity.Property(e => e.HoraInicio).HasColumnName("Hora_Inicio");
            entity.Property(e => e.IdClase).HasColumnName("Id_Clase");
            entity.Property(e => e.IdDiaSemana).HasColumnName("Id_DiaSemana");

            entity.HasOne(d => d.IdClaseNavigation).WithMany(p => p.HorarioClases)
                .HasForeignKey(d => d.IdClase)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HorarioCl__Id_Cl__1EA48E88");

            entity.HasOne(d => d.IdDiaSemanaNavigation).WithMany(p => p.HorarioClases)
                .HasForeignKey(d => d.IdDiaSemana)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HorarioCl__Id_Di__1F98B2C1");
        });

        modelBuilder.Entity<Modulo>(entity =>
        {
            entity.HasKey(e => e.IdModulo).HasName("PK__Modulos__C11E1F33BA513445");

            entity.Property(e => e.IdModulo).HasColumnName("Id_Modulo");
            entity.Property(e => e.NombreModulo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nombre_Modulo");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("PK__Personas__C95634AF2C88017D");

            entity.HasIndex(e => e.Email, "UQ__Personas__A9D10534AADDB3EB").IsUnique();

            entity.Property(e => e.IdPersona).HasColumnName("Id_Persona");
            entity.Property(e => e.Apellido).HasMaxLength(50);
            entity.Property(e => e.Dni).HasColumnName("DNI");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(50);
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

        modelBuilder.Entity<Profesore>(entity =>
        {
            entity.HasKey(e => e.IdProfesor).HasName("PK__Profesor__45D4152A910C9782");

            entity.Property(e => e.IdProfesor).HasColumnName("Id_Profesor");
            entity.Property(e => e.IdPersona).HasColumnName("Id_Persona");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Profesores)
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Profesore__Id_Pe__1332DBDC");

            entity.HasMany(d => d.IdEspecialidads).WithMany(p => p.IdProfesors)
                .UsingEntity<Dictionary<string, object>>(
                    "ProfesoresEspecialidade",
                    r => r.HasOne<Especialidade>().WithMany()
                        .HasForeignKey("IdEspecialidad")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Profesore__Id_Es__17036CC0"),
                    l => l.HasOne<Profesore>().WithMany()
                        .HasForeignKey("IdProfesor")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Profesore__Id_Pr__160F4887"),
                    j =>
                    {
                        j.HasKey("IdProfesor", "IdEspecialidad").HasName("PK__Profesor__AC638671339A7F7C");
                        j.ToTable("Profesores_Especialidades");
                        j.IndexerProperty<int>("IdProfesor").HasColumnName("Id_Profesor");
                        j.IndexerProperty<int>("IdEspecialidad").HasColumnName("Id_Especialidad");
                    });
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

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.IdReserva).HasName("PK__Reservas__9E953BE1EC5FA04C");

            entity.Property(e => e.IdReserva).HasColumnName("Id_Reserva");
            entity.Property(e => e.FechaAlta)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Alta");
            entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");
            entity.Property(e => e.IdEstadoReserva).HasColumnName("Id_EstadoReserva");
            entity.Property(e => e.IdReservaPadre).HasColumnName("Id_ReservaPadre");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservas__Id_Cli__2BFE89A6");

            entity.HasOne(d => d.IdEstadoReservaNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdEstadoReserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservas__Id_Est__2CF2ADDF");

            entity.HasOne(d => d.IdReservaPadreNavigation).WithMany(p => p.InverseIdReservaPadreNavigation)
                .HasForeignKey(d => d.IdReservaPadre)
                .HasConstraintName("FK_Reservas_Reservas_Padre");
        });

        modelBuilder.Entity<ReservaIndividual>(entity =>
        {
            entity.HasKey(e => e.IdReserva).HasName("PK__ReservaI__9E953BE1DD06ED2C");

            entity.ToTable("ReservaIndividual");

            entity.Property(e => e.IdReserva)
                .ValueGeneratedNever()
                .HasColumnName("Id_Reserva");
            entity.Property(e => e.FechaReserva).HasColumnName("Fecha_Reserva");
            entity.Property(e => e.IdHorarioClase).HasColumnName("Id_HorarioClase");

            entity.HasOne(d => d.IdHorarioClaseNavigation).WithMany(p => p.ReservaIndividuals)
                .HasForeignKey(d => d.IdHorarioClase)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ReservaIn__Id_Ho__30C33EC3");

            entity.HasOne(d => d.IdReservaNavigation).WithOne(p => p.ReservaIndividual)
                .HasForeignKey<ReservaIndividual>(d => d.IdReserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ReservaIn__Id_Re__2FCF1A8A");
        });

        modelBuilder.Entity<ReservaRecurrente>(entity =>
        {
            entity.HasKey(e => e.IdReserva).HasName("PK__ReservaR__9E953BE15C5F3344");

            entity.ToTable("ReservaRecurrente");

            entity.Property(e => e.IdReserva)
                .ValueGeneratedNever()
                .HasColumnName("Id_Reserva");
            entity.Property(e => e.IdHorarioClase).HasColumnName("Id_HorarioClase");
            entity.Property(e => e.IdTipoRecurrencia).HasColumnName("Id_TipoRecurrencia");

            entity.HasOne(d => d.IdHorarioClaseNavigation).WithMany(p => p.ReservaRecurrentes)
                .HasForeignKey(d => d.IdHorarioClase)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ReservaRe__Id_Ho__3B40CD36");

            entity.HasOne(d => d.IdReservaNavigation).WithOne(p => p.ReservaRecurrente)
                .HasForeignKey<ReservaRecurrente>(d => d.IdReserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ReservaRe__Id_Re__3A4CA8FD");

            entity.HasOne(d => d.IdTipoRecurrenciaNavigation).WithMany(p => p.ReservaRecurrentes)
                .HasForeignKey(d => d.IdTipoRecurrencia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ReservaRe__Id_Ti__3C34F16F");
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

        modelBuilder.Entity<TipoRecurrencium>(entity =>
        {
            entity.HasKey(e => e.IdTipoRecurrencia).HasName("PK__TipoRecu__E0831CD0D012BBB7");

            entity.Property(e => e.IdTipoRecurrencia).HasColumnName("Id_TipoRecurrencia");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__63C76BE25614DDFA");

            entity.HasIndex(e => e.NombreUsuario, "UQ__Usuarios__57A4BD1970D88A2A").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");
            entity.Property(e => e.ClaveUsuario)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Clave_Usuario");
            entity.Property(e => e.ExpiracionToken)
                .HasColumnType("datetime")
                .HasColumnName("Expiracion_Token");
            entity.Property(e => e.IdEstadoUsuario).HasColumnName("Id_EstadoUsuario");
            entity.Property(e => e.IdPersona).HasColumnName("Id_Persona");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nombre_Usuario");
            entity.Property(e => e.TokenRecuperacion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Token_Recuperacion");

            entity.HasOne(d => d.IdEstadoUsuarioNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdEstadoUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuarios__Id_Est__7F2BE32F");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("FK__Usuarios__Id_Per__0E6E26BF");

            entity.HasMany(d => d.IdAccions).WithMany(p => p.IdUsuarios)
                .UsingEntity<Dictionary<string, object>>(
                    "UsuariosAccione",
                    r => r.HasOne<Accione>().WithMany()
                        .HasForeignKey("IdAccion")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Usuarios___Id_Ac__0A9D95DB"),
                    l => l.HasOne<Usuario>().WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Usuarios___Id_Us__09A971A2"),
                    j =>
                    {
                        j.HasKey("IdUsuario", "IdAccion").HasName("PK__Usuarios__547CF53A67BDC9D2");
                        j.ToTable("Usuarios_Acciones");
                        j.IndexerProperty<int>("IdUsuario").HasColumnName("Id_Usuario");
                        j.IndexerProperty<int>("IdAccion").HasColumnName("Id_Accion");
                    });

            entity.HasMany(d => d.IdGrupos).WithMany(p => p.IdUsuarios)
                .UsingEntity<Dictionary<string, object>>(
                    "UsuariosGrupo",
                    r => r.HasOne<Grupo>().WithMany()
                        .HasForeignKey("IdGrupo")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Usuarios___Id_Gr__06CD04F7"),
                    l => l.HasOne<Usuario>().WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Usuarios___Id_Us__05D8E0BE"),
                    j =>
                    {
                        j.HasKey("IdUsuario", "IdGrupo").HasName("PK__Usuarios__F90AB6757D89509A");
                        j.ToTable("Usuarios_Grupos");
                        j.IndexerProperty<int>("IdUsuario").HasColumnName("Id_Usuario");
                        j.IndexerProperty<int>("IdGrupo").HasColumnName("Id_Grupo");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
