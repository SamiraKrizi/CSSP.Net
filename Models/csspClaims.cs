using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CbcSelfServicePortal.Models
{
    public class csspClaims
    {
        [Key]
        public int ID { get; set; }
        public int UsersID { get; set; }
        public virtual Details Details { get; set; }
        public virtual OtherParty OtherParty { get; set; }
        public virtual Documents Documents { get; set; }
    }
}