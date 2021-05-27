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
using CbcSelfServicePortal.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CbcSelfServicePortal.Controllers
{
    public class InsuranceCompaniesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        /* // GET: api/InsuranceCompanies
         public IQueryable<InsuranceCompany> GetInsuranceCompanies()
         {
             return db.InsuranceCompanies;
         }*/

        // GET api/InsuranceCompanies
        [HttpGet]
        [Route("api/InsuranceCompanies")]
        public async Task<List<InsuranceCompany>> ListCompanies()
        {
            using (var context = new ApplicationDbContext())
            {
                // var users = db.CsspClaims;

                return await context.InsuranceCompanies.ToListAsync();
            }
        }


        // GET: api/InsuranceCompanies/5
        [ResponseType(typeof(InsuranceCompany))]
        public IHttpActionResult GetInsuranceCompany(int id)
        {
            InsuranceCompany insuranceCompany = db.InsuranceCompanies.Find(id);
            if (insuranceCompany == null)
            {
                return NotFound();
            }

            return Ok(insuranceCompany);
        }

        /*   // PUT: api/InsuranceCompanies/5
           [ResponseType(typeof(void))]
           public IHttpActionResult PutInsuranceCompany(int id, InsuranceCompany insuranceCompany)
           {
               if (!ModelState.IsValid)
               {
                   return BadRequest(ModelState);
               }

               if (id != insuranceCompany.ID)
               {
                   return BadRequest();
               }

               db.Entry(insuranceCompany).State = EntityState.Modified;

               try
               {
                   db.SaveChanges();
               }
               catch (DbUpdateConcurrencyException)
               {
                   if (!InsuranceCompanyExists(id))
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
          */

        // PUT: api/InsuranceCompanies/5
        [HttpPut]
        [Route("api/InsuranceCompanies/{id:guid}")]
        public async Task<InsuranceCompany> PutEmaployeeMaster(InsuranceCompany InsuranceCompany)
        {
            InsuranceCompany objEmp = new InsuranceCompany();
            var provider = new MultipartMemoryStreamProvider();
            try
            {
                //InsuranceCompany objEmp = new InsuranceCompany();
                objEmp = db.InsuranceCompanies.Find(InsuranceCompany.ID);
                if (objEmp != null)
                {
                    objEmp.Name = InsuranceCompany.Name;
                
                await Request.Content.ReadAsMultipartAsync(provider)
            .ContinueWith(async (a) =>
            {
                foreach (var file in provider.Contents)
                {
                    if (file.Headers.ContentLength > 1000)
                    {
                        var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
                        var contentType = file.Headers.ContentType.ToString();
                        await file.ReadAsByteArrayAsync().ContinueWith(b => { objEmp.Logo = b.Result; });
                    }

                }

            }).Unwrap();
                }
                //  db.InsuranceCompanies.Add(item);
                db.SaveChanges();
                int i = this.db.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
              return objEmp;
           
        }



        // POST: api/InsuranceCompanies
        [HttpPost]
        [Route("api/InsuranceCompanies")]
        [ResponseType(typeof(InsuranceCompany))]
        public async Task<InsuranceCompany> PostInsuranceCompany()
        {

            if (!Request.Content.IsMimeMultipartContent())
                throw new Exception();


            var provider = new MultipartMemoryStreamProvider();
            var result = new { file = new List<InsuranceCompany>() };
            var item = new InsuranceCompany();

            item.Name = HttpContext.Current.Request.Form["Name"];

            await Request.Content.ReadAsMultipartAsync(provider)
             .ContinueWith(async (a) =>
             {
                 foreach (var file in provider.Contents)
                 {
                     if (file.Headers.ContentLength > 1000)
                     {
                         var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
                         var contentType = file.Headers.ContentType.ToString();
                         await file.ReadAsByteArrayAsync().ContinueWith(b => { item.Logo = b.Result; });
                     }

                 }

             }).Unwrap();

            db.InsuranceCompanies.Add(item);
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

        // DELETE: api/InsuranceCompanies/5
        [ResponseType(typeof(InsuranceCompany))]
        public IHttpActionResult DeleteInsuranceCompany(int id)
        {
            InsuranceCompany insuranceCompany = db.InsuranceCompanies.Find(id);
            if (insuranceCompany == null)
            {
                return NotFound();
            }

            db.InsuranceCompanies.Remove(insuranceCompany);
            db.SaveChanges();

            return Ok(insuranceCompany);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InsuranceCompanyExists(int id)
        {
            return db.InsuranceCompanies.Count(e => e.ID == id) > 0;
        }
    }
}