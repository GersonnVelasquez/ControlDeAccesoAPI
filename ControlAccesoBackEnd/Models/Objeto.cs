namespace ControlAccesoBackEnd
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Objeto")]
    public partial class Objeto
    {
        [Key]
        public int id_objeto { get; set; }

        public int id_visita { get; set; }

        [Required]
        [StringLength(50)]
        public string descripcion { get; set; }

        public int cantidad { get; set; }

        [StringLength(50)]
        public string comentario { get; set; }
    }
}
