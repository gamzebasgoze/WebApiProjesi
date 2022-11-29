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
using apiguzellikmerkezi.Models;

namespace apiguzellikmerkezi.Controllers
{
    public class SalonlarsController : ApiController
    {
        private GuzellikMerkeziEntities db = new GuzellikMerkeziEntities();

        // GET: api/Salonlars
        public IQueryable<Salonlar> GetSalonlars()
        {
            return db.Salonlars;
        }

        // GET: api/Salonlars/5
        [ResponseType(typeof(Salonlar))]
        public async Task<IHttpActionResult> GetSalonlar(int id)
        {
            Salonlar salonlar = await db.Salonlars.FindAsync(id);
            if (salonlar == null)
            {
                return NotFound();
            }

            return Ok(salonlar);
        }

        // PUT: api/Salonlars/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSalonlar(int id, Salonlar salonlar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != salonlar.SalonNo)
            {
                return BadRequest();
            }

            db.Entry(salonlar).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalonlarExists(id))
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

        // POST: api/Salonlars
        [ResponseType(typeof(Salonlar))]
        public async Task<IHttpActionResult> PostSalonlar(Salonlar salonlar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Salonlars.Add(salonlar);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = salonlar.SalonNo }, salonlar);
        }

        // DELETE: api/Salonlars/5
        [ResponseType(typeof(Salonlar))]
        public async Task<IHttpActionResult> DeleteSalonlar(int id)
        {
            Salonlar salonlar = await db.Salonlars.FindAsync(id);
            if (salonlar == null)
            {
                return NotFound();
            }

            db.Salonlars.Remove(salonlar);
            await db.SaveChangesAsync();

            return Ok(salonlar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SalonlarExists(int id)
        {
            return db.Salonlars.Count(e => e.SalonNo == id) > 0;
        }
    }
}