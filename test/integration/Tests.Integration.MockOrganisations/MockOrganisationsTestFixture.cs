using CluedIn.Crawling;
using CluedIn.Crawling.MockOrganisations.Core;
using System.IO;
using System.Reflection;
using CrawlerIntegrationTesting.Clues;

namespace Tests.Integration.MockOrganisations
{
    public class MockOrganisationsTestFixture
    {
        public MockOrganisationsTestFixture()
        {
            var executingFolder = new FileInfo(Assembly.GetExecutingAssembly().CodeBase.Substring(8)).DirectoryName;
            var p = new DebugCrawlerHost<MockOrganisationsCrawlJobData>(executingFolder, MockOrganisationsConstants.ProviderName);

            ClueStorage = new ClueStorage();

            p.ProcessClue += ClueStorage.AddClue;            

            p.Execute(MockOrganisationsConfiguration.Create(), MockOrganisationsConstants.ProviderId);
        }

        public ClueStorage ClueStorage { get; }

        public void Dispose()
        {
        }

    }
}


