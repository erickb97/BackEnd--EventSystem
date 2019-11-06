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
    public class ArtistasController : ApiController
    {
        private db_desarrollofinalEntities db = new db_desarrollofinalEntities();

        // GET: api/Artistas
        public IQueryable<Tb_Artistas> GetTb_Artistas()
        {
            return db.Tb_Artistas;
        }

        // GET: api/Artistas/5
        [ResponseType(typeof(Tb_Artistas))]
        public async Task<IHttpActionResult> GetTb_Artistas(int id)
        {
            Tb_Artistas tb_Artistas = await db.Tb_Artistas.FindAsync(id);
            if (tb_Artistas == null)
            {
                return NotFound();
            }

            return Ok(tb_Artistas);
        }

        // PUT: api/Artistas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTb_Artistas(int id, Tb_Artistas tb_Artistas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tb_Artistas.Artista_id)
            {
                return BadRequest();
            }

            db.Entry(tb_Artistas).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tb_ArtistasExists(id))
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

        // POST: api/Artistas
        [ResponseType(typeof(Tb_Artistas))]
        public async Task<IHttpActionResult> PostTb_Artistas(Tb_Artistas tb_Artistas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tb_Artistas.Add(tb_Artistas);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tb_Artistas.Artista_id }, tb_Artistas);
        }

        // DELETE: api/Artistas/5
        [ResponseType(typeof(Tb_Artistas))]
        public async Task<IHttpActionResult> DeleteTb_Artistas(int id)
        {
            Tb_Artistas tb_Artistas = await db.Tb_Artistas.FindAsync(id);
            if (tb_Artistas == null)
            {
                return NotFound();
            }

            db.Tb_Artistas.Remove(tb_Artistas);
            await db.SaveChangesAsync();

            return Ok(tb_Artistas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tb_ArtistasExists(int id)
        {
            return db.Tb_Artistas.Count(e => e.Artista_id == id) > 0;
        }
    }
}