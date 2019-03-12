using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlAccesoBackEnd
{
    public class VisitaUpdated
    {
        public bool isFinal { get; set; }
        public Visita_Detalle[] visita_detalle { get; set; }
        public Objeto[] objetos { get; set; }
    }
}