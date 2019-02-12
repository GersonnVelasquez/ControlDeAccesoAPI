namespace ControlAccesoBackEnd
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuario")]
    public partial class Usuario
    {
        [Key]
        public int id_usuario { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        [Column("usuario")]
        [Required]
        [StringLength(25)]
        public string usuario1 { get; set; }

        [Required]
        [StringLength(20)]
        public string contrasena { get; set; }

        [Required]
        [StringLength(50)]
        public string correo { get; set; }

        public int id_rol { get; set; }

        public int id_empresa { get; set; }
    }
}
