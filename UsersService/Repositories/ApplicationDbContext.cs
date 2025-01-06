using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using UsersService.DTO;
using UsersService.Migrations;
using UsersService.Models;

namespace UsersService.Repositories
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<UserData> UserData { get; set; }
        public DbSet<CartData> CartData { get; set; }
        public DbSet<manager> managerData { get; set; }
        public DbSet<cartSummary> cartSummary { get; set; }
        public DbSet<TotalPrice> totalPrice { get; set; }
        public DbSet<PaymentData> PaymentData { get; set; }
        public DbSet<ShoppingListSP> ShoppingListSP { get; set; }
        public DbSet<UserDataView> UserDataView { get; set; }
        public DbSet<PaymentView> PaymentView { get; set; }
        public DbSet<TotalFollowers> TotalFollowers { get; set; }





















        public List<cartSummary> GetCartSummary(int productId)
        {
            // استدعاء الإجراء المخزن باستخدام FromSqlRaw
            var productIdParam = new MySqlParameter("@id", productId);
            return cartSummary.FromSqlRaw("CALL GetCartSummary(@id)", productIdParam).ToList();
        }


        public List<TotalPrice> GetTotalPrice(int productId)
        {
            // استدعاء الإجراء المخزن باستخدام FromSqlRaw
            var productIdParam = new MySqlParameter("@id", productId);

            return totalPrice.FromSqlRaw("CALL GetTotalPrice(@id)", productIdParam)
                                .ToList(); // استخدم FirstOrDefault للحصول على الصف الأول فقط

             
        }



        public List<ShoppingListSP> GetShoppingListSP(int productId)
        {
            // إعداد معامل الإجراء المخزن
            var productIdParam = new MySqlParameter("@id", productId);

            // استدعاء الإجراء المخزن باستخدام FromSqlRaw
            return ShoppingListSP
                           .FromSqlRaw("CALL GetShoppingListSP(@id)", productIdParam)
                           .ToList();
        }






        //FUNCTION 
        [DbFunction("shoppinglistcount", "")]
        public static int ShoppingListCount()
        {
            // الدالة هنا للتعريف فقط، التنفيذ سيتم في قاعدة البيانات
            throw new NotSupportedException("This method is for use with LINQ-to-Entities only.");
        }






        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // إضافة قيد فريد على حقل User_Email باستخدام Fluent API
            modelBuilder.Entity<UserData>()
                .HasIndex(u => u.User_Email)
                .IsUnique(); // التأكد من أن القيمة فريدة

            modelBuilder.Entity<UserData>()
       .HasCheckConstraint("CK_UserData_User_PhoneNumber", "User_PhoneNumber REGEXP '^[0-9]{11}$'");



            // إضافة قيد فريد على حقل User_Email باستخدام Fluent API
            modelBuilder.Entity<manager>()
                .HasIndex(u => u.manager_Email)
                .IsUnique(); // التأكد من أن القيمة فريدة




            // تعريف كيان ShoppingListSP ككيان للقراءة فقط
            modelBuilder.Entity<ShoppingListSP>(entity =>
            {
                entity.HasNoKey(); // الإجراء المخزن لا يحتوي على مفتاح أساسي
                entity.ToTable("ShoppingListSP"); // اسم الكيان (يمكن تغييره، لكنه ليس ضروريًا هنا)
            });





            modelBuilder.Entity<CartData>()
         .HasIndex(c => c.User_ID)
         .HasDatabaseName("IDX_CartData_UserID_Search");









            //VIEW
            modelBuilder.Entity<UserDataView>()
              .ToView("userdatatodashboard")
              .HasNoKey(); // هذا يعادل [Keyless]

            modelBuilder.Entity<PaymentView>()
              .ToView("payment")
              .HasNoKey(); // هذا يعادل [Keyless]


            modelBuilder.Entity<TotalFollowers>()
             .ToView("totalfollowers")
             .HasNoKey(); // هذا يعادل [Keyless]




            //Stored Procedure
            modelBuilder.Entity<cartSummary>().HasNoKey();

            modelBuilder.Entity<TotalPrice>().HasNoKey();



            //FUNCTION 
            modelBuilder
           .HasDbFunction(typeof(ApplicationDbContext).GetMethod(nameof(ShoppingListCount)))
           .HasName("shoppinglistcount")
           .HasSchema(""); // إذا كانت الدالة ضمن مخطط مختلف، عدّل اسم المخطط هنا

        }




    







    }
}
