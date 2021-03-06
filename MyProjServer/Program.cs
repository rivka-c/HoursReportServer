using DAL;
using HoursReport_Service;
using Microsoft.AspNetCore;

public class Program
{
    public static void Main(string[] args)
    {
        var host = CreateWebHostBuilder(args).Build();
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
           /* try
            {
                var context = services.GetRequiredService<ApplicationDbContext>();
             //   DataSeeder.Initialize(context);
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred while seeding the database.");
            }*/
        }
        host.Run();
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args) => WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
}