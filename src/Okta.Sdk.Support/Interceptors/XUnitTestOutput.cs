using Xunit.Abstractions;

namespace Okta.Sdk.UnitTest.Interceptors;

public class XUnitTestOutput : IOutput
{
    public XUnitTestOutput(ITestOutputHelper output)
    {
        this.TestOutputHelper = output;
    }

    private ITestOutputHelper TestOutputHelper { get; }
    
    public async ValueTask WriteAsync(string output)
    {
        TestOutputHelper.WriteLine(output.Trim());
    }
}