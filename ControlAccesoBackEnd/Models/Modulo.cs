namespace ControlAccesoBackEnd
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Modulo")]
    public partial class Modulo
    {
        [Key]
        public int id_modulo { get; set; }

        [Required]
        [StringLength(30)]
        public string descripcion { get; set; }
    }
}
