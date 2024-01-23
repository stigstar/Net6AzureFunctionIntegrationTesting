namespace FunctionApp1;

public class MyService : IMyService
{
    public string MyMethod(string myArgument)
    {
        return myArgument;
    }
}