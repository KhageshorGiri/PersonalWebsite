using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace personal_web.Models
{
    public class BlogCategory
    {
        public BlogCategory()
        {
            Blogs = new HashSet<Blog>();
        }
        [Key]
        public int CategoryID { get; set; }

        [Required(ErrorMessage ="Please Provide Blog Category.")]
        [StringLength(100, ErrorMessage ="Category should  be less then 100 characters.")]
        public string Category { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
    }
}