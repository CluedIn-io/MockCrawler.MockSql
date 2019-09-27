using System;
using CluedIn.Core.Data;
using CluedIn.Crawling.MockOrganisations.Core.Models;
using CluedIn.Crawling.Factories;
using CluedIn.Core;
using CluedIn.Crawling.MockOrganisations.Vocabularies;
using CluedIn.Crawling.Helpers;
using RuleConstants = CluedIn.Core.Constants.Validation.Rules;


namespace CluedIn.Crawling.MockOrganisations.ClueProducers
{
    public class MockOrganisationClueProducer : BaseClueProducer<MockOrganisation>
    {
        private readonly IClueFactory _factory;

        public MockOrganisationClueProducer([NotNull] IClueFactory factory)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));

        }

        protected override Clue MakeClueImpl([NotNull] MockOrganisation input, Guid accountId)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            // TODO: Create clue specifying the type of entity it is and ID            
            var clue = _factory.Create(EntityType.Organization, input.Id.ToString(), accountId);

            // TODO: Populate clue data
            var data = clue.Data.EntityData;
            data.Name = input.Name.PrintIfAvailable();
            data.DisplayName = input.Name.PrintIfAvailable();

            var vocab = new MockOrganisationVocabulary();

            data.Properties[vocab.Id] = input.Id.PrintIfAvailable();
            data.Properties[vocab.Name] = input.Name.PrintIfAvailable();
            data.Properties[vocab.Address] = input.Address.PrintIfAvailable();
            data.Properties[vocab.Contact] = input.Contact.PrintIfAvailable();
            data.Properties[vocab.Revenue] = input.Revenue.PrintIfAvailable();
            data.Properties[vocab.Employees] = input.Employees.PrintIfAvailable();
            data.Properties[vocab.Website] = input.Website.PrintIfAvailable();
            data.Properties[vocab.Email] = input.Email.PrintIfAvailable();
            data.Properties[vocab.Information] = input.Information.PrintIfAvailable();

            clue.ValidationRuleSuppressions.AddRange(new[]
          {
                RuleConstants.METADATA_001_Name_MustBeSet,
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
