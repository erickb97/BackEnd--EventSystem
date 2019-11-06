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
    public class TicketController : ApiController
    {
        private db_desarrollofinalEntities db = new db_desarrollofinalEntities();

        // GET: api/Ticket
        public IQueryable<Tb_Ticket> GetTb_Ticket()
        {
            return db.Tb_Ticket;
        }

        // GET: api/Ticket/5
        [ResponseType(typeof(Tb_Ticket))]
        public async Task<IHttpActionResult> GetTb_Ticket(int id)
        {
            Tb_Ticket tb_Ticket = await db.Tb_Ticket.FindAsync(id);
            if (tb_Ticket == null)
            {
                return NotFound();
            }

            return Ok(tb_Ticket);
        }

        // PUT: api/Ticket/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTb_Ticket(int id, Tb_Ticket tb_Ticket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tb_Ticket.Ticket_id)
            {
                return BadRequest();
            }

            db.Entry(tb_Ticket).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tb_TicketExists(id))
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

        // POST: api/Ticket
        [ResponseType(typeof(Tb_Ticket))]
        public async Task<IHttpActionResult> PostTb_Ticket(Tb_Ticket tb_Ticket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tb_Ticket.Add(tb_Ticket);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tb_Ticket.Ticket_id }, tb_Ticket);
        }

        // DELETE: api/Ticket/5
        [ResponseType(typeof(Tb_Ticket))]
        public async Task<IHttpActionResult> DeleteTb_Ticket(int id)
        {
            Tb_Ticket tb_Ticket = await db.Tb_Ticket.FindAsync(id);
            if (tb_Ticket == null)
            {
                return NotFound();
            }

            db.Tb_Ticket.Remove(tb_Ticket);
            await db.SaveChangesAsync();

            return Ok(tb_Ticket);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tb_TicketExists(int id)
        {
            return db.Tb_Ticket.Count(e => e.Ticket_id == id) > 0;
        }
    }
}