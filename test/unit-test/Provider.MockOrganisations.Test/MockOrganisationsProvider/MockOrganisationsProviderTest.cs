using Castle.Windsor;
using CluedIn.Core;
using CluedIn.Core.Providers;
using CluedIn.Crawling.MockOrganisations.Infrastructure.Factories;
using Moq;

namespace Provider.MockOrganisations.Test.MockOrganisationsProvider
{
  public abstract class MockOrganisationsProviderTest
  {
    protected readonly ProviderBase Sut;

    protected Mock<IMockOrganisationsClientFactory> NameClientFactory;
    protected Mock<IWindsorContainer> Container;

    protected MockOrganisationsProviderTest()
    {
      Container = new Mock<IWindsorContainer>();
      NameClientFactory = new Mock<IMockOrganisationsClientFactory>();
      var applicationContext = new ApplicationContext(Container.Object);
      Sut = new CluedIn.Provider.MockOrganisations.MockOrganisationsProvider(applicationContext, NameClientFactory.Object);
    }
  }
}
