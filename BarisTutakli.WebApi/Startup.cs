using BarisTutakli.WebApi.Common;
using BarisTutakli.WebApi.Common.Abstract;
using BarisTutakli.WebApi.DbOperations;
using BarisTutakli.WebApi.Middleswares;
using BarisTutakli.WebApi.Services;
using BarisTutakli.WebApi.Services.Abstract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.ProductOperations.Handlers.CommandHandlers;
using MediatR;
using WebApi.ProductOperations.Handlers.QueryHandlers;
using System.Reflection;
using WebApi.Common.Base.Concrete;
using BarisTutakli.WebApi.Models.Concrete;
using WebApi.Common.Base.Abstract;
using BarisTutakli.WebApi.Common.Entities;
using WebApi.Services;

namespace BarisTutakli.WebApi
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BarisTutakli.WebApi", Version = "v1" });
            });
            services.AddDbContext<ECommerceDbContext>(options => options.UseInMemoryDatabase(databaseName: "ECommerceDb"));
            //services.AddSingleton<ILoggerService, ConsoleLogger>();
            services.AddSingleton<ILoggerService, DBLogger>();


            services.AddScoped<BaseReadAllRepository<Product, ECommerceDbContext>>();
            services.AddScoped<GetProductsQueryHandler>();

            // Register groups of services with extension methods
            // IServiceCollection is extended by CustomMeditT class located in Services folder.
            services.AddServices();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BarisTutakli.WebApi v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseCustomExceptionMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
