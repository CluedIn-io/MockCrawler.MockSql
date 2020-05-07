using System;
using CluedIn.Core.Data;
using CluedIn.Crawling.MockSql.Core.Models;
using CluedIn.Crawling.Factories;
using CluedIn.Core;
using CluedIn.Crawling.MockSql.Vocabularies;
using CluedIn.Crawling.Helpers;
using RuleConstants = CluedIn.Core.Constants.Validation.Rules;


namespace CluedIn.Crawling.MockSql.ClueProducers
{
    public class OrganizationClueProducer : BaseClueProducer<Organization>
    {
        private readonly IClueFactory _factory;

        public OrganizationClueProducer([NotNull] IClueFactory factory)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));

        }

        protected override Clue MakeClueImpl([NotNull] Organization input, Guid accountId)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            // TODO: Create clue specifying the type of entity it is and ID            
            var clue = _factory.Create(EntityType.Organization, input.Id.ToString(), accountId);

            // TODO: Populate clue data
            var data = clue.Data.EntityData;
            data.Name = input.Name.PrintIfAvailable();
            data.DisplayName = input.Name.PrintIfAvailable();

            var vocab = new OrganizationVocabulary();

            data.Properties[vocab.Id] = input.Id.PrintIfAvailable();
            data.Properties[vocab.Name] = input.Name.PrintIfAvailable();
            data.Properties[vocab.Address] = input.Address.PrintIfAvailable();
            data.Properties[vocab.Revenue] = input.Revenue.PrintIfAvailable();
            data.Properties[vocab.EmployeeNo] = input.EmployeeNo.PrintIfAvailable();
            data.Properties[vocab.Website] = input.Website.PrintIfAvailable();
            data.Properties[vocab.Industry] = input.Industry.PrintIfAvailable();

            clue.ValidationRuleSuppressions.AddRange(new[]
            {
                RuleConstants.METADATA_001_Name_MustBeSet,
                RuleConstants.PROPERTIES_001_MustExist,
                RuleConstants.METADATA_002_Uri_MustBeSet,
                RuleConstants.METADATA_003_Author_Name_MustBeSet,
                RuleConstants.METADATA_005_PreviewImage_RawData_MustBeSet
            });

            //since all clues need at least one edge
            //folder is connected to the provider itself
            _factory.CreateEntityRootReference(clue, EntityEdgeType.PartOf);
            return clue;
        }
    }
}
