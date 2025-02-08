using FlotteApplication;

namespace FlotteApplcation
{
    public class Program
    {
        public static void Main(String[] args)
        {
            BuildWebHost(args).Run();
        }
        public static IHost BuildWebHost(String[] args) => Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
        .Build();
    }
}