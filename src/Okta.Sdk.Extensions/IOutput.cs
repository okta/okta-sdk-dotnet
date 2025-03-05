using System.Threading.Tasks;

namespace Okta.Sdk.Extensions;

public interface IOutput
{
    ValueTask WriteAsync(string output);
}