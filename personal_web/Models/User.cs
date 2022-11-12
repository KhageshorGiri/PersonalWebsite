using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace personal_web.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [StringLength(20)]
        public string UserName { get; set; }

        [StringLength(500)]
        public string Password { get; set; }

        [StringLength(10)]
        public string Role { get; set; }
    }
}