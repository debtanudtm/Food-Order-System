using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Food_Order_System.Models
{
    public class Item
    {
        [Key]
        [Display(Name = "ID")]
        public int Item_ID { get; set; }

        [Display(Name = "Name")]
        public string Item_Name { get; set; }

        [Display(Name = "Price")]
        public int Item_Price { get; set; }

        [Display(Name = "image")]
        public string? Item_image { get; set; }

        [NotMapped]
        public IFormFile? Pic_File { get; set; }

        [Display(Name = "Category")]
        public int? Category_ID { get; set; }

        [NotMapped]
        public string Category_Name { get; set; }
    }
}
