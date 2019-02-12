namespace ControlAccesoBackEnd
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Permiso_Trabajo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Permiso_Trabajo()
        {
            Herramienta = new HashSet<Herramienta>();
            Permiso_Trabajo_Detalle = new HashSet<Permiso_Trabajo_Detalle>();
            Visita = new HashSet<Visita>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_permiso_trabajo { get; set; }

        public int? id_usuario { get; set; }

        public int? id_persona { get; set; }

        public int? id_empresa { get; set; }

        public DateTime fecha_creacion { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecha_desde { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecha_hasta { get; set; }

        [StringLength(20)]
        public string horario { get; set; }

        [StringLength(20)]
        public string tipo_trabajo { get; set; }

        [StringLength(30)]
        public string empresa_nombre { get; set; }

        [StringLength(100)]
        public string descripcion_trabajo { get; set; }

        [StringLength(150)]
        public string epp { get; set; }

        [StringLength(100)]
        public string desecho { get; set; }

        public virtual Empresa Empresa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Herramienta> Herramienta { get; set; }

        public virtual Persona Persona { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Permiso_Trabajo_Detalle> Permiso_Trabajo_Detalle { get; set; }

        public virtual Usuario Usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Visita> Visita { get; set; }
    }
}
