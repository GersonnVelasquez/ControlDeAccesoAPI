namespace ControlAccesoBackEnd
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Rol")]
    public partial class Rol
    {
        [Key]
        public int id_rol { get; set; }

        [Required]
        [StringLength(30)]
        public string descripcion { get; set; }
    }
}
