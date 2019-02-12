namespace ControlAccesoBackEnd
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Data : DbContext
    {
        public Data()
            : base("name=Data")
        {
        }

        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Herramienta> Herramienta { get; set; }
        public virtual DbSet<Modulo> Modulo { get; set; }
        public virtual DbSet<Modulo_Detalle> Modulo_Detalle { get; set; }
        public virtual DbSet<Objeto> Objeto { get; set; }
        public virtual DbSet<Permiso_Trabajo> Permiso_Trabajo { get; set; }
        public virtual DbSet<Permiso_Trabajo_Detalle> Permiso_Trabajo_Detalle { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Visita> Visita { get; set; }
        public virtual DbSet<Visita_Detalle> Visita_Detalle { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empresa>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Herramienta>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Herramienta>()
                .Property(e => e.comentario)
                .IsUnicode(false);

            modelBuilder.Entity<Modulo>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Objeto>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Objeto>()
                .Property(e => e.comentario)
                .IsUnicode(false);

            modelBuilder.Entity<Permiso_Trabajo>()
                .Property(e => e.horario)
                .IsUnicode(false);

            modelBuilder.Entity<Permiso_Trabajo>()
                .Property(e => e.tipo_trabajo)
                .IsUnicode(false);

            modelBuilder.Entity<Permiso_Trabajo>()
                .Property(e => e.empresa_nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Permiso_Trabajo>()
                .Property(e => e.descripcion_trabajo)
                .IsUnicode(false);

            modelBuilder.Entity<Permiso_Trabajo>()
                .Property(e => e.epp)
                .IsUnicode(false);

            modelBuilder.Entity<Permiso_Trabajo>()
                .Property(e => e.desecho)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.n_identidad)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.correo)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Rol>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.usuario1)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.contrasena)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.correo)
                .IsUnicode(false);

            modelBuilder.Entity<Visita>()
                .Property(e => e.tipo_visita)
                .IsUnicode(false);

            modelBuilder.Entity<Visita>()
                .Property(e => e.empresa_procedencia)
                .IsUnicode(false);

            modelBuilder.Entity<Visita_Detalle>()
                .Property(e => e.placa_vehiculo)
                .IsUnicode(false);

            modelBuilder.Entity<Visita_Detalle>()
                .Property(e => e.observaciones)
                .IsUnicode(false);
        }
    }
}
