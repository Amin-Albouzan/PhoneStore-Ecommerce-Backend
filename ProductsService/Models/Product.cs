using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsService.Models
{
    public class Product
    {
        [Key]
        public int Product_ID { get; set; }

       
        [Required]
        public String Product_Name { get; set; }

        [Required]
        public double Product_Price { get; set; }

        [Required]
        public String Product_Discription { get; set; }


        [Required]
        public String Product_ImageUrl { get; set; }


        //[ForeignKey("Category")]
        [Required]
        public int Category_Id { get; set; }
        //public virtual Category Category { get; set; }

    }
}
