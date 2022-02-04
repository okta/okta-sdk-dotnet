using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Okta.Sdk.IntegrationTests
{
    public class DomainScenarios
    {
        //[Fact]
        //public async Task CreateDomain()
        //{
        //    var oktaClient = TestClient.Create();
        //    var domainsClient = oktaClient.Domains;
        //    var domainName = $"domain{new Random().Next(1000000)}.example.com";
        //    var newDomain = new Domain
        //    {
        //        DomainName = domainName,
        //        CertificateSourceType = DomainCertificateSourceType.Manual,
        //    };

        //    var createDomainResult = await domainsClient.CreateDomainAsync(newDomain);
        //    createDomainResult.DomainName.Should().Be(domainName);
        //    createDomainResult.CertificateSourceType.Should().Be(DomainCertificateSourceType.Manual);
        //    createDomainResult.ValidationStatus.Should().Be(DomainValidationStatus.NotStarted);
        //    createDomainResult.Id.Should().NotBeNullOrEmpty();

        //    await domainsClient.DeleteDomainAsync(createDomainResult.Id);
        //}

        //[Fact]
        //public async Task GetDomain()
        //{
        //    var oktaClient = TestClient.Create();
        //    var domainsClient = oktaClient.Domains;
        //    var domainName = $"domain{new Random().Next(1000000)}.example.com";
        //    var newDomain = new Domain
        //    {
        //        DomainName = domainName,
        //        CertificateSourceType = DomainCertificateSourceType.Manual,
        //    };

        //    var createDomainResult = await domainsClient.CreateDomainAsync(newDomain);

        //    // Find the domain among all domains
        //    var domainList = await domainsClient.ListDomainsAsync();
        //    domainList.Domains.Should().Contain(x => x.DomainName == domainName);

        //    // Get the domain by Id
        //    var getDomainResult = await domainsClient.GetDomainAsync(createDomainResult.Id);
        //    getDomainResult.Id.Should().Be(createDomainResult.Id);
        //    getDomainResult.DomainName.Should().Be(createDomainResult.DomainName);
        //    getDomainResult.CertificateSourceType.Should().Be(createDomainResult.CertificateSourceType);
        //    getDomainResult.ValidationStatus.Should().Be(createDomainResult.ValidationStatus);

        //    await domainsClient.DeleteDomainAsync(createDomainResult.Id);

        //    domainList = await domainsClient.ListDomainsAsync();
        //    domainList.Domains.Should().NotContain(x => x.DomainName == domainName);
        //    await Assert.ThrowsAsync<OktaApiException>(() => domainsClient.GetDomainAsync(createDomainResult.Id));
        //}
    }
}
