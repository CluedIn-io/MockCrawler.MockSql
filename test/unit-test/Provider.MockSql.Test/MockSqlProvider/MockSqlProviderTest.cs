using Castle.Windsor;
using CluedIn.Core;
using CluedIn.Core.Providers;
using CluedIn.Crawling.MockSql.Infrastructure.Factories;
using Moq;

namespace Provider.MockSql.Test.MockSqlProvider
{
  public abstract class MockSqlProviderTest
  {
    protected readonly ProviderBase Sut;

    protected Mock<IMockSqlClientFactory> NameClientFactory;
    protected Mock<IWindsorContainer> Container;

    protected MockSqlProviderTest()
    {
      Container = new Mock<IWindsorContainer>();
      NameClientFactory = new Mock<IMockSqlClientFactory>();
      var applicationContext = new ApplicationContext(Container.Object);
      Sut = new CluedIn.Provider.MockSql.MockSqlProvider(applicationContext, NameClientFactory.Object);
    }
  }
}
