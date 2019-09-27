using System;
using CluedIn.Core;
using CluedIn.Core.Data;
using CluedIn.Crawling.Factories;
using CluedIn.Crawling.MockOrganisations.Core;
using RuleConstants = CluedIn.Core.Constants.Validation.Rules;

namespace CluedIn.Crawling.MockOrganisations.Factories
{
  public class MockOrganisationsClueFactory : ClueFactory
  {
    public MockOrganisationsClueFactory()
        : base(MockOrganisationsConstants.CodeOrigin, MockOrganisationsConstants.ProviderRootCodeValue)
    {
    }

    protected override Clue ConfigureProviderRoot([NotNull] Clue clue)
    {
      if (clue == null) throw new ArgumentNullException(nameof(clue));

      var data = clue.Data.EntityData;
      data.Name = MockOrganisationsConstants.CrawlerName;
      data.Uri = new Uri(MockOrganisationsConstants.Uri);
      data.Description = MockOrganisationsConstants.CrawlerDescription;

      // TODO this should not be necessary
      clue.ValidationRuleSuppressions.AddRange(new[]
          {
            RuleConstants.METADATA_002_Uri_MustBeSet
          });

      return clue;
    }
  }
}
