using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ControlAccesoBackEnd.Controllers
{
    public class EmpresasController : ApiController
    {
        Data DB = new Data();

        [HttpGet]
        [Route("api/Empresas/select/")]
        public IHttpActionResult Get()
        {
            return Ok(DB.Empresa.ToList());
        }


        [HttpPost]
        [Route("api/Empresas/insert/")]
        public IHttpActionResult post(Empresa n)
        {
            DB.Empresa.Add(n);
            DB.SaveChanges();
            return Ok();
        }


        [HttpPost]
        [Route("api/Empresas/insert/logo/")]
        public IHttpActionResult postLogo(byte[] logo)
        {

            var l = logo;
           
            return Ok();
        }

        [HttpPut]
        [Route("api/Empresas/update/")]
        public IHttpActionResult Update(Empresa n)
        {

            return Ok();
        }


        [HttpDelete]
        [Route("api/Empresas/delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            DB.Empresa.Remove(DB.Empresa.Find(id));
            DB.SaveChanges();
            return Ok();
        }
    }
}
