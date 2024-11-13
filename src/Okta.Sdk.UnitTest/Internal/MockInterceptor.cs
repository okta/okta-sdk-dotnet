using RestSharp.Interceptors;

namespace Okta.Sdk.UnitTest.Internal;

public class MockInterceptor : Interceptor
{
    public MockInterceptor(IMockDependency mockDependency)
    {
        this.MockDependency = mockDependency;
    }
    
    public IMockDependency MockDependency { get; set; }
}