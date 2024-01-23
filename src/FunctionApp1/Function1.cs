using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;

namespace FunctionApp1;

public class Function1
{
    private readonly IMyService _myService;
    private readonly IMyIckyDependency _myIckyDependency;

    public Function1(IMyService myService, IMyIckyDependency myIckyDependency)
    {
        _myService = myService;
        _myIckyDependency = myIckyDependency;
    }
    [FunctionName("Function1")]
    public Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req)
    {
        var resultFromMyService = _myService.MyMethod("Hello");
        var resultFromMyOtherService = _myIckyDependency.Hello();

        return Task.FromResult<IActionResult>(new OkObjectResult($"{resultFromMyService} {resultFromMyOtherService}"));
    }
}