using FakeItEasy;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace FunctionApp1.IntegrationTest;

public class TestStartup : Startup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        base.Configure(builder);

        builder.Services.AddTransient<Function1>(); //We need to register the function by hand when running the test
        builder.Services.BuildServiceProvider(new ServiceProviderOptions { ValidateScopes = true });
    }

    public override void BootstrapMyIckyDependency(IFunctionsHostBuilder builder)
    {
        builder.Services.AddSingleton(A.Fake<IMyIckyDependency>());
    }
}