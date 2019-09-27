using CluedIn.Crawling.MockOrganisations.Core;

namespace CluedIn.Crawling.MockOrganisations
{
    public class MockOrganisationsCrawlerJobProcessor : GenericCrawlerTemplateJobProcessor<MockOrganisationsCrawlJobData>
    {
        public MockOrganisationsCrawlerJobProcessor(MockOrganisationsCrawlerComponent component) : base(component)
        {
        }
    }
}
