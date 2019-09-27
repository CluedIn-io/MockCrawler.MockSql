using System.Collections.Generic;
using CluedIn.Crawling.MockOrganisations.Core;

namespace Tests.Integration.MockOrganisations
{
  public static class MockOrganisationsConfiguration
  {
    public static Dictionary<string, object> Create()
    {
      return new Dictionary<string, object>
            {
                { MockOrganisationsConstants.KeyName.ApiKey, "demo" }
            };
    }
  }
}
