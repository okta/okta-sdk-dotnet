using System;
using System.Threading.Tasks;

namespace Okta.Sdk.Extensions;

public class ConsoleOutput : IOutput
{
    public async ValueTask WriteAsync(string output)
    {
        Console.WriteLine(output.Trim());
    }
}