using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CbcSelfServicePortal.Models
{
    public class UserEdit
    {
        [Required]
        public string UserName { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string VehicleRegistration { get; set; }

        public string RegistrationCountry { get; set; }

        public String PhoneNumber { get; set; }

    }
}