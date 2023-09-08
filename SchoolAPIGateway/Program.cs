using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPIGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).ConfigureAppConfiguration((HostingContext, config) => {
                    config.SetBasePath(HostingContext.HostingEnvironment.ContentRootPath)
                    .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
                });

    }
}

//using SchoolAPIGateway;
//using Ocelot.DependencyInjection;
//using Ocelot.Middleware;
//using Ocelot.Provider.Polly;
//using Microsoft.Extensions.Configuration;
//using System.Threading.Tasks;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//if (Directory.Exists("configurations") && File.Exists(Path.Combine("configurations", "ocelot.json")))
//{
//    builder.Configuration.AddJsonFile(Path.Combine("configurations", "ocelot.json"), optional: false, reloadOnChange: false);
//}
//else
//{
//    builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: false);
//}

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("_myAllowSpecificOrigins",
//    builder =>
//    {
//        builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
//    });
//});

////Host.CreateDefaultBuilder(args)
////                .ConfigureWebHostDefaults(webBuilder =>
////                {
////                    webBuilder.UseStartup<Startup>();
////                }).ConfigureAppConfiguration((HostingContext, config) => {
////                    config.SetBasePath(HostingContext.HostingEnvironment.ContentRootPath)
////                    .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
////                });

////builder.Services.AddControllers();
//builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true).AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

////builder.Services.AddOcelot().AddPolly().AddDelegatingHandler<AuthorizationDelegatingHandler>();

////app.UseHttpsRedirection();

//app.UseCors("_myAllowSpecificOrigins");

//app.UseAuthorization();

//app.MapControllers();

////app.UseOcelot().Wait();
//try
//{
//    app.UseOcelot();
//}
//catch (Exception ex)
//{
//    Console.WriteLine("An error occurred while configuring Ocelot: " + ex.Message);
//}

//app.Run();
