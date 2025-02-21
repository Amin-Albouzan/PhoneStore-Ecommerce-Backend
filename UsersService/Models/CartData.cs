using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UsersService.Models
{
    public class CartData
    {
        [Key]
        public int Cart_ID { get; set; }

        
        [Required]
        public int Product_ID { get; set; }
      

        [Required]
        public String Product_Name { get; set; }

        [Required]
        public String Product_Discription { get; set; }

        [Required]
        public double Product_Price { get; set; }

        [Required]
        public String Product_ImageUrl { get; set; }

       
        public int Quantity { get; set; }


    
        [Required]
        public int User_ID { get; set; }




        

    }
}
