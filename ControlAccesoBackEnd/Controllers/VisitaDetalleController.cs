using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using System.Web;

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

        [HttpGet]
        [Route("api/Visita_Detalle/select/idVisita/{idvisita:int}")]
        public IHttpActionResult GetbyIdVisita(int idvisita)
        {
            var personas = (from visitadetalle in DB.Visita_Detalle
                           join persona in DB.Persona
                           on visitadetalle.id_persona equals persona.id_persona
                           where visitadetalle.id_visita == idvisita
                           select new
                           {
                               IdVisitaDetalle = visitadetalle.id_visita_detalle,
                               Nombre = persona.nombre,
                               HoraEntrada = visitadetalle.hr_entrada,
                               HoraSalida = visitadetalle.hr_salida,
                               NoCarnet = visitadetalle.n_carnet,
                               Observaciones = visitadetalle.observaciones,
                               
                                
                           }).ToList();


            return Ok(personas);
        }

        public Stream toStream(byte[] array)
        {
            if (array != null)
            {
                MemoryStream st = new MemoryStream(array);
                return st;
            }
            return null;

        }

        public byte[] ToByteArray(Stream stream)
        {
            stream.Position = 0;
            byte[] buffer = new byte[stream.Length];
            for (int totalBytesCopied = 0; totalBytesCopied < stream.Length;)
                totalBytesCopied += stream.Read(buffer, totalBytesCopied, Convert.ToInt32(stream.Length) - totalBytesCopied);
            return buffer;
        }

        [HttpPost]
        [Route("api/Visita_Detalle/Adjunto/")]
        public IHttpActionResult Adjunto()
        {
            string NombreArchivo = HttpContext.Current.Request.Form["Nombre_Adjunto"];
            if (NombreArchivo != null)
            {
                using (FileStream output = new FileStream(@"C:\Adjuntos\" + NombreArchivo, FileMode.Create))
                {
                    HttpContext.Current.Request.Files["Adjunto"].InputStream.CopyTo(output);
                }
            }

            return Ok();
        }

        [HttpPost]
        [Route("api/Visita_Detalle/insert/")]
        public IHttpActionResult post(Visita_Detalle n) {

           // n.nombre_adjunto = HttpContext.Current.Request.Form["Nombre_Adjunto"];

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
