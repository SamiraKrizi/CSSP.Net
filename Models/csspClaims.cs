using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CbcSelfServicePortal.Models
{
    public class csspClaims
    {
        [Key]
        public int ID { get; set; }
        public DateTime ClaimDate { get; set; } = DateTime.Now;
        public  Details Details { get; set; }
        public  OtherParty OtherParty { get; set; }
        public  Documents Documents { get; set; }

    }
}