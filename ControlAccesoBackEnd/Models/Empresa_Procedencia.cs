namespace ControlAccesoBackEnd
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Empresa_Procedencia
    {
        [Key]
        public int id_empresa_proc { get; set; }

        [Required]
        [StringLength(50)]
        public string descripcion { get; set; }
    }
}
