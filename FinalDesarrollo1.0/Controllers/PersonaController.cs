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
    public class PersonaController : ApiController
    {
        private db_desarrollofinalEntities db = new db_desarrollofinalEntities();

        // GET: api/Persona
        public IQueryable<Tb_Persona> GetTb_Persona()
        {
            return db.Tb_Persona;
        }

        // GET: api/Persona/5
        [ResponseType(typeof(Tb_Persona))]
        public async Task<IHttpActionResult> GetTb_Persona(int id)
        {
            Tb_Persona tb_Persona = await db.Tb_Persona.FindAsync(id);
            if (tb_Persona == null)
            {
                return NotFound();
            }

            return Ok(tb_Persona);
        }

        // PUT: api/Persona/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTb_Persona(int id, Tb_Persona tb_Persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tb_Persona.Persona_id)
            {
                return BadRequest();
            }

            db.Entry(tb_Persona).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tb_PersonaExists(id))
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

        // POST: api/Persona
        [ResponseType(typeof(Tb_Persona))]
        public async Task<IHttpActionResult> PostTb_Persona(Tb_Persona tb_Persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tb_Persona.Add(tb_Persona);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tb_Persona.Persona_id }, tb_Persona);
        }

        // DELETE: api/Persona/5
        [ResponseType(typeof(Tb_Persona))]
        public async Task<IHttpActionResult> DeleteTb_Persona(int id)
        {
            Tb_Persona tb_Persona = await db.Tb_Persona.FindAsync(id);
            if (tb_Persona == null)
            {
                return NotFound();
            }

            db.Tb_Persona.Remove(tb_Persona);
            await db.SaveChangesAsync();

            return Ok(tb_Persona);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tb_PersonaExists(int id)
        {
            return db.Tb_Persona.Count(e => e.Persona_id == id) > 0;
        }
    }
}