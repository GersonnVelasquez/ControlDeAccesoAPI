using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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
                    i.nombreimg,
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
            if (array != null)
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
                logo = ToByteArray(HttpContext.Current.Request.Files["logo"].InputStream),
                nombreimg = HttpContext.Current.Request.Form["nombreimg"]

            };

            //using (System.IO.FileStream output = new System.IO.FileStream(@"C:\Users\Naomy_Rios\Desktop\MyOutput.jpg", FileMode.Create))
            //{
            //    HttpContext.Current.Request.Files["logo"].InputStream.CopyTo(output);
            //}
            //string NombreIMG = HttpContext.Current.Request.Form["nombreimg"];

            //Image img = System.Drawing.Image.FromStream(HttpContext.Current.Request.Files["logo"].InputStream);

            //img.Save(@"C:\Users\Naomy_Rios\Documents\GitHub\ControlDeAcceso\src\assets\logos\" + NombreIMG);


            DB.Empresa.Add(n);
            DB.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("api/Empresas/prueba/")]
        public IHttpActionResult Getprueba() { 
        
            return Ok("funciona");
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
        [Route("api/Empresas/insert/logo/")]
        public IHttpActionResult postLogo(byte [] logo, string nombreimg)
        {
            //byte[]

            var l = logo;
            var n = nombreimg;
           
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
