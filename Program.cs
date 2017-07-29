using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Sign
{
    public class Program
    {
        public static void Main(string[] args)
        {
           
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory()).UseUrls("http://192.168.43.53:9090")
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();

            host.Run();
        }
    }
}
