using BankLoanManagement.Services;
using DealerPortalApp.Data;
using DealerPortalApp.Interfaces;
using DealerPortalApp.Models;
using DealerPortalApp.Repositories;
using DealerPortalApp.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json.Serialization;

namespace DealerPortalApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                options.JsonSerializerOptions.MaxDepth = 64; // Adjust depth if needed
            }); ;

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<DealerPortalContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

            builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

            builder.Services.AddScoped<IRepository<int, Applicant>, ApplicantRepository>();
            builder.Services.AddScoped<IApplicantService, ApplicantService>();
            builder.Services.AddScoped<IRepository<int, Vendor>, VendorRepository>();
            builder.Services.AddScoped<IVendorService, VendorService>();
            builder.Services.AddScoped<IRepository<int, Loan>, LoanRepository>();
            builder.Services.AddScoped<ILoanService, LoanService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IRepository<string, User>, UserRepository>();
            builder.Services.AddScoped<ITokenService, TokenService>();


            builder.Services.AddCors(opts =>
            {
                opts.AddPolicy("Cors", options =>
                {
                    options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseCors("Cors");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}

