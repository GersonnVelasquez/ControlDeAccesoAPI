namespace ControlAccesoBackEnd
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Modulo_Detalle
    {
        [Key]
        public int id_modulo_detalle { get; set; }

        public int id_modulo { get; set; }

        public int id_rol { get; set; }
    }
}
