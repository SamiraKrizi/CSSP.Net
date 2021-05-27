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
    public class AdminRepliesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/AdminReplies
        public IQueryable<AdminReply> GetAdminReply()
        {
            return db.AdminReply;
        }

        // GET: api/AdminReplies/5
        [ResponseType(typeof(AdminReply))]
        public IHttpActionResult GetAdminReply(int id)
        {
            AdminReply adminReply = db.AdminReply.Find(id);
            if (adminReply == null)
            {
                return NotFound();
            }

            return Ok(adminReply);
        }

        // PUT: api/AdminReplies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdminReply(int id, AdminReply adminReply)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adminReply.ID)
            {
                return BadRequest();
            }

            db.Entry(adminReply).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminReplyExists(id))
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

        // POST: api/AdminReplies
        [ResponseType(typeof(AdminReply))]
        public IHttpActionResult PostAdminReply(AdminReply adminReply)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AdminReply.Add(adminReply);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = adminReply.ID }, adminReply);
        }

        // DELETE: api/AdminReplies/5
        [ResponseType(typeof(AdminReply))]
        public IHttpActionResult DeleteAdminReply(int id)
        {
            AdminReply adminReply = db.AdminReply.Find(id);
            if (adminReply == null)
            {
                return NotFound();
            }

            db.AdminReply.Remove(adminReply);
            db.SaveChanges();

            return Ok(adminReply);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdminReplyExists(int id)
        {
            return db.AdminReply.Count(e => e.ID == id) > 0;
        }
    }
}