using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Security;
using CbcSelfServicePortal.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

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

        // GET api/getClaims
        [HttpGet]
        [Route("api/getClaims")]
        public async Task<List<csspClaims>> ListClaims()
        {
            using (var context = new ApplicationDbContext())
            {
                // var users = db.CsspClaims;

                return await context.CsspClaims.ToListAsync();
            }
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
                var text = "Treated !";
                csspClaims.Status = text;
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



        [HttpPost]
        [Route("api/csspClaims")]
        [ResponseType(typeof(csspClaims))]
        public async Task<csspClaims> postClaim()
        {

            if (!Request.Content.IsMimeMultipartContent())
                throw new Exception();


            var provider = new MultipartMemoryStreamProvider();
            var result = new { file = new List<csspClaims>() };
            var item = new csspClaims();

            item.Location = HttpContext.Current.Request.Form["Location"];
            item.AccidentDate = HttpContext.Current.Request.Form["AccidentDate"];
            item.BodilyInjury = HttpContext.Current.Request.Form["BodilyInjury"];
            item.Description = HttpContext.Current.Request.Form["Description"];
            item.VehicleRegistration = HttpContext.Current.Request.Form["VehicleRegistration"];
            item.DriverName = HttpContext.Current.Request.Form["DriverName"];
            item.PolicyHolderName = HttpContext.Current.Request.Form["PolicyHolderName"];
            item.RegistrationCountry = HttpContext.Current.Request.Form["RegistrationCountry"];
            

            var userName = HttpContext.Current.Request.Form["User"];


            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var user = manager.FindByEmail(userName);
          //  string userId = Membership.GetUser().ProviderUserKey.ToString();

            //item.userID = user.userId;
            item.claimUploadedBy = user.Email;
            item.claimUploadDate = DateTime.Now;
            var text = "Panding...";
            item.Status = text;

            await Request.Content.ReadAsMultipartAsync(provider)
             .ContinueWith(async (a) =>
             {
                 foreach (var file in provider.Contents)
                 {
                     if (file.Headers.ContentLength > 1000)
                     {
                         var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
                         var contentType = file.Headers.ContentType.ToString();
                         await file.ReadAsByteArrayAsync().ContinueWith(b => { item.File = b.Result; });
                     }

                 }

             }).Unwrap();

            db.CsspClaims.Add(item);
            db.SaveChanges();

            return item;
        }


        //   [HttpPost]
        public string UploadFile()
        {
            var file = HttpContext.Current.Request.Files.Count > 0 ?
                HttpContext.Current.Request.Files[0] : null;

            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);

                var path = Path.Combine(
                    HttpContext.Current.Server.MapPath("~/uploads"),
                    fileName
                );

                file.SaveAs(path);
            }

            return file != null ? "/uploads/" + file.FileName : null;
        }

        // PUT: api/UpdateClaimDetails/
        [HttpPut]
        [Route("api/UpdateClaimDetails")]
        public IHttpActionResult PutClaimMaster(csspClaims csspClaims)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                csspClaims objEmp = new csspClaims();
                objEmp = db.CsspClaims.Find(csspClaims.ID);
                if (objEmp != null)
                {
                    objEmp.Reply = csspClaims.Reply;
                    objEmp.Location = csspClaims.Location;
                    objEmp.AccidentDate = csspClaims.AccidentDate;
                    objEmp.BodilyInjury = csspClaims.BodilyInjury;
                    objEmp.Description = csspClaims.Description;
                    objEmp.VehicleRegistration = csspClaims.VehicleRegistration;
                    objEmp.DriverName = csspClaims.DriverName;
                    objEmp.PolicyHolderName = csspClaims.PolicyHolderName;
                    objEmp.RegistrationCountry = csspClaims.RegistrationCountry;
                    var text = "Panding...";
                    objEmp.Status = text;

                }
                int i = this.db.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
            return Ok(csspClaims);
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