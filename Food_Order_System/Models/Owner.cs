using System.ComponentModel.DataAnnotations;

namespace Food_Order_System.Models
{
    public class Owner
    {
        [Key]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
