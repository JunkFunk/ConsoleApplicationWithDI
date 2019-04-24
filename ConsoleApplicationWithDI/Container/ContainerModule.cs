using InversionOfControl.Shared.Contract;

namespace ConsoleApplicationWithDI.Container
{
    public class ContainerModule : IInversionOfControlModule
    {
        public void Configure(IInversionOfControlConfiguration configuration)
        {
            configuration.RegisterTransient<ITestService, TestService>();
            configuration.RegisterTransient<App>();
        }
    }
}
