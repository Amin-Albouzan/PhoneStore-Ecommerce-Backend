namespace UsersService.Models
{
    public class ShoppingListSP
    {

        public int Payment_ID { get; set; }


        public int Cart_ID { get; set; }


        public int Product_ID { get; set; }


        public String Product_Name { get; set; }


        public String Product_Discription { get; set; }


        public double Product_Price { get; set; }


        public String Product_ImageUrl { get; set; }


        public int Quantity { get; set; }


        public int User_ID { get; set; }


        public DateTime payment_Date { get; set; }

    }
}
