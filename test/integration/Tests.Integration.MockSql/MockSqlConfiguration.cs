using System.Collections.Generic;
using CluedIn.Crawling.MockSql.Core;

namespace Tests.Integration.MockSql
{
  public static class MockSqlConfiguration
  {
    public static Dictionary<string, object> Create()
    {
      return new Dictionary<string, object>
            {
                { MockSqlConstants.KeyName.ConnectionString, "Server=localhost;Database=Andrei;Trusted_Connection=True;" }
            };
    }
  }
}
