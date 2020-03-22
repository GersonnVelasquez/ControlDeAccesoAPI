using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ControlAccesoBackEnd.Models
{
    public class ReportesController : ApiController
    {
        Data DB = new Data();
     
  
        [HttpGet]
        [Route("api/Reportes/Prueba/{Tipo}")]
        public IHttpActionResult Prueba(string Tipo)
        {
            //var TipoParametro = new SqlParameter("@tipo_visita", Tipo);

            //var data = DB.Database.SqlQuery<Object[]>("exec dbo.VisitasPorTipo @tipo_visita", TipoParametro).ToList();
            return Ok(DB.Visita.Where(i => i.id_empresa == 1025).OrderBy(i => i.tipo_visita).ToList());
          
        }
    }
}
