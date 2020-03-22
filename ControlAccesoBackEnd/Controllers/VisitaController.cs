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
    public class VisitaController : ApiController
    {
        Data DB = new Data();

        [HttpGet]
        [Route("api/Visita/select/")]
        public IHttpActionResult Get()
        {
            return Ok(DB.Visita.ToList());
        }

        [HttpGet]
        [Route("api/Visita/select/empresaId/{id:int}")]
        public IHttpActionResult GetbyEmpresaId(int id)
        {
            return Ok(DB.Visita.Where(i => i.id_empresa == id).OrderBy(i => i.tipo_visita).ToList());
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
        [Route("api/Visita/Adjunto/")]
        public IHttpActionResult AddAdjunto()
        {
            string NombreArchivo = HttpContext.Current.Request.Form["Nombre_Adjunto"];

            if (NombreArchivo != null)
            { 
                using (FileStream output = new FileStream(@"C:\Adjuntos\" + NombreArchivo , FileMode.Create))
                {
                    HttpContext.Current.Request.Files["Adjunto"].InputStream.CopyTo(output);
                }
            }
            return Ok();
        }


        [HttpPost]
        [Route("api/Visita/insert/")]
        public IHttpActionResult post(VisitaData n)
        {

            using (var dbContextTransaction = DB.Database.BeginTransaction())
            {
                try
                {
                    if (n.visita.nombre_adjunto != null)
                    {
                        Visita nuevaVisita = new Visita()
                        {
                            descripcion = n.visita.descripcion,
                            empresa_procedencia = n.visita.empresa_procedencia,
                            fecha_creacion = DateTime.Now,
                            fecha_visita = n.visita.fecha_visita,
                            id_empresa = n.visita.id_empresa,
                            id_permiso_trabajo = n.visita.id_permiso_trabajo,
                            id_usuario = n.visita.id_usuario,
                            placa_vehiculo = n.visita.placa_vehiculo,
                            tipo_visita = n.visita.tipo_visita,
                            hora_visita = n.visita.hora_visita,
                            estado = 1,
                            nombre_adjunto = n.visita.nombre_adjunto
                        };
                        DB.Visita.Add(nuevaVisita);
                        DB.SaveChanges();
                        foreach (Persona p in n.personas)
                        {
                            Visita_Detalle nuevaVisitaDetalle = new Visita_Detalle()
                            {
                                hr_entrada = null,
                                hr_salida = null,
                                id_persona = p.id_persona,
                                id_visita = nuevaVisita.id_visita,
                                n_carnet = null,
                                observaciones = null
                            };
                            DB.Visita_Detalle.Add(nuevaVisitaDetalle);
                            DB.SaveChanges();
                        }

                        foreach (Objeto o in n.objetos)
                        {
                            Objeto nuevoObjeto = new Objeto()
                            {
                                cantidad = o.cantidad,
                                comentario = o.comentario,
                                descripcion = o.descripcion,
                                id_visita = nuevaVisita.id_visita

                            };
                            DB.Objeto.Add(nuevoObjeto);
                            DB.SaveChanges();
                        }
                    }
                    else
                    {
                        Visita nuevaVisita = new Visita()
                        {
                            descripcion = n.visita.descripcion,
                            empresa_procedencia = n.visita.empresa_procedencia,
                            fecha_creacion = DateTime.Now,
                            fecha_visita = n.visita.fecha_visita,
                            id_empresa = n.visita.id_empresa,
                            id_permiso_trabajo = n.visita.id_permiso_trabajo,
                            id_usuario = n.visita.id_usuario,
                            placa_vehiculo = n.visita.placa_vehiculo,
                            tipo_visita = n.visita.tipo_visita,
                            hora_visita = n.visita.hora_visita,
                            estado = 1,
                            nombre_adjunto = null
                        };
                        DB.Visita.Add(nuevaVisita);
                        DB.SaveChanges();
                        foreach (Persona p in n.personas)
                        {
                            Visita_Detalle nuevaVisitaDetalle = new Visita_Detalle()
                            {
                                hr_entrada = null,
                                hr_salida = null,
                                id_persona = p.id_persona,
                                id_visita = nuevaVisita.id_visita,
                                n_carnet = null,
                                observaciones = null
                            };
                            DB.Visita_Detalle.Add(nuevaVisitaDetalle);
                            DB.SaveChanges();
                        }

                        foreach (Objeto o in n.objetos)
                        {
                            Objeto nuevoObjeto = new Objeto()
                            {
                                cantidad = o.cantidad,
                                comentario = o.comentario,
                                descripcion = o.descripcion,
                                id_visita = nuevaVisita.id_visita

                            };
                            DB.Objeto.Add(nuevoObjeto);
                            DB.SaveChanges();
                        }


                    }
                    dbContextTransaction.Commit();
                    return Ok();
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return NotFound();
                }
            }


            return Ok();
        }


        [HttpPost]
        [Route("api/Visita/UpdateInfo/")]
        public IHttpActionResult ActualizarInfoVisitas(VisitaUpdated n)
        {
            using (var dbContextTransaction = DB.Database.BeginTransaction())
            {
                try
                {
                    int idvisitadetalle = 0;

                    foreach (Visita_Detalle p in n.visita_detalle)
                    {
                        Visita_Detalle VisitaDetalle = DB.Visita_Detalle.Find(p.id_visita_detalle);
                        VisitaDetalle.hr_entrada = p.hr_entrada;
                        VisitaDetalle.hr_salida = p.hr_salida;
                        VisitaDetalle.n_carnet = p.n_carnet;
                        VisitaDetalle.observaciones = p.observaciones;
                        VisitaDetalle.nombre_adjunto = p.nombre_adjunto;
                        idvisitadetalle = VisitaDetalle.id_visita_detalle;
                        DB.SaveChanges();
                    }

                    foreach (Objeto o in n.objetos)
                    {
                        Objeto Objeto = DB.Objeto.Find(o.id_objeto);
                        Objeto.comentario = o.comentario;
                        DB.SaveChanges();
                    }

                    Visita visita = DB.Visita.Find(DB.Visita_Detalle.Find(idvisitadetalle).id_visita);

                    if (n.isFinal)
                    {
                        visita.estado = 3;
                    }
                    else
                    {
                        visita.estado = 2;
                    }

                    DB.SaveChanges();

                    dbContextTransaction.Commit();
                    return Ok();

                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return NotFound();
                }
            }
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
            DB.Visita_Detalle.RemoveRange(DB.Visita_Detalle.Where(i => i.id_visita == id));
            DB.Objeto.RemoveRange(DB.Objeto.Where(i => i.id_visita == id));
            DB.SaveChanges();
            return Ok();
        }
    }
}
