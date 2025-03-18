namespace Okta.Sdk.UnitTest.Internal;

public class MockDependency : IMockDependency
{
    public MockDependency(SubDependency subDependency)
    {
        this.SubDependency = subDependency;
    }
    
    public SubDependency SubDependency { get; set; }
}