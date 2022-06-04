using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using Microsoft.Extensions.Hosting;
using NLog.Web;
using Cw.Vanti.Integrations.Utils;

namespace Cw.Vanti.Integrations.WebApi
{
    /// <summary>
    /// 
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            // CreateHostBuilder(args).Build().Run();
            CreateWebHostBuilder(args).Build().Run();

        }

        /// <summary>
        /// Initializes a new instance of the Microsoft.AspNetCore.Hosting.WebHostBuilder
        /// class with pre-configured defaults.
        /// </summary>
        /// <returns>objeto de tipo <see cref="IWebHostBuilder"/></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                var configuration = config.Build();

                IKeyVault keyVault = SecretKeyManager.GetSecretKey(configuration["AzureKeyVaulSettings:AzureADApplicationId"], configuration["AzureKeyVaulSettings:AzureADPassword"]);
                var keyVaultEndpoint = configuration["AzureKeyVaulSettings:UrlAzureKeyVault"];
                config.AddAzureKeyVault(
                    keyVaultEndpoint, keyVault.GetKeyVaultClient(), new DefaultKeyVaultSecretManager());
            })
            .UseIISIntegration()
            .UseNLog()
            .UseStartup<Startup>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

    }
}
