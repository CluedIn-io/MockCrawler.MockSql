using CluedIn.Core.Agent.Jobs;
using CluedIn.Core.Crawling;
using CluedIn.Crawling;
using CluedIn.Crawling.MockSql;
using CluedIn.Crawling.MockSql.Core;
using CluedIn.Crawling.MockSql.Infrastructure.Factories;
using Moq;
using Should;
using Xunit;

namespace Crawling.MockSql.Test
{
  public class MockSqlCrawlerBehaviour
  {
    private readonly ICrawlerDataGenerator _sut;

    public MockSqlCrawlerBehaviour()
    {
        var nameClientFactory = new Mock<IMockSqlClientFactory>();

        _sut = new MockSqlCrawler(nameClientFactory.Object);
    }

    [Fact]
    public void GetDataReturnsData()
    {
      var jobData = new CrawlJobData();

      _sut.GetData(jobData)
          .ShouldNotBeNull();
    }
  }
}
