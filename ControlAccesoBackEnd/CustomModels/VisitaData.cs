using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlAccesoBackEnd
{
    public class VisitaData
    {
        public Visita visita { get; set; }
        public Persona[] personas { get; set; }
        public Objeto[] objetos { get; set; }

    }
}