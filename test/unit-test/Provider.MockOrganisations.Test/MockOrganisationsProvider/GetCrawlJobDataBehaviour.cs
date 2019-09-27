using AutoFixture.Xunit2;
using Should;
using System;
using System.Collections.Generic;

using Xunit;

namespace Provider.MockOrganisations.Test.MockOrganisationsProvider
{
  public class GetCrawlJobDataBehaviour : MockOrganisationsProviderTest
  {
    [Theory]
    [InlineAutoData]
    public void GetCrawlJobDataTests(Dictionary<string, object> dictionary, Guid organizationId, Guid userId, Guid providerDefinitionId)
    {
      //TODO: passing null here does not look good
      Sut.GetCrawlJobData(null, dictionary, organizationId, userId, providerDefinitionId)
          .ShouldNotBeNull();
    }
  }
}
