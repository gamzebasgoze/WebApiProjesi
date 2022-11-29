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
    public class UrunlersController : ApiController
    {
        private GuzellikMerkeziEntities db = new GuzellikMerkeziEntities();

        // GET: api/Urunlers
        public IQueryable<Urunler> GetUrunlers()
        {
            return db.Urunlers;
        }

        // GET: api/Urunlers/5
        [ResponseType(typeof(Urunler))]
        public async Task<IHttpActionResult> GetUrunler(int id)
        {
            Urunler urunler = await db.Urunlers.FindAsync(id);
            if (urunler == null)
            {
                return NotFound();
            }

            return Ok(urunler);
        }

        // PUT: api/Urunlers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUrunler(int id, Urunler urunler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != urunler.UrunNo)
            {
                return BadRequest();
            }

            db.Entry(urunler).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UrunlerExists(id))
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

        // POST: api/Urunlers
        [ResponseType(typeof(Urunler))]
        public async Task<IHttpActionResult> PostUrunler(Urunler urunler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Urunlers.Add(urunler);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = urunler.UrunNo }, urunler);
        }

        // DELETE: api/Urunlers/5
        [ResponseType(typeof(Urunler))]
        public async Task<IHttpActionResult> DeleteUrunler(int id)
        {
            Urunler urunler = await db.Urunlers.FindAsync(id);
            if (urunler == null)
            {
                return NotFound();
            }

            db.Urunlers.Remove(urunler);
            await db.SaveChangesAsync();

            return Ok(urunler);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UrunlerExists(int id)
        {
            return db.Urunlers.Count(e => e.UrunNo == id) > 0;
        }
    }
}