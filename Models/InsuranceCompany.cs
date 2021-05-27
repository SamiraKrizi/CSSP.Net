using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CbcSelfServicePortal.Models
{
    public class InsuranceCompany
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public byte[] Logo { get; set; }
        //public ICollection<Rating> Ratings { get; set; }
    }
}