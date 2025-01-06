
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using SoapCore;
using UsersService.Models;
using UsersService.Repositories;
using static SoapCore.DocumentationWriter.SoapDefinition;

namespace UsersService
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            // تسجيل الخدمات
            builder.Services.AddScoped<PaymentService>();




            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //mysql
            string connectionString = "Server=localhost;Database=e_commerce;User=root;";
            var serverVersion = ServerVersion.AutoDetect(connectionString);
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, serverVersion)
);



            //CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp", policy =>
                {
                    policy.WithOrigins("http://localhost:3000") // ????? ????? React
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.UseCors("AllowReactApp");




            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.UseSoapEndpoint<PaymentService>(
                    "/PaymentService.asmx",
                    new SoapEncoderOptions(),
                    SoapSerializer.XmlSerializer // أو DataContractSerializer
                    
                );
            });








            app.MapControllers();







          



            app.Run();
        }
    }
}
