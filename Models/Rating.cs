using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CbcSelfServicePortal.Models
{
    public class Rating
    {
            [Key]
            public int ID { get; set; }
            public int UserID { get; set; }
            public int CompanyID { get; set; }
            public int Stars { get; set; }
            public string Reviews { get; set; }
            public DateTime DatePost { get; set; }
        }
    }
