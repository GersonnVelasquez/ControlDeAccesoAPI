using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ControlAccesoBackEnd.Controllers
{
    public class LoginController : ApiController
    {
        Data DB = new Data();
        // GET: api/Login
        [Route("api/Login/{User}/{Password}")]
        public IHttpActionResult Get(string User, string Password)
        {
            Usuario usuario = DB.Usuario.Where(i => i.usuario1 == User).FirstOrDefault();
            if (usuario != null)
            {
                if (usuario.contrasena == Password)
                {
                    return Ok(usuario);
                }
            }
            return Ok(false);
        }
        
    }
}
