namespace UsersService.DTO
{
    public class PaymentView
    {
        public String User_Name { get; set; }
        public String User_Surname { get; set; }
        public String Product_Name { get; set; }
        public String Product_ImageUrl { get; set; }
        public int Quantity { get; set; }
        public DateTime payment_Date { get; set; }


    }
}
