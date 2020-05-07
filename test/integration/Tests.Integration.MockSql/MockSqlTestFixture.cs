using CluedIn.Crawling;
using CluedIn.Crawling.MockSql.Core;
using System.IO;
using System.Reflection;
using CrawlerIntegrationTesting.Clues;

namespace Tests.Integration.MockSql
{
    public class MockSqlTestFixture
    {
        public MockSqlTestFixture()
        {
            var executingFolder = new FileInfo(Assembly.GetExecutingAssembly().CodeBase.Substring(8)).DirectoryName;
            var p = new DebugCrawlerHost<MockSqlCrawlJobData>(executingFolder, MockSqlConstants.ProviderName);

            ClueStorage = new ClueStorage();

            p.ProcessClue += ClueStorage.AddClue;            

            p.Execute(MockSqlConfiguration.Create(), MockSqlConstants.ProviderId);
        }

        public ClueStorage ClueStorage { get; }

        public void Dispose()
        {
        }

    }
}


