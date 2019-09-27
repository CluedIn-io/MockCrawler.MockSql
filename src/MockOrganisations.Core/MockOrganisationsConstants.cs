using System;
using System.Collections.Generic;
using CluedIn.Core.Net.Mail;
using CluedIn.Core.Providers;

namespace CluedIn.Crawling.MockOrganisations.Core
{
  public class MockOrganisationsConstants
  {
    public struct KeyName
    {
      public static readonly string ApiKey = nameof(ApiKey);
    }

    public const string CodeOrigin = "MockOrganisations";
    public const string ProviderRootCodeValue = "MockOrganisations";
    public const string CrawlerName = "MockOrganisationsCrawler";
    public const string CrawlerComponentName = "MockOrganisationsCrawler";
    public const string CrawlerDescription = "MockOrganisations is a ... to be completed ..."; // TODO complete the crawler description
    public const string CrawlerDisplayName = "MockOrganisations";  // TODO RJ - this field is never used can it be removed ?
    public const string Uri = "http://www.sampleurl.com";

     

    public static readonly Guid ProviderId = Guid.Parse("28fa07c2-34bb-4f06-8661-4c95f4b6e6dd");   // TODO: Replace value
    public const string ProviderName = "MockOrganisations";         // TODO: Replace value
    public const bool SupportsConfiguration = true;             // TODO: Replace value
    public const bool SupportsWebHooks = false;             // TODO: Replace value
    public const bool SupportsAutomaticWebhookCreation = true;             // TODO: Replace value
    public const bool RequiresAppInstall = false;            // TODO: Replace value
    public const string AppInstallUrl = null;             // TODO: Replace value
    public const string ReAuthEndpoint = null;             // TODO: Replace value
    public const string IconUri = "https://s3-eu-west-1.amazonaws.com/staticcluedin/bitbucket.png"; // TODO: Replace value

    public static readonly ComponentEmailDetails ComponentEmailDetails = new ComponentEmailDetails
    {
      Features = new Dictionary<string, string>
            {
                                       { "Tracking",        "Expenses and Invoices against customers" },
                                       { "Intelligence",    "Aggregate types of invoices and expenses against customers and companies." }
                                   },
      Icon = new Uri(IconUri),
      ProviderName = ProviderName,
      ProviderId = ProviderId,
      Webhooks = SupportsWebHooks
    };

    public static IProviderMetadata CreateProviderMetadata()
    {
      return new ProviderMetadata
      {
        Id = ProviderId,
        ComponentName = CrawlerName,
        Name = ProviderName,
        Type = "Cloud",
        SupportsConfiguration = SupportsConfiguration,
        SupportsWebHooks = SupportsWebHooks,
        SupportsAutomaticWebhookCreation = SupportsAutomaticWebhookCreation,
        RequiresAppInstall = RequiresAppInstall,
        AppInstallUrl = AppInstallUrl,
        ReAuthEndpoint = ReAuthEndpoint,
        ComponentEmailDetails = ComponentEmailDetails
      };
    }
  }
}
