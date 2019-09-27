using CluedIn.Crawling.MockOrganisations.Core;

namespace CluedIn.Crawling.MockOrganisations.Infrastructure.Factories
{
    public interface IMockOrganisationsClientFactory
    {
        MockOrganisationsClient CreateNew(MockOrganisationsCrawlJobData mockorganisationsCrawlJobData);
    }
}
