using System.ComponentModel.DataAnnotations;

namespace Food_Order_System.Models
{
    public class User
    {
        [Key]
        public int Order_ID { get; set; }
        [Display(Name = "Email ID ")]
        public String Email_ID { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        [MaxLength(10)]
        public string ContNo { get; set; }
        [Display(Name = "Product ID")]
        public int Item_ID { get; set; }
        [Display(Name = "Product Name")]
        public string Item_Name { get; set; }

        [Display(Name = "Date Time")]
        public DateTime Order_Date { get; set; }

        [Display(Name = "Amount")]
        public int Order_Amount { get; set; }
    }
}
