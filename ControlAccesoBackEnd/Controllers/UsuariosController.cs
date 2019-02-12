using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ControlAccesoBackEnd.Controllers
{
    public class UsuariosController : ApiController
    {
        Data DB = new Data();

        [HttpGet]
        [Route("api/Usuarios/select/")]
        public IHttpActionResult Get()
        {
            return Ok(DB.Usuario.ToList());
        }

   
        [HttpPost]
        [Route("api/Usuarios/insert/")]
        public IHttpActionResult post(Usuario n)
        {
            DB.Usuario.Add(n);
            DB.SaveChanges();
            return Ok();
        }


        [HttpPut]
        [Route("api/Usuarios/update/")]
        public IHttpActionResult Update(Usuario n)
        {
            
            return Ok();
        }


        [HttpDelete]
        [Route("api/Usuarios/delete/")]
        public IHttpActionResult Delete(Usuario n)
        {
            DB.Usuario.Remove(n);
            DB.SaveChanges();
            return Ok();
        }

    }
}
