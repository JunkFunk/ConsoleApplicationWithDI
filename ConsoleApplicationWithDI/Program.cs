using ConsoleApplicationWithDI.Container;
using ConsoleApplicationWithDI.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System.IO;

namespace ConsoleApplicationWithDI
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
               .WriteTo.File("consoleapp.log")
               .CreateLogger();

            // create service collection
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // create service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // entry to run app
            serviceProvider.GetService<App>().Run();
        }

        private static void ConfigureServices(ServiceCollection serviceCollection)
        {
            serviceCollection.AddLogging(configure => configure.AddConsole().AddDebug().AddSerilog());

            var configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("app-setting.json", false)
                   .Build();

            serviceCollection.AddOptions();

            serviceCollection.Configure<AppSetting>(configuration.GetSection("Configuration"));

            // add services
            serviceCollection.AddTransient<ITestService, TestService>();

            // add app
            serviceCollection.AddTransient<App>();
        }
    }
}
