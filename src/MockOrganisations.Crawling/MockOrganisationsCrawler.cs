using System.Collections.Generic;

using CluedIn.Core.Crawling;
using CluedIn.Crawling.MockOrganisations.Core;
using CluedIn.Crawling.MockOrganisations.Infrastructure.Factories;

namespace CluedIn.Crawling.MockOrganisations
{
    public class MockOrganisationsCrawler : ICrawlerDataGenerator
    {
        private readonly IMockOrganisationsClientFactory _clientFactory;
        public MockOrganisationsCrawler(IMockOrganisationsClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public IEnumerable<object> GetData(CrawlJobData jobData)
        {
            if (!(jobData is MockOrganisationsCrawlJobData mockorganisationscrawlJobData))
            {
                yield break;
            }

            var client = _clientFactory.CreateNew(mockorganisationscrawlJobData);

            //crawl data from provider and yield objects

            foreach( var folder in client.GetFolders())
            {
                yield return folder;
            }
        }       
    }
}
