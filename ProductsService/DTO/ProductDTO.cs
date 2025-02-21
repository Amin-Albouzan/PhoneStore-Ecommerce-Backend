using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProductsService.DTO
{
    public class ProductDTO
    {

     
        public int Product_ID { get; set; }


        public String Product_Name { get; set; }

      
        public double Product_Price { get; set; }

        
        public String Product_Discription { get; set; }


      
        public String Product_ImageUrl { get; set; }



       
        public int Category_Id { get; set; }



    }
}
