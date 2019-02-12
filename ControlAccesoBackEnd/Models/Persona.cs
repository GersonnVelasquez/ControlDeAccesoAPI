namespace ControlAccesoBackEnd
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Persona")]
    public partial class Persona
    {
        [Key]
        public int id_persona { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        [Required]
        [StringLength(15)]
        public string n_identidad { get; set; }

        [StringLength(50)]
        public string correo { get; set; }

        [StringLength(9)]
        public string telefono { get; set; }
    }
}
