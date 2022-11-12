using System.ComponentModel.DataAnnotations;

namespace personal_web.Models
{
    public class links
    {
        [Key]
        public int LinkID { get; set; }

        [StringLength(100)]
        public string Facebook { get; set; }

        [StringLength(100)]
        public string Instagram { get; set; }

        [StringLength(100)]
        public string Twitter { get; set; }

        [StringLength(100)]
        public string LinkedIn { get; set; }

        [StringLength(100)]
        public string Github { get; set; }

        [StringLength(100)]
        public string Ohters { get; set; }
    }
}