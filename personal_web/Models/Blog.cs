using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace personal_web.Models
{
    public class Blog
    {
        [Key]
        public int BlogID { get; set; }

        [Required(ErrorMessage = "Please Provide Blog Title.")]
        [StringLength(200)]
        [Display(Name = "Blog Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please Provide Blog Date.")]
        [StringLength(10)]
        [Display(Name = "Blog Date")]
        public string Date { get; set; }

        [Required(ErrorMessage = "Please Provide Short Introduction.")]
        [StringLength(800)]
        [Display(Name = "Short Intro")]
        public string ShortDescription { get; set; }

        [AllowHtml]
        [Required(ErrorMessage = "Please Provide Blog Description.")]
        [Display(Name = "Blog Description")]
        //[UIHint("tinymce_jquery_full"), AllowHtml]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please Provide Image.")]
        [Display(Name = "Blog Thumbnail")]
        [StringLength(500)]
        public string Image { get; set; }

        public int? CategoryID { get; set; }
        public virtual BlogCategory BlogCategory { get; set; }
    }
}