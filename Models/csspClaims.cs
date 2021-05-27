using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CbcSelfServicePortal.Models
{
    public class csspClaims
    {
        [Key]
        public int ID { get; set; }
       // public string userID { get; set; }

        public DateTime? claimUploadDate { get; set; }
        public string claimUploadedBy { get; set; }
        public string Status { get; set; }
        public string Reply { get; set; }


        ////////////////////////////////////////////////////////
        public string Location { get; set; }
        public string AccidentDate { get; set; }
        public string BodilyInjury { get; set; }
        public string Description { get; set; }

        ///////////////////////////////////////////////////////

        public string VehicleRegistration { get; set; }
        public string DriverName { get; set; }
        public string PolicyHolderName { get; set; }
        public string RegistrationCountry { get; set; }

        ///////////////////////////////////////////////////////
        public byte[] File { get; set; }
        ///////////////////////////////////////////////////////
       







    }
}