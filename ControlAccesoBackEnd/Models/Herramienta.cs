namespace ControlAccesoBackEnd
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Herramienta")]
    public partial class Herramienta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_herramienta { get; set; }

        public int? id_permiso_trabajo { get; set; }

        [StringLength(50)]
        public string descripcion { get; set; }

        [StringLength(100)]
        public string comentario { get; set; }

        public virtual Permiso_Trabajo Permiso_Trabajo { get; set; }
    }
}
