using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CbcSelfServicePortal.Models
{
    public class AdminReply
    {
        [Key]
        public int ID { get; set; }
        public string Content { get; set; }
    }
}