using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using GuitarAPI.Models;

namespace GuitarAPI.Controllers
{
    public class GuitarsController : ApiController
    {
        private GuitarBase db = new GuitarBase();

        // GET: api/Guitars
        public IQueryable<Guitar> GetGuitars()
        {
            return db.Guitars;
        }

        // GET: api/Guitars/5
        [ResponseType(typeof(Guitar))]
        public IHttpActionResult GetGuitar(int id)
        {
            Guitar guitar = db.Guitars.Find(id);
            if (guitar == null)
            {
                return NotFound();
            }

            return Ok(guitar);
        }

        // PUT: api/Guitars/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGuitar(int id, Guitar guitar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != guitar.Id)
            {
                return BadRequest();
            }

            db.Entry(guitar).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuitarExists(id))
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

        // POST: api/Guitars
        [ResponseType(typeof(Guitar))]
        public IHttpActionResult PostGuitar(Guitar guitar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Guitars.Add(guitar);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = guitar.Id }, guitar);
        }

        // DELETE: api/Guitars/5
        [ResponseType(typeof(Guitar))]
        public IHttpActionResult DeleteGuitar(int id)
        {
            Guitar guitar = db.Guitars.Find(id);
            if (guitar == null)
            {
                return NotFound();
            }

            db.Guitars.Remove(guitar);
            db.SaveChanges();

            return Ok(guitar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GuitarExists(int id)
        {
            return db.Guitars.Count(e => e.Id == id) > 0;
        }
    }
}