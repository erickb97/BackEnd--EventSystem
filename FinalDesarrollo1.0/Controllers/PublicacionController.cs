using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using FinalDesarrollo1._0;

namespace FinalDesarrollo1._0.Controllers
{
    public class PublicacionController : ApiController
    {
        private db_desarrollofinalEntities db = new db_desarrollofinalEntities();

        // GET: api/Publicacion
        public IQueryable<Tb_Publicacion> GetTb_Publicacion()
        {
            return db.Tb_Publicacion;
        }

        // GET: api/Publicacion/5
        [ResponseType(typeof(Tb_Publicacion))]
        public async Task<IHttpActionResult> GetTb_Publicacion(int id)
        {
            Tb_Publicacion tb_Publicacion = await db.Tb_Publicacion.FindAsync(id);
            if (tb_Publicacion == null)
            {
                return NotFound();
            }

            return Ok(tb_Publicacion);
        }

        // PUT: api/Publicacion/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTb_Publicacion(int id, Tb_Publicacion tb_Publicacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tb_Publicacion.Publicacion_id)
            {
                return BadRequest();
            }

            db.Entry(tb_Publicacion).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tb_PublicacionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Publicacion
        [ResponseType(typeof(Tb_Publicacion))]
        public async Task<IHttpActionResult> PostTb_Publicacion(Tb_Publicacion tb_Publicacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tb_Publicacion.Add(tb_Publicacion);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tb_Publicacion.Publicacion_id }, tb_Publicacion);
        }

        // DELETE: api/Publicacion/5
        [ResponseType(typeof(Tb_Publicacion))]
        public async Task<IHttpActionResult> DeleteTb_Publicacion(int id)
        {
            Tb_Publicacion tb_Publicacion = await db.Tb_Publicacion.FindAsync(id);
            if (tb_Publicacion == null)
            {
                return NotFound();
            }

            db.Tb_Publicacion.Remove(tb_Publicacion);
            await db.SaveChangesAsync();

            return Ok(tb_Publicacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tb_PublicacionExists(int id)
        {
            return db.Tb_Publicacion.Count(e => e.Publicacion_id == id) > 0;
        }
    }
}