using System;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using HSCFiscalRegistrar.Enums;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace HSCFiscalRegistrar
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
            
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

    }
}
