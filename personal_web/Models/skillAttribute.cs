using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace personal_web.Models
{
    public class skillAttribute
    {
        [Key]
        public int SkillAttributeID { get; set; }

        [StringLength(50)]
        [Required]
        public string SkillTitle { get; set; }

        [StringLength(50)]
        public string Remarks { get; set; }

        public int SkillID { get; set; }
        public virtual Skill Skill { get; set; }
    }
}