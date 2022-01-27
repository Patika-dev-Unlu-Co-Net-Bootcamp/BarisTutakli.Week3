using CleanArch.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infrastructure
{
    public static class DependencyContainer
    {

        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<CinemaContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));
            return services;
        }
    }
}
