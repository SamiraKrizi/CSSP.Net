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
    public class csspClaimsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/csspClaims 
        public IQueryable<csspClaims> GetCsspClaims()
        {
            return db.CsspClaims;
        }

        // GET: api/csspClaims/5
        [ResponseType(typeof(csspClaims))]
        public IHttpActionResult GetcsspClaims(int id)
        {
            csspClaims csspClaims = db.CsspClaims.Find(id);
            if (csspClaims == null)
            {
                return NotFound();
            }

            return Ok(csspClaims);
        }

        // PUT: api/csspClaims/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutcsspClaims(int id, csspClaims csspClaims)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != csspClaims.ID)
            {
                return BadRequest();
            }

            db.Entry(csspClaims).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!csspClaimsExists(id))
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

        // POST: api/csspClaims
        [ResponseType(typeof(csspClaims))]
        public IHttpActionResult PostcsspClaims(csspClaims csspClaims)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CsspClaims.Add(csspClaims);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = csspClaims.ID }, csspClaims);
        }

        // DELETE: api/csspClaims/5
        [ResponseType(typeof(csspClaims))]
        public IHttpActionResult DeletecsspClaims(int id)
        {
            csspClaims csspClaims = db.CsspClaims.Find(id);
            if (csspClaims == null)
            {
                return NotFound();
            }

            db.CsspClaims.Remove(csspClaims);
            db.SaveChanges();

            return Ok(csspClaims);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool csspClaimsExists(int id)
        {
            return db.CsspClaims.Count(e => e.ID == id) > 0;
        }
    }
}