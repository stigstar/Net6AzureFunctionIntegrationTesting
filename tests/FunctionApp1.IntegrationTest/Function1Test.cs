using System.Threading.Tasks;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace FunctionApp1.IntegrationTest;

public class Function1Test
{
    [Fact]
    public async Task Run_WhenCalled_ShouldDoStuff()
    {
        //arrange
        var hostBuilder = new HostBuilder();
        hostBuilder.ConfigureWebJobs(b => b.UseWebJobsStartup(typeof(TestStartup), new WebJobsBuilderContext(), NullLoggerFactory.Instance));
        var host = hostBuilder.Start();

        A.CallTo(() => host.Services.GetRequiredService<IMyIckyDependency>().Hello()).Returns("World!");


        //act
        var result = await host.Services.GetRequiredService<Function1>().Run(null).ConfigureAwait(continueOnCapturedContext: false);


        //assert
        Assert.Equal("Hello World!", ((OkObjectResult)result).Value);
    }
}