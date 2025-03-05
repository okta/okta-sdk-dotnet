using System.IO;
using System.Threading.Tasks;

namespace Okta.Sdk.Extensions;

public class FileOutput : IOutput
{
    public FileOutput(FileInfo file)
    {
        this.File = file;
    }
    protected FileInfo File { get; }
    public async ValueTask WriteAsync(string output)
    {
        await using StreamWriter streamWriter = File.AppendText();
        await streamWriter.WriteAsync(output);
    }
}