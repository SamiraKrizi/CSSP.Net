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
using CbcSelfServicePortal.Models;

namespace CbcSelfServicePortal.Controllers
{
    public class DetailsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Details
        public IQueryable<Details> GetDetails()
        {
            return db.Details;
        }

        // GET: api/Details/5
        [ResponseType(typeof(Details))]
        public IHttpActionResult GetDetails(int id)
        {
            Details details = db.Details.Find(id);
            if (details == null)
            {
                return NotFound();
            }

            return Ok(details);
        }

        // PUT: api/Details/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDetails(int id, Details details)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != details.ID)
            {
                return BadRequest();
            }

            db.Entry(details).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetailsExists(id))
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

        // POST: api/Details
        [ResponseType(typeof(Details))]
        public IHttpActionResult PostDetails(Details details)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Details.Add(details);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = details.ID }, details);
        }

        // DELETE: api/Details/5
        [ResponseType(typeof(Details))]
        public IHttpActionResult DeleteDetails(int id)
        {
            Details details = db.Details.Find(id);
            if (details == null)
            {
                return NotFound();
            }

            db.Details.Remove(details);
            db.SaveChanges();

            return Ok(details);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DetailsExists(int id)
        {
            return db.Details.Count(e => e.ID == id) > 0;
        }
    }
}