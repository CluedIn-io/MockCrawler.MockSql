using CluedIn.Core;
using CluedIn.Crawling.MockOrganisations.Core;

using ComponentHost;

namespace CluedIn.Crawling.MockOrganisations
{
    [Component(MockOrganisationsConstants.CrawlerComponentName, "Crawlers", ComponentType.Service, Components.Server, Components.ContentExtractors, Isolation = ComponentIsolation.NotIsolated)]
    public class MockOrganisationsCrawlerComponent : CrawlerComponentBase
    {
        public MockOrganisationsCrawlerComponent([NotNull] ComponentInfo componentInfo)
            : base(componentInfo)
        {
        }
    }
}

