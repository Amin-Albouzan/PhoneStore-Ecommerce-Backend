using System.ComponentModel.DataAnnotations;

namespace ProductsService.Models
{
    public class Category
    {
        [Key]
        public int Category_ID { get; set; }

        [Required]
        public String Category_Name { get; set; }


        public List<Product> Product { get; set; }
    }
}
