namespace ControlAccesoBackEnd
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Empresa")]
    public partial class Empresa
    {
        [Key]
        public int id_empresa { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        [StringLength(50)]
        public string nombreimg { get; set; }

        [Column(TypeName = "image")]
        public byte[] logo { get; set; }
    }
}
