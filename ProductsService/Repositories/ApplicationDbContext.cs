using Microsoft.EntityFrameworkCore;
using ProductsService.DTO;
using ProductsService.Models;


namespace ProductsService.Repositories
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Product> ProductData { get; set; }
        public DbSet<Category> CategoryData { get; set; }
        public DbSet<categoryView> categoryView { get; set; }
        public DbSet<CategoriesListCount> CategoriesListCount { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // إضافة قيد فريد على حقل User_Email باستخدام Fluent API
            modelBuilder.Entity<Product>()
                .HasIndex(u => u.Product_Name)
              .IsUnique();

       //     modelBuilder.Entity<Product>() // هنا يجب أن تشير إلى الكيان Order
       //.HasOne<Category>(p => p.Category)   // تشير إلى الكيان المرتبط
       //.WithMany()              // تحدد العلاقة (واحد إلى متعدد)
       //.HasForeignKey(o => o.Category_Id) // المفتاح الأجنبي
       //.OnDelete(DeleteBehavior.Cascade); // سلوك الحذف







            // إضافة قيد فريد على حقل User_Email باستخدام Fluent API
            modelBuilder.Entity<Category>()
                .HasIndex(u => u.Category_Name)
                .IsUnique(); // التأكد من أن القيمة فريدة



            modelBuilder.Entity<categoryView>()
            .ToView("categorieslist")
            .HasNoKey(); // هذا يعادل [Keyless]



            modelBuilder.Entity<CategoriesListCount>()
            .ToView("categorieslistcount")
            .HasNoKey(); // هذا يعادل [Keyless]







        }












    }

}
