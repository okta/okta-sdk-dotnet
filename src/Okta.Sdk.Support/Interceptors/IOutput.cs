using System.Threading.Tasks;

namespace Okta.Sdk.UnitTest.Interceptors;

public interface IOutput
{
    ValueTask WriteAsync(string output);
}