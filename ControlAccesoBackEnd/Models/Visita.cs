namespace ControlAccesoBackEnd
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Visita")]
    public partial class Visita
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Visita()
        {
            Objeto = new HashSet<Objeto>();
            Visita_Detalle = new HashSet<Visita_Detalle>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_visita { get; set; }

        [Required]
        [StringLength(30)]
        public string tipo_visita { get; set; }

        public int? id_usuario { get; set; }

        public int? id_empresa { get; set; }

        [Required]
        [StringLength(50)]
        public string empresa_procedencia { get; set; }

        public DateTime fecha_creacion { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecha_visita { get; set; }

        public int? id_permiso_trabajo { get; set; }

        public virtual Empresa Empresa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Objeto> Objeto { get; set; }

        public virtual Permiso_Trabajo Permiso_Trabajo { get; set; }

        public virtual Usuario Usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Visita_Detalle> Visita_Detalle { get; set; }
    }
}
