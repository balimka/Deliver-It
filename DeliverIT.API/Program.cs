using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace DeliverIT.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var db = new DeliverITDBContext();
            //db.Database.EnsureCreated();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
