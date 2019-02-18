using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ControlAccesoBackEnd.Controllers
{
    public class RolesController : ApiController
    {
        Data DB = new Data();

        [HttpGet]
        [Route("api/Roles/select/")]
        public IHttpActionResult Get()
        {
            return Ok(DB.Rol.ToList());
        }


        [HttpPost]
        [Route("api/Roles/insert/")]
        public IHttpActionResult post(Rol n)
        {
            DB.Rol.Add(n);
            DB.SaveChanges();
            return Ok();
        }


        [HttpPut]
        [Route("api/Roles/update/")]
        public IHttpActionResult Update(Usuario n)
        {

            return Ok();
        }


        [HttpDelete]
        [Route("api/Roles/delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            DB.Rol.Remove(DB.Rol.Find(id));
            DB.SaveChanges();
            return Ok();
        }
    }
}
