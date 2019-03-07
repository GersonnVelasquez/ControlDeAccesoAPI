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
        [Key]
        public int id_visita { get; set; }

        [Required]
        [StringLength(30)]
        public string tipo_visita { get; set; }

        public int id_usuario { get; set; }

        public int id_empresa { get; set; }

        [Required]
        [StringLength(50)]
        public string empresa_procedencia { get; set; }

        public DateTime fecha_creacion { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecha_visita { get; set; }

        public int? id_permiso_trabajo { get; set; }

    
        [StringLength(50)]
        public string placa_vehiculo { get; set; }

        [Required]
        [StringLength(50)]
        public string descripcion { get; set; }
    }
}
