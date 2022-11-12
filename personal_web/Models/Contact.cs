using System.ComponentModel.DataAnnotations;

namespace personal_web.Models
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }
        [StringLength(20)]
        public string FullName { get; set; }
        [StringLength(30)]
        public string Email { get; set; }
        [StringLength(10)]
        public string Phone { get; set; }
        [StringLength(1000)]
        public string Message { get; set; }
    }
}