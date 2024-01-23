using FunctionApp1;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]
namespace FunctionApp1;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services.AddSingleton<IMyService, MyService>();
        BootstrapMyIckyDependency(builder);
    }

    public virtual void BootstrapMyIckyDependency(IFunctionsHostBuilder builder)
    {
        builder.Services.AddSingleton<MyIckyDependency>();
    }
}