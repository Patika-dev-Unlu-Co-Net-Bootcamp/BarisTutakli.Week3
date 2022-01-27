using BarisTutakli.WebApi.DbOperations;
using BarisTutakli.WebApi.Models.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Common.Base.Concrete;
using WebApi.ProductOperations;
using WebApi.ProductOperations.Handlers.CommandHandlers;
using WebApi.ProductOperations.Handlers.QueryHandlers;

namespace WebApi.Services
{
    public static class CustomMediatR
    {
        public static void AddServices(this IServiceCollection services)
        {

            services.AddScoped<BaseReadAllRepository<Product, ECommerceDbContext>>();
            services.AddScoped<GetProductsQueryHandler>();

            services.AddScoped<BaseReadRepository<Product, ECommerceDbContext>>();
            services.AddScoped<GetProductDetailQueryHandler>();

            services.AddScoped<BaseCreateRepository<Product, ECommerceDbContext>>();
            services.AddScoped<CreateProductCommandHandler>();

            services.AddScoped<BaseDeleteRepository<Product, ECommerceDbContext>>();
            services.AddScoped<DeleteProductCommandHandler>();

            services.AddScoped<BaseUpdateRepository<Product, ECommerceDbContext>>();
            services.AddScoped<UpdateProductCommandHandler>();

          
       
        }
    }
}
