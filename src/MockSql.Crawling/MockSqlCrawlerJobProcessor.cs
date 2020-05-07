using CluedIn.Crawling.MockSql.Core;

namespace CluedIn.Crawling.MockSql
{
    public class MockSqlCrawlerJobProcessor : GenericCrawlerTemplateJobProcessor<MockSqlCrawlJobData>
    {
        public MockSqlCrawlerJobProcessor(MockSqlCrawlerComponent component) : base(component)
        {
        }
    }
}
