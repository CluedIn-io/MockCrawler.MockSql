using System;
using CluedIn.Core.Logging;
using CluedIn.Core.Providers;
using CluedIn.Crawling.MockSql.Core;
using CluedIn.Crawling.MockSql.Core.Models;
using System.Collections.Generic;
using RestSharp;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

namespace CluedIn.Crawling.MockSql.Infrastructure
{
    public class MockSqlClient
    {
        // ReSharper disable once NotAccessedField.Local
        private readonly ILogger _log;
        public MockSqlCrawlJobData JobData { get; set; }
        //private readonly string _stateFilePath = "MockSqlCrawlJobData.StateFile.json";

        public MockSqlClient(ILogger log, MockSqlCrawlJobData mockSqlCrawlJobData) // TODO: pass on any extra dependencies
        {
            if (mockSqlCrawlJobData == null)
                throw new ArgumentNullException(nameof(mockSqlCrawlJobData));

            _log = log ?? throw new ArgumentNullException(nameof(log));
            JobData = mockSqlCrawlJobData;

        }

        public IEnumerable<Organization> GetOrganisations()
        {
            using (var connection = new SqlConnection(JobData.ConnectionString))
            {
                connection.Open();

                using (var cmd = new SqlCommand() { CommandTimeout = 0 })
                {
                    cmd.Connection = connection;
                    cmd.CommandText = $@"SELECT * FROM Organization";

                    using (var reader = cmd.ExecuteReader(CommandBehavior.Default))
                    {
                        while (reader.Read())
                        {
                            var org = new Organization(reader);
                            yield return org;
                        }
                    }
                }

                connection.Close();
            }
        }



        public IEnumerable<Person> GetPersons()
        {
            using (var connection = new SqlConnection("Server=localhost;Database=Andrei;Trusted_Connection=True;"))
            {
                connection.Open();


                using (var cmd = new SqlCommand() { CommandTimeout = 0 })
                {
                    cmd.Connection = connection;
                        cmd.CommandText = $@"SELECT Person.*, CompanyRelationship.Name as RelationshipName
                                          FROM Person
                                          LEFT OUTER JOIN CompanyRelationship 
                                          ON Person.CompanyRelationship = CompanyRelationship.Id";

                    using (var reader = cmd.ExecuteReader(CommandBehavior.Default))
                    {
                        while (reader.Read())
                        {
                            var pers = new Person(reader);
                            yield return pers;
                        }
                    }
                }

                connection.Close();
            }
        }

        public AccountInformation GetAccountInformation()
        {
            return new AccountInformation("asd", "asd2"); //TODO
        }
    }
}
