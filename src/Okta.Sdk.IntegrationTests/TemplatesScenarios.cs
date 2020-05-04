using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Okta.Sdk.IntegrationTests
{
    public class TemplatesScenarios
    {
        [Fact]
        public async Task CreateSmsTemplate()
        {
            var client = TestClient.Create();
            var randomSuffix = DateTime.UtcNow.ToString();

            var smsTranslations = new SmsTemplateTranslations();
            smsTranslations.SetProperty("es", "${org.name}: el código de verificación es ${code}");
            smsTranslations.SetProperty("fr", "${org.name}: votre code de vérification est ${code}");

            var createdTemplate = await client.Templates.CreateSmsTemplateAsync(
                new SmsTemplate()
                {
                    Name = $"dotnet-sdk:Create{randomSuffix}",
                    Type = SmsTemplateType.SmsVerifyCode,
                    Template = "${org.name}: your verification code is ${code}",
                    Translations = smsTranslations,
                });

            try
            {
                createdTemplate.Should().NotBeNull();
                createdTemplate.Name.Should().Be($"dotnet-sdk:Create{randomSuffix}");
                createdTemplate.Type.Should().Be(SmsTemplateType.SmsVerifyCode);
                createdTemplate.Template.Should().Be("${org.name}: your verification code is ${code}");
                createdTemplate.Translations.Should().NotBeNull();
                createdTemplate.Translations.GetProperty<string>("es").Should().Be("${org.name}: el código de verificación es ${code}");
                createdTemplate.Translations.GetProperty<string>("fr").Should().Be("${org.name}: votre code de vérification est ${code}");
            }
            finally
            {
                await client.Templates.DeleteSmsTemplateAsync(createdTemplate.Id);
            }
        }

        [Fact]
        public async Task ListSmsTemplates()
        {
            var client = TestClient.Create();
            var randomSuffix = DateTime.UtcNow.ToString();

            var smsTranslations = new SmsTemplateTranslations();
            smsTranslations.SetProperty("es", "${org.name}: el código de verificación es ${code}");
            smsTranslations.SetProperty("fr", "${org.name}: votre code de vérification est ${code}");

            var createdTemplate = await client.Templates.CreateSmsTemplateAsync(
                new SmsTemplate()
                {
                    Name = $"dotnet-sdk:List{randomSuffix}",
                    Type = SmsTemplateType.SmsVerifyCode,
                    Template = "${org.name}: your verification code is ${code}",
                    Translations = smsTranslations,
                });

            try
            {
                var templates = await client.Templates.ListSmsTemplates().ToListAsync();

                templates.Should().NotBeNullOrEmpty();

                var retrievedTemplate = templates.FirstOrDefault(x => x.Id == createdTemplate.Id);
                retrievedTemplate.Name.Should().Be($"dotnet-sdk:List{randomSuffix}");
                retrievedTemplate.Type.Should().Be(SmsTemplateType.SmsVerifyCode);
                retrievedTemplate.Template.Should().Be("${org.name}: your verification code is ${code}");
                retrievedTemplate.Translations.Should().NotBeNull();
                retrievedTemplate.Translations.GetProperty<string>("es").Should().Be("${org.name}: el código de verificación es ${code}");
                retrievedTemplate.Translations.GetProperty<string>("fr").Should().Be("${org.name}: votre code de vérification est ${code}");
            }
            finally
            {
                await client.Templates.DeleteSmsTemplateAsync(createdTemplate.Id);
            }
        }

        [Fact]
        public async Task GetSmsTemplate()
        {
            var client = TestClient.Create();
            var randomSuffix = DateTime.UtcNow.ToString();

            var smsTranslations = new SmsTemplateTranslations();
            smsTranslations.SetProperty("es", "${org.name}: el código de verificación es ${code}");
            smsTranslations.SetProperty("fr", "${org.name}: votre code de vérification est ${code}");

            var createdTemplate = await client.Templates.CreateSmsTemplateAsync(
                new SmsTemplate()
                {
                    Name = $"dotnet-sdk:Get-{randomSuffix}",
                    Type = SmsTemplateType.SmsVerifyCode,
                    Template = "${org.name}: your verification code is ${code}",
                    Translations = smsTranslations,
                });

            try
            {
                var retrievedTemplate = await client.Templates.GetSmsTemplateAsync(createdTemplate.Id);

                retrievedTemplate.Should().NotBeNull();
                retrievedTemplate.Name.Should().Be($"dotnet-sdk:Get-{randomSuffix}");
                retrievedTemplate.Type.Should().Be(SmsTemplateType.SmsVerifyCode);
                retrievedTemplate.Template.Should().Be("${org.name}: your verification code is ${code}");
                retrievedTemplate.Translations.Should().NotBeNull();
                retrievedTemplate.Translations.GetProperty<string>("es").Should().Be("${org.name}: el código de verificación es ${code}");
                retrievedTemplate.Translations.GetProperty<string>("fr").Should().Be("${org.name}: votre code de vérification est ${code}");
            }
            finally
            {
                await client.Templates.DeleteSmsTemplateAsync(createdTemplate.Id);
            }
        }

        [Fact]
        public async Task UpdateSmsTemplate()
        {
            var client = TestClient.Create();
            var randomSuffix = DateTime.UtcNow.ToString();

            var smsTranslations = new SmsTemplateTranslations();
            smsTranslations.SetProperty("es", "${org.name}: el código de verificación es ${code}");
            smsTranslations.SetProperty("fr", "${org.name}: votre code de vérification est ${code}");

            var createdTemplate = await client.Templates.CreateSmsTemplateAsync(
                new SmsTemplate()
                {
                    Name = $"dotnet-sdk:Update-{randomSuffix}",
                    Type = SmsTemplateType.SmsVerifyCode,
                    Template = "${org.name}: your verification code is ${code}",
                    Translations = smsTranslations,
                });

            try
            {
                createdTemplate.Template = "updated: ${org.name}: your verification code is ${code}";
                var updatedTemplate = await client.Templates.UpdateSmsTemplateAsync(createdTemplate, createdTemplate.Id);

                updatedTemplate.Should().NotBeNull();
                updatedTemplate.Name.Should().Be($"dotnet-sdk:Update-{randomSuffix}");
                updatedTemplate.Type.Should().Be(SmsTemplateType.SmsVerifyCode);
                updatedTemplate.Template.Should().Be("updated: ${org.name}: your verification code is ${code}");
                updatedTemplate.Translations.Should().NotBeNull();
                updatedTemplate.Translations.GetProperty<string>("es").Should().Be("${org.name}: el código de verificación es ${code}");
                updatedTemplate.Translations.GetProperty<string>("fr").Should().Be("${org.name}: votre code de vérification est ${code}");
            }
            finally
            {
                await client.Templates.DeleteSmsTemplateAsync(createdTemplate.Id);
            }
        }

        [Fact]
        public async Task PartialUpdateSmsTemplate()
        {
            var client = TestClient.Create();
            var randomSuffix = DateTime.UtcNow.ToString();

            var smsTranslations = new SmsTemplateTranslations();
            smsTranslations.SetProperty("es", "${org.name}: el código de verificación es ${code}");
            smsTranslations.SetProperty("fr", "${org.name}: votre code de vérification est ${code}");

            var createdTemplate = await client.Templates.CreateSmsTemplateAsync(
                new SmsTemplate()
                {
                    Name = $"dotnet-sdk:PartialUpdate-{randomSuffix}",
                    Type = SmsTemplateType.SmsVerifyCode,
                    Template = "${org.name}: your verification code is ${code}",
                    Translations = smsTranslations,
                });

            try
            {
                var tempTemplate = new SmsTemplate()
                {
                    Translations = new SmsTemplateTranslations(),
                };

                // Add translation
                tempTemplate.Translations.SetProperty("de", "${org.name}: ihre bestätigungscode ist ${code}.");

                var updatedTemplate = await client.Templates.PartialUpdateSmsTemplateAsync(tempTemplate, createdTemplate.Id);

                updatedTemplate.Should().NotBeNull();
                updatedTemplate.Name.Should().Be($"dotnet-sdk:PartialUpdate-{randomSuffix}");
                updatedTemplate.Type.Should().Be(SmsTemplateType.SmsVerifyCode);
                updatedTemplate.Template.Should().Be("${org.name}: your verification code is ${code}");
                updatedTemplate.Translations.Should().NotBeNull();
                updatedTemplate.Translations.GetProperty<string>("es").Should().Be("${org.name}: el código de verificación es ${code}");
                updatedTemplate.Translations.GetProperty<string>("fr").Should().Be("${org.name}: votre code de vérification est ${code}");
                updatedTemplate.Translations.GetProperty<string>("de").Should().Be("${org.name}: ihre bestätigungscode ist ${code}.");
            }
            finally
            {
                await client.Templates.DeleteSmsTemplateAsync(createdTemplate.Id);
            }
        }
    }
}
