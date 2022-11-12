using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace personal_web.Models
{
    public class Skill
    {
        public Skill()
        {
            SkillAttributes = new HashSet<skillAttribute>();
        }

        [Key]
        public int SkillID { get; set; }

        [Required(ErrorMessage ="Please provide Image for Skill.")]
        [StringLength(300)]
        public string Image { get; set; }

        [Required(ErrorMessage = "Please provide Description for Skill.")]
        [StringLength(100, ErrorMessage = "Content length Should be less than 100.")]
        public string Description { get; set; }

        public virtual ICollection<skillAttribute> SkillAttributes { get; set; }
    }
}