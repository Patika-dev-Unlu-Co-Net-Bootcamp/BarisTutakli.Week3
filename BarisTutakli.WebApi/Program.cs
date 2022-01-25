namespace BarisTutakli.WebApi
{
    using BarisTutakli.WebApi.Common.Abstract;
    using BarisTutakli.WebApi.DbOperations;
    using BarisTutakli.WebApi.Services;
    using global::WebApi.Services;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    /// <summary>
    /// Defines the <see cref="Program" />.
    /// </summary>
    public class Program
    {
    
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                DataGenerator.Initialize(services);
            }
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                Printer.Initialize(services);
            }
         

            
            host.Run();
        }

      
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
