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
    public class EventosController : ApiController
    {
        private db_desarrollofinalEntities db = new db_desarrollofinalEntities();

        // GET: api/Eventos
        public IQueryable<Tb_Eventos> GetTb_Eventos()
        {
            return db.Tb_Eventos;
        }

        // GET: api/Eventos/5
        [ResponseType(typeof(Tb_Eventos))]
        public async Task<IHttpActionResult> GetTb_Eventos(int id)
        {
            Tb_Eventos tb_Eventos = await db.Tb_Eventos.FindAsync(id);
            if (tb_Eventos == null)
            {
                return NotFound();
            }

            return Ok(tb_Eventos);
        }

        // PUT: api/Eventos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTb_Eventos(int id, Tb_Eventos tb_Eventos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tb_Eventos.Eventos_id)
            {
                return BadRequest();
            }

            db.Entry(tb_Eventos).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tb_EventosExists(id))
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

        // POST: api/Eventos
        [ResponseType(typeof(Tb_Eventos))]
        public async Task<IHttpActionResult> PostTb_Eventos(Tb_Eventos tb_Eventos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tb_Eventos.Add(tb_Eventos);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tb_Eventos.Eventos_id }, tb_Eventos);
        }

        // DELETE: api/Eventos/5
        [ResponseType(typeof(Tb_Eventos))]
        public async Task<IHttpActionResult> DeleteTb_Eventos(int id)
        {
            Tb_Eventos tb_Eventos = await db.Tb_Eventos.FindAsync(id);
            if (tb_Eventos == null)
            {
                return NotFound();
            }

            db.Tb_Eventos.Remove(tb_Eventos);
            await db.SaveChangesAsync();

            return Ok(tb_Eventos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tb_EventosExists(int id)
        {
            return db.Tb_Eventos.Count(e => e.Eventos_id == id) > 0;
        }
    }
}