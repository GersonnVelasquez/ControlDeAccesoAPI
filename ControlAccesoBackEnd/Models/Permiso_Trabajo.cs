namespace ControlAccesoBackEnd
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Permiso_Trabajo
    {
        [Key]
        public int id_permiso_trabajo { get; set; }

        public int id_usuario { get; set; }

        public int id_persona { get; set; }

        public int id_empresa { get; set; }

        public DateTime fecha_creacion { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecha_desde { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecha_hasta { get; set; }

        [Required]
        [StringLength(20)]
        public string horario { get; set; }

        [Required]
        [StringLength(20)]
        public string tipo_trabajo { get; set; }

        [Required]
        [StringLength(30)]
        public string empresa_nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string descripcion_trabajo { get; set; }

        [Required]
        [StringLength(150)]
        public string epp { get; set; }

        [Required]
        [StringLength(100)]
        public string desecho { get; set; }
    }
}
