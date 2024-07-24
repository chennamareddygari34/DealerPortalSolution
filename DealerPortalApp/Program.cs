using DealerPortalApp.Data;
using DealerPortalApp.Interfaces;
using DealerPortalApp.Models;
using DealerPortalApp.Repositories;
using DealerPortalApp.Services;
using Microsoft.EntityFrameworkCore;

namespace DealerPortalApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<DealerPortalContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

            builder.Services.AddScoped<IRepository<int, Applicant>, ApplicantRepository>();
            builder.Services.AddScoped<IApplicantService, ApplicantService>();
            builder.Services.AddScoped<IRepository<int, Vendor>, VendorRepository>();
            builder.Services.AddScoped<IVendorService, VendorService>();
            builder.Services.AddScoped<IRepository<int, Loan>, LoanRepository>();
            builder.Services.AddScoped<ILoanService, LoanService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
