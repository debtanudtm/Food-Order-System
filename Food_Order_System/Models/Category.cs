using System.ComponentModel.DataAnnotations;

namespace Food_Order_System.Models
{
    public class Category
    {
        [Key]
        public int Category_ID { get; set; }

        [Display(Name = "Category Name")]
        public string Category_Name { get; set; }
    }
}
