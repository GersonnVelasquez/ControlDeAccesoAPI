using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ControlAccesoBackEnd.Controllers
{
    public class PersonaController : ApiController
    {
        Data DB = new Data();

        [HttpGet]
        [Route("api/Persona/select/")]
        public IHttpActionResult Get()
        {
            return Ok(DB.Persona.ToList());
        }


        [HttpPost]
        [Route("api/Persona/insert/")]
        public IHttpActionResult post(Persona n)
        {
            DB.Persona.Add(n);
            DB.SaveChanges();
            return Ok();
        }


        [HttpPut]
        [Route("api/Persona/update/")]
        public IHttpActionResult Update(Persona n)
        {

            return Ok();
        }


        [HttpDelete]
        [Route("api/Persona/delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            DB.Persona.Remove(DB.Persona.Find(id));
            DB.SaveChanges();
            return Ok();
        }
    }
}
