using System.ServiceModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using UsersService.DTO;
using UsersService.Models;
using UsersService.Repositories;

[ServiceContract]
public class PaymentService
{
    private readonly ApplicationDbContext _context;

    public PaymentService(ApplicationDbContext context)
    {
        _context = context;
    }

    [OperationContract]
    public String SavePaymentData(emailRequest email)
    {

        UserData userData = _context.UserData.FirstOrDefault(e => e.User_Email == email.Email);

        List<CartData> cartData = _context.CartData.Where(e=>e.User_ID==userData.User_ID).ToList();


        foreach (var cartItem in cartData)
        {
            var paymentData = new PaymentData
            {
                Cart_ID = cartItem.Cart_ID,
                Product_ID = cartItem.Product_ID,
                Product_Name = cartItem.Product_Name,
                Product_Discription = cartItem.Product_Discription,
                Product_Price = cartItem.Product_Price,
                Product_ImageUrl = cartItem.Product_ImageUrl,
                Quantity = cartItem.Quantity,
                User_ID = userData.User_ID,
                payment_Date = DateTime.Now // تحديد وقت الدفع الحالي
            };

            _context.PaymentData.Add(paymentData);
        }

        // حفظ البيانات في قاعدة البيانات
        try
        {
            _context.SaveChanges();
            return "Payment data saved successfully.";
        }
        catch (Exception ex)
        {
            return $"An error occurred: {ex.Message}";
        }

    }







   








}
