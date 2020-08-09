using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CbcSelfServicePortal.Models
{
    public class Details
    {
        [Key]
        public int ID { get; set; }
        public string Location { get; set; }
        public string AccidentDate { get; set; }
        public string BodilyInjury { get; set; }
        public string Description { get; set; }
    }
}