using System;
using CluedIn.Core.Logging;
using CluedIn.Core.Providers;
using CluedIn.Crawling.MockOrganisations.Core;
using CluedIn.Crawling.MockOrganisations.Core.Models;
using System.Collections.Generic;
using RestSharp;
using System.Data.SqlClient;
using System.Data;

namespace CluedIn.Crawling.MockOrganisations.Infrastructure
{
  public class MockOrganisationsClient
  {
    private const string s_baseUri = "http://sample.com";

    // ReSharper disable once NotAccessedField.Local
    private readonly ILogger _log;

    public MockOrganisationsClient(ILogger log, MockOrganisationsCrawlJobData mockorganisationsCrawlJobData, IRestClient client) // TODO: pass on any extra dependencies
    {
        if (mockorganisationsCrawlJobData == null) throw new ArgumentNullException(nameof(mockorganisationsCrawlJobData));
       if (client == null) throw new ArgumentNullException(nameof(client));

       _log = log ?? throw new ArgumentNullException(nameof(log));

      // TODO use info from mockorganisationsCrawlJobData to instantiate the connection
      client.BaseUrl = new Uri(s_baseUri);
      client.AddDefaultParameter("api_key", mockorganisationsCrawlJobData.ApiKey, ParameterType.QueryString);
    }

    public IEnumerable<MockOrganisation> GetFolders()
    {
            using (var connection = new SqlConnection("Server=localhost;Database=MockOrganisations;Trusted_Connection=True;"))
            {
                connection.Open();


                using (var cmd = new SqlCommand() { CommandTimeout = 0 })
                {
                    cmd.Connection = connection;
                    cmd.CommandText = @"SELECT * FROM MockOrganisationsLarge";

                    using (var reader = cmd.ExecuteReader(CommandBehavior.Default))
                    {
                        while (reader.Read())
                        {
                            var crm = new MockOrganisation(reader);
                            yield return crm;
                        }
                    }
                }
                
                connection.Close();
            }
    }

    public IEnumerable<_SampleFile_> GetFilesForFolder(int folderId)
    {
      return new[] {
                new _SampleFile_ { Id= 11, Name = "Sample file 1", FolderId = folderId, Uri = new Uri("http://foo.com/file1")},
                new _SampleFile_ { Id= 12, Name = "Sample file 2", FolderId = folderId, Uri = new Uri("http://foo.com/file1")}
            };
    }

    public AccountInformation GetAccountInformation()
    {
      return new AccountInformation("", ""); //TODO
    }
  }
}
