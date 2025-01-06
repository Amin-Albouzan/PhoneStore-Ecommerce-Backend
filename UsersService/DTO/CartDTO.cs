using System.ComponentModel.DataAnnotations;

namespace UsersService.DTO
{
    public class CartDTO
    {
        public int productID { get; set; }
        public String UserEmail { get; set; }
        public String Product_Name { get; set; }
        public String Product_Discription { get; set; }
        public double Product_Price { get; set; }
        public String Product_ImageUrl { get; set; }

    }
}
