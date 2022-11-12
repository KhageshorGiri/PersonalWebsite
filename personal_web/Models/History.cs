using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace personal_web.Models
{
    public class History
    {
        [Key]
        public int HistoryID { get; set; }
       
        [Required(ErrorMessage ="Please Provide Description.")]
        [StringLength(500, ErrorMessage ="Content length Should be less than 500.")]
        public string Description { get; set; }

    }
}