using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ControlAccesoBackEnd.Controllers
{
    public class VisitaDetalleController : ApiController
    {
        Data DB = new Data();

        [HttpGet]
        [Route("api/Visita_Detalle/select/")]
        public IHttpActionResult Get()
        {
            return Ok(DB.Visita_Detalle.ToList());
        }


        [HttpPost]
        [Route("api/Visita_Detalle/insert/")]
        public IHttpActionResult post(Visita_Detalle n)
        {
            DB.Visita_Detalle.Add(n);
            DB.SaveChanges();
            return Ok();
        }


        [HttpPut]
        [Route("api/Visita_Detalle/update/")]
        public IHttpActionResult Update(Visita_Detalle n)
        {

            return Ok();
        }


        [HttpDelete]
        [Route("api/Visita_Detalle/delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            DB.Visita_Detalle.Remove(DB.Visita_Detalle.Find(id));
            DB.SaveChanges();
            return Ok();
        }
    }
}
