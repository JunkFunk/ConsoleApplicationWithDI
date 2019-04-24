using ConsoleApplicationWithDI.Model;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ConsoleApplicationWithDI.Container
{
    public class TestService : ITestService
    {
        private readonly ILogger<TestService> _logger;
        private readonly AppSetting _config;

        public TestService(ILogger<TestService> logger, IOptions<AppSetting> config)
        {
            _logger = logger;
            _config = config.Value;
        }

        public void Run()
        {
            _logger.LogWarning($"Wow! We are now in the test service of: {_config.Title}");
        }
    }
}
