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
    public class PersonClueProducer : BaseClueProducer<Person>
    {
        private readonly IClueFactory _factory;

        public PersonClueProducer([NotNull] IClueFactory factory)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));

        }

        protected override Clue MakeClueImpl([NotNull] Person input, Guid accountId)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            // TODO: Create clue specifying the type of entity it is and ID            
            var clue = _factory.Create(EntityType.Person, input.Id.ToString(), accountId);

            // TODO: Populate clue data
            var data = clue.Data.EntityData;
            data.Name = input.FirstName;

            var vocab = new PersonVocabulary();

            data.Properties[vocab.Id] = input.Id.PrintIfAvailable();
            data.Properties[vocab.FirstName] = input.FirstName.PrintIfAvailable();
            data.Properties[vocab.LastName] = input.LastName.PrintIfAvailable();
            data.Properties[vocab.Email] = input.Email.PrintIfAvailable();
            data.Properties[vocab.Gender] = input.Gender.PrintIfAvailable();
            data.Properties[vocab.CompanyId] = input.CompanyId.PrintIfAvailable();
            data.Properties[vocab.CompanyRelationship] = input.CompanyRelationship.PrintIfAvailable();
            data.Properties[vocab.JobTitle] = input.JobTitle.PrintIfAvailable();
            data.Properties[vocab.Department] = input.Department.PrintIfAvailable();

            //_factory.CreateOutgoingEntityReference(clue, EntityType.Organization, EntityEdgeType.For, input.CompanyId, input.CompanyId);

            clue.ValidationRuleSuppressions.AddRange(new[]
            {
                //RuleConstants.METADATA_001_Name_MustBeSet,
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
