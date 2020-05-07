using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using CluedIn.Core.Agent.Jobs;
using CluedIn.Core.Crawling;
using CluedIn.Crawling.MockSql.Core;
using CluedIn.Crawling.MockSql.Core.Models;
using CluedIn.Crawling.MockSql.Infrastructure.Factories;
using Newtonsoft.Json;

namespace CluedIn.Crawling.MockSql
{
    public class MockSqlCrawler : ICrawlerDataGenerator
    {
        private readonly IMockSqlClientFactory _clientFactory;

        public MockSqlCrawler(IMockSqlClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public IEnumerable<object> GetData(CrawlJobData jobData)
        {
            if (!(jobData is MockSqlCrawlJobData mockSqlcrawlJobData))
            {
                yield break;
            }

            var client = _clientFactory.CreateNew(mockSqlcrawlJobData);

            //crawl data from provider and yield objects

            foreach ( var org in client.GetOrganisations())
            {
                yield return org;
            }

            foreach (var pers in client.GetPersons())
            {
                yield return pers;
            }

        }
    }
}
