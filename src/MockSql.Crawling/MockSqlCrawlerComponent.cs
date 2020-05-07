using CluedIn.Core;
using CluedIn.Crawling.MockSql.Core;

using ComponentHost;

namespace CluedIn.Crawling.MockSql
{
    [Component(MockSqlConstants.CrawlerComponentName, "Crawlers", ComponentType.Service, Components.Server, Components.ContentExtractors, Isolation = ComponentIsolation.NotIsolated)]
    public class MockSqlCrawlerComponent : CrawlerComponentBase
    {
        public MockSqlCrawlerComponent([NotNull] ComponentInfo componentInfo)
            : base(componentInfo)
        {
        }
    }
}

