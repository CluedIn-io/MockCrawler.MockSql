using CluedIn.Crawling.MockSql.Core;

namespace CluedIn.Crawling.MockSql.Infrastructure.Factories
{
    public interface IMockSqlClientFactory
    {
        MockSqlClient CreateNew(MockSqlCrawlJobData mockSqlCrawlJobData);
    }
}
