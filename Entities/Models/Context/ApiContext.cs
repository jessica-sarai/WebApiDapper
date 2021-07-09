using Entities.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace Entities.Models.Context
{
    public partial class ApiContext : DbContext
    {
        public ApiContext()
        {
        }

        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumnos> Alumnos { get; set; }
        public virtual DbSet<AlumnosBaja> AlumnosBaja { get; set; }
        public virtual DbSet<CatCursos> CatCursos { get; set; }
        public virtual DbSet<CursoInstructores> CursoInstructores { get; set; }
        public virtual DbSet<Cursos> Cursos { get; set; }
        public virtual DbSet<CursosAlumnos> CursosAlumnos { get; set; }
        public virtual DbSet<Estados> Estados { get; set; }
        public virtual DbSet<EstatusAlumnos> EstatusAlumnos { get; set; }
        public virtual DbSet<Instructores> Instructores { get; set; }
        public virtual DbSet<Saldos> Saldos { get; set; }
        public virtual DbSet<Transacciones> Transacciones { get; set; }
        public virtual DbSet<VAlumnos> VAlumnos { get; set; }
        public virtual DbSet<VistaAlumnos> VistaAlumnos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=PruebasTich;User Id=sa;Password=Pass2017;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumnos>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasColumnName("correo")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Curp)
                    .IsRequired()
                    .HasColumnName("curp")
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnName("fechaNacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.IdEstadoOrigen).HasColumnName("idEstadoOrigen");

                entity.Property(e => e.IdEstatus).HasColumnName("idEstatus");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerApellido)
                    .IsRequired()
                    .HasColumnName("primerApellido")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoApellido)
                    .HasColumnName("segundoApellido")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasColumnName("telefono")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.IdEstadoOrigenNavigation)
                    .WithMany(p => p.Alumnos)
                    .HasForeignKey(d => d.IdEstadoOrigen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Alumnos_Estados");

                entity.HasOne(d => d.IdEstatusNavigation)
                    .WithMany(p => p.Alumnos)
                    .HasForeignKey(d => d.IdEstatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Alumnos_EstatusAlumnos");
            });

            modelBuilder.Entity<AlumnosBaja>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FechaBaja)
                    .HasColumnName("fechaBaja")
                    .HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerApellido)
                    .IsRequired()
                    .HasColumnName("primerApellido")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoApellido)
                    .HasColumnName("segundoApellido")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CatCursos>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasColumnName("clave")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Horas).HasColumnName("horas");

                entity.Property(e => e.IdPreRequisito).HasColumnName("idPreRequisito");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPreRequisitoNavigation)
                    .WithMany(p => p.InverseIdPreRequisitoNavigation)
                    .HasForeignKey(d => d.IdPreRequisito)
                    .HasConstraintName("FK_CatCursos_CatCursos");
            });

            modelBuilder.Entity<CursoInstructores>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FechaContratación)
                    .HasColumnName("fechaContratación")
                    .HasColumnType("date");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.IdInstructor).HasColumnName("idInstructor");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.CursoInstructores)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CursoInstructores_Cursos");

                entity.HasOne(d => d.IdInstructorNavigation)
                    .WithMany(p => p.CursoInstructores)
                    .HasForeignKey(d => d.IdInstructor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CursoInstructores_Instructor");
            });

            modelBuilder.Entity<Cursos>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.FechaInicio)
                    .HasColumnName("fechaInicio")
                    .HasColumnType("date");

                entity.Property(e => e.FechaTermino)
                    .HasColumnName("fechaTermino")
                    .HasColumnType("date");

                entity.Property(e => e.IdCatCurso).HasColumnName("idCatCurso");

                entity.HasOne(d => d.IdCatCursoNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.IdCatCurso)
                    .HasConstraintName("FK_Cursos_CatCursos");
            });

            modelBuilder.Entity<CursosAlumnos>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Calificacion).HasColumnName("calificacion");

                entity.Property(e => e.FechaBaja)
                    .HasColumnName("fechaBaja")
                    .HasColumnType("date");

                entity.Property(e => e.FechaInsripcion)
                    .HasColumnName("fechaInsripcion")
                    .HasColumnType("date");

                entity.Property(e => e.IdAlumno).HasColumnName("idAlumno");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.HasOne(d => d.IdAlumnoNavigation)
                    .WithMany(p => p.CursosAlumnos)
                    .HasForeignKey(d => d.IdAlumno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CursosAlumnos_Alumnos");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.CursosAlumnos)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CursosAlumnos_Curso");
            });

            modelBuilder.Entity<Estados>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstatusAlumnos>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Clave)
                    .HasColumnName("clave")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Instructores>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasColumnName("correo")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Cuota)
                    .HasColumnName("cuota")
                    .HasColumnType("decimal(9, 2)");

                entity.Property(e => e.Curp)
                    .IsRequired()
                    .HasColumnName("curp")
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnName("fechaNacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerApellido)
                    .IsRequired()
                    .HasColumnName("primerApellido")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rfc)
                    .IsRequired()
                    .HasColumnName("rfc")
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SegundoApellido)
                    .HasColumnName("segundoApellido")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasColumnName("telefono")
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Saldos>(entity =>
            {
                entity.ToTable("saldos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Saldo).HasColumnName("saldo");
            });

            modelBuilder.Entity<Transacciones>(entity =>
            {
                entity.ToTable("transacciones");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdDestino).HasColumnName("idDestino");

                entity.Property(e => e.IdOrigen).HasColumnName("idOrigen");

                entity.Property(e => e.Monto).HasColumnName("monto");

                entity.HasOne(d => d.IdDestinoNavigation)
                    .WithMany(p => p.TransaccionesIdDestinoNavigation)
                    .HasForeignKey(d => d.IdDestino)
                    .HasConstraintName("FK_transaccionesDestino");

                entity.HasOne(d => d.IdOrigenNavigation)
                    .WithMany(p => p.TransaccionesIdOrigenNavigation)
                    .HasForeignKey(d => d.IdOrigen)
                    .HasConstraintName("FK_transaccionesOrigen");
            });

            modelBuilder.Entity<VAlumnos>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vAlumnos");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasColumnName("correo")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Curp)
                    .IsRequired()
                    .HasColumnName("curp")
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Estatus)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerApellido)
                    .IsRequired()
                    .HasColumnName("primerApellido")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoApellido)
                    .HasColumnName("segundoApellido")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasColumnName("telefono")
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<VistaAlumnos>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VistaAlumnos");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasColumnName("correo")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Curp)
                    .IsRequired()
                    .HasColumnName("curp")
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Estatus)
                    .HasColumnName("estatus")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnName("fechaNacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerApellido)
                    .IsRequired()
                    .HasColumnName("primerApellido")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoApellido)
                    .HasColumnName("segundoApellido")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasColumnName("telefono")
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
