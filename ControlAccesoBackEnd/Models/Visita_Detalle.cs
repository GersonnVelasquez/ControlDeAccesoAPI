namespace ControlAccesoBackEnd
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Visita_Detalle
    {
        [Key]
        public int id_visita_detalle { get; set; }

        public int id_visita { get; set; }

        public int id_persona { get; set; }

        public TimeSpan? hr_entrada { get; set; }

        public TimeSpan? hr_salida { get; set; }

        public int? n_carnet { get; set; }

        [StringLength(100)]
        public string observaciones { get; set; }

    }
}
