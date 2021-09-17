using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using StoreAppBusiness;
using StoreAppBusiness.Interfaces;
using StoreAppDBContext.Models;

namespace StoreAppUI
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {

      services.AddControllers();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "StoreAppUI", Version = "v1" });
      });

      services.AddDbContext<AkilApplicationDBContext>(options =>
        {
          if (!options.IsConfigured)
          {
            options.UseSqlServer("Server=08162021dotnetuta.database.windows.net;Database=AkilApplicationDB;User Id=sqladmin;Password=Password12345;");
          }

        });

      services.AddScoped<ICustomerRepository, CustomerRepository>();
      services.AddScoped<IStoreRepository, StoreRepository>();
      services.AddScoped<IProductRepository, ProductRepository>();
      services.AddScoped<IOrderRepository, OrderRepository>();



    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "StoreAppUI v1"));
      }

      app.UseStatusCodePages();

      app.UseHttpsRedirection();

      app.UseRewriter(new RewriteOptions()
          .AddRedirect("^$", "index.html"));

      app.UseStaticFiles();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
