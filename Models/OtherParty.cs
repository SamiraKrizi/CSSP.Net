using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CbcSelfServicePortal.Models
{
    public class OtherParty
    {
        [Key]
        public int ID { get; set; }
        public string VehicleRegistration { get; set; }
        public string DriverName { get; set; }
        public string PolicyHolderName { get; set; }
        public string RegistrationCountry { get; set; }
    }
}