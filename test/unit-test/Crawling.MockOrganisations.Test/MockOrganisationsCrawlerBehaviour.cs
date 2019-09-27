using CluedIn.Core.Crawling;
using CluedIn.Crawling;
using CluedIn.Crawling.MockOrganisations;
using CluedIn.Crawling.MockOrganisations.Infrastructure.Factories;
using Moq;
using Should;
using Xunit;

namespace Crawling.MockOrganisations.Test
{
  public class MockOrganisationsCrawlerBehaviour
  {
    private readonly ICrawlerDataGenerator _sut;

    public MockOrganisationsCrawlerBehaviour()
    {
        var nameClientFactory = new Mock<IMockOrganisationsClientFactory>();

        _sut = new MockOrganisationsCrawler(nameClientFactory.Object);
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
