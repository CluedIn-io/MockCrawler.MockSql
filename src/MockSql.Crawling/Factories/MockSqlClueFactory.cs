using System;
using CluedIn.Core;
using CluedIn.Core.Data;
using CluedIn.Crawling.Factories;
using CluedIn.Crawling.MockSql.Core;
using RuleConstants = CluedIn.Core.Constants.Validation.Rules;

namespace CluedIn.Crawling.MockSql.Factories
{
    public class MockOrganisationsClueFactory : ClueFactory
    {
        public MockOrganisationsClueFactory()
            : base(MockSqlConstants.CodeOrigin, MockSqlConstants.ProviderRootCodeValue)
        {
        }

        protected override Clue ConfigureProviderRoot([NotNull] Clue clue)
        {
            if (clue == null)
                throw new ArgumentNullException(nameof(clue));

            var data = clue.Data.EntityData;
            data.Name = MockSqlConstants.CrawlerName;
            //data.Uri = new Uri(MockSqlConstants.Uri);
            data.Description = MockSqlConstants.CrawlerDescription;

            // TODO this should not be necessary
            clue.ValidationRuleSuppressions.AddRange(new[]
            {
                    RuleConstants.METADATA_001_Name_MustBeSet,
                    RuleConstants.PROPERTIES_001_MustExist,
                    RuleConstants.METADATA_002_Uri_MustBeSet,
                    RuleConstants.METADATA_004_Invalid_EntityType,
                    RuleConstants.METADATA_003_Author_Name_MustBeSet,
                    RuleConstants.METADATA_005_PreviewImage_RawData_MustBeSet
            });

            return clue;
        }
    }
}
