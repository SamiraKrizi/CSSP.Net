using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CbcSelfServicePortal.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        // public csspClaims CsspClaims { get; set; }
        public string VehicleRegistration { get; set; }
        public string RegistrationCountry { get; set; }
        public string Name { get; set; }
        public DateTime ClaimDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }

        //public string[] Roles { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext()
            : base("CedInternship", throwIfV1Schema: false)
        {
            Configuration.LazyLoadingEnabled = false;
        }
       
        public DbSet<csspClaims> CsspClaims { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<AdminReply> AdminReply { get; set; }
        public DbSet<InsuranceCompany> InsuranceCompanies { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

       
    }
}