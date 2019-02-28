using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ControlAccesoBackEnd.Controllers
{
    public class VisitaController : ApiController
    {
        Data DB = new Data();

        [HttpGet]
        [Route("api/Visita/select/")]
        public IHttpActionResult Get()
        {
            return Ok(DB.Visita.ToList());
        }


        [HttpPost]
        [Route("api/Visita/insert/")]
        public IHttpActionResult post(Visita n)
        {
            DB.Visita.Add(n);
            DB.SaveChanges();
            return Ok();
        }


        [HttpPut]
        [Route("api/Visita/update/")]
        public IHttpActionResult Update(Visita n)
        {

            return Ok();
        }


        [HttpDelete]
        [Route("api/Visita/delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            DB.Visita.Remove(DB.Visita.Find(id));
            DB.SaveChanges();
            return Ok();
        }
    }
}
