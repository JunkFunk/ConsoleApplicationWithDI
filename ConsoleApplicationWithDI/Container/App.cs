using ConsoleApplicationWithDI.Container;
using ConsoleApplicationWithDI.Model;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;

namespace ConsoleApplicationWithDI
{
    public class App
    {
        private readonly ITestService _testService;
        private readonly ILogger<App> _logger;
        private readonly AppSetting _config;

        public App(ITestService testService, ILogger<App> logger, IOptions<AppSetting> config)
        {
            _testService = testService;
            _logger = logger;
            _config = config.Value;
        }

        public void Run()
        {
            _logger.LogInformation($"This is a console application for {_config.Title}");
            _testService.Run();
            Console.ReadKey();
        }
    }
}
