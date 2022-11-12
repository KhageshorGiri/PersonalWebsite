using System.ComponentModel.DataAnnotations;

namespace personal_web.Models
{
    public class Home
    {
        [Key]
        public int HomeID { get; set; }
        [Required(ErrorMessage ="Please Provide your Full Name.")]
        [StringLength(50)]
        [Display(Name ="Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please Provide Title For Home.")]
        [StringLength(100, ErrorMessage ="Description cannot be gratere than 100 charater.")]
        [Display(Name = "Title Description")]
        public string TitleDescription { get; set; }

        [Required(ErrorMessage = "Please Provide your Introduction.")]
        [StringLength(250, ErrorMessage = "Introduction cannot be gratere than 250 charater.")]
        [Display(Name = "Introduction")]
        public string Introduction { get; set; }

        [Required(ErrorMessage = "Please Provide your bg image in png.")]
        [Display(Name = "Bg Image File")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Please Provide call to action text.")]
        [StringLength(300, ErrorMessage = "Call to Action cannot be gratere than 300 charater.")]
        [Display(Name = "Call To Action")]
        public string CalltoAction { get; set; }

    }
}