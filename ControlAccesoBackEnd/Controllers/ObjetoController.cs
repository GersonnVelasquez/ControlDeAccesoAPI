using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ControlAccesoBackEnd.Controllers
{
    public class ObjetoController : ApiController
    {
        Data DB = new Data();

        [HttpGet]
        [Route("api/Objeto/select/")]
        public IHttpActionResult Get()
        {
            return Ok(DB.Objeto.ToList());
        }


        [HttpGet]
        [Route("api/Objeto/select/idVisita/{idvisita:int}")]
        public IHttpActionResult GetbyIdVisita(int idvisita)
        {
            return Ok(DB.Objeto.Where(i => i.id_visita == idvisita).Select(i => new
            {
                Descripcion = i.descripcion,
                Cantidad = i.cantidad,
                Comentario = i.comentario

            }));
        }

        [HttpPost]
        [Route("api/Objeto/insert/")]
        public IHttpActionResult post(Objeto n)
        {
            DB.Objeto.Add(n);
            DB.SaveChanges();
            return Ok();
        }


        [HttpPut]
        [Route("api/Objeto/update/")]
        public IHttpActionResult Update(Objeto n)
        {

            return Ok();
        }


        [HttpDelete]
        [Route("api/Objeto/delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            DB.Objeto.Remove(DB.Objeto.Find(id));
            DB.SaveChanges();
            return Ok();
        }
    }
}
