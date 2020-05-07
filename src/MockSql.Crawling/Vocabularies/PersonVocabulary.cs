using CluedIn.Core.Data;
using CluedIn.Core.Data.Vocabularies;

namespace CluedIn.Crawling.MockSql.Vocabularies
{
    class PersonVocabulary : SimpleVocabulary
    {
        public PersonVocabulary()
        {
            VocabularyName = "MockSql PersonVocabulary";
            KeyPrefix = "MockSql.personVocabulary"; 
            KeySeparator = ".";
            Grouping = EntityType.Person;

            AddGroup("MockSql Details", group =>
            {
                Id = group.Add(new VocabularyKey("id", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
                FirstName = group.Add(new VocabularyKey("firstName", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
                LastName = group.Add(new VocabularyKey("lastName", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
                Email = group.Add(new VocabularyKey("email", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
                Gender = group.Add(new VocabularyKey("gender", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
                CompanyId = group.Add(new VocabularyKey("companyId", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
                CompanyRelationship = group.Add(new VocabularyKey("companyRelationship", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
                JobTitle = group.Add(new VocabularyKey("jobTitle", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
                Department = group.Add(new VocabularyKey("department", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
            });

            //AddMapping(FirstName, CluedIn.Core.Data.Vocabularies.Vocabularies.CluedInPerson.FirstName);
            //AddMapping(LastName, CluedIn.Core.Data.Vocabularies.Vocabularies.CluedInPerson.LastName);
            //AddMapping(Email, CluedIn.Core.Data.Vocabularies.Vocabularies.CluedInPerson.Email);
            //AddMapping(Gender, CluedIn.Core.Data.Vocabularies.Vocabularies.CluedInPerson.Gender);
            //AddMapping(JobTitle, CluedIn.Core.Data.Vocabularies.Vocabularies.CluedInPerson.JobTitle);
        }

        public VocabularyKey Id { get; private set; }
        public VocabularyKey FirstName { get; private set; }
        public VocabularyKey LastName { get; private set; }
        public VocabularyKey Email { get; private set; }
        public VocabularyKey Gender { get; private set; }
        public VocabularyKey CompanyId { get; private set; }
        public VocabularyKey CompanyRelationship { get; private set; }
        public VocabularyKey JobTitle { get; private set; }
        public VocabularyKey Department { get; private set; }
    }
}
