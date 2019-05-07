using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
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
            try
            {
                var empresa = DB.Empresa.ToList().Select(i => new
                {
                    i.nombre,
                    i.id_empresa,
                    logo = toStream(i.logo)
                });

               
                 return Ok(empresa); ;
            }
            catch (Exception r)
            {
                return NotFound();
            }
        }

     
        public Stream toStream(byte[] array)
        {
            if(array != null)
            {
                MemoryStream st = new MemoryStream(array);
                return st;
            }
            return null;
           
        }

        [HttpPost]
        [Route("api/Empresas/insert/")]
        public IHttpActionResult post()
        {


            Empresa n = new Empresa
            {
                nombre = HttpContext.Current.Request.Form["nombre"],
                logo = ToByteArray(HttpContext.Current.Request.Files["logo"].InputStream)
            };


            DB.Empresa.Add(n);
            DB.SaveChanges();
            return Ok();
        }

        public byte[] ToByteArray(Stream stream)
        {
            stream.Position = 0;
            byte[] buffer = new byte[stream.Length];
            for (int totalBytesCopied = 0; totalBytesCopied < stream.Length;)
                totalBytesCopied += stream.Read(buffer, totalBytesCopied, Convert.ToInt32(stream.Length) - totalBytesCopied);
            return buffer;
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
