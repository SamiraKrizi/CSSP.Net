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
    public class OtherPartiesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/OtherParties
        public IQueryable<OtherParty> GetOtherParty()
        {
            return db.OtherParty;
        }

        // GET: api/OtherParties/5
        [ResponseType(typeof(OtherParty))]
        public IHttpActionResult GetOtherParty(int id)
        {
            OtherParty otherParty = db.OtherParty.Find(id);
            if (otherParty == null)
            {
                return NotFound();
            }

            return Ok(otherParty);
        }

        // PUT: api/OtherParties/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOtherParty(int id, OtherParty otherParty)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != otherParty.ID)
            {
                return BadRequest();
            }

            db.Entry(otherParty).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OtherPartyExists(id))
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

        // POST: api/OtherParties
        [ResponseType(typeof(OtherParty))]
        public IHttpActionResult PostOtherParty(OtherParty otherParty)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OtherParty.Add(otherParty);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = otherParty.ID }, otherParty);
        }

        // DELETE: api/OtherParties/5
        [ResponseType(typeof(OtherParty))]
        public IHttpActionResult DeleteOtherParty(int id)
        {
            OtherParty otherParty = db.OtherParty.Find(id);
            if (otherParty == null)
            {
                return NotFound();
            }

            db.OtherParty.Remove(otherParty);
            db.SaveChanges();

            return Ok(otherParty);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OtherPartyExists(int id)
        {
            return db.OtherParty.Count(e => e.ID == id) > 0;
        }
    }
}