using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace personal_web.Models
{
    public class About
    {
        [Key]
        public int AboutID { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        [StringLength(150)]
        public string Qutation { get; set; }

        [StringLength(200)]
        public string ShortDescription { get; set; }

        [Required]
        [StringLength(1500)]
        public string Description { get; set; }
    }
}