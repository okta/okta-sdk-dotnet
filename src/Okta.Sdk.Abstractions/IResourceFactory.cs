namespace Okta.Sdk.Abstractions
{
    public interface IResourceFactory
    {
        T Create<T>(IDeltaDictionary<string, object> data);
    }
}
