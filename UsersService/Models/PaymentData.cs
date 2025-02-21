using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsersService.Models
{
    public class PaymentData
    {
        [Key]
        [Required]
        public int Payment_ID { get; set; }

        //[ForeignKey("CartData")]
        public int? Cart_ID { get; set; }

        
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

        //[ForeignKey("UserData")]
        [Required]
        public int User_ID { get; set; }

        [Required]
        public DateTime payment_Date { get; set; }


        

    }
}
