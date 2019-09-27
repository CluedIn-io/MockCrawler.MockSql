using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CluedIn.Core.Data.Vocabularies;

namespace CluedIn.Crawling.MockOrganisations.Vocabularies
{
    class MockOrganisationVocabulary : SimpleVocabulary
    {
        public MockOrganisationVocabulary()
        {
            VocabularyName = "MockOrganisations [MockOrganisationVocabulary]"; // TODO: Set value
            KeyPrefix = "mockorganisations.[MockOrganisationVocabulary]"; // TODO: Set value
            KeySeparator = ".";
            Grouping = "Organisation"; // TODO: Set value

            AddGroup("MockOrganisations Details", group =>
            {
                Id = group.Add(new VocabularyKey("id", VocabularyKeyDataType.Text, VocabularyKeyVisiblity.Visible));
                Name = group.Add(new VocabularyKey("name", VocabularyKeyDataType.Text, VocabularyKeyVisiblity.Visible));
                Address = group.Add(new VocabularyKey("address", VocabularyKeyDataType.Text, VocabularyKeyVisiblity.Visible));
                Contact = group.Add(new VocabularyKey("contact", VocabularyKeyDataType.Text, VocabularyKeyVisiblity.Visible));
                Revenue = group.Add(new VocabularyKey("revenue", VocabularyKeyDataType.Text, VocabularyKeyVisiblity.Visible));
                Employees = group.Add(new VocabularyKey("employees", VocabularyKeyDataType.Text, VocabularyKeyVisiblity.Visible));
                Website = group.Add(new VocabularyKey("website", VocabularyKeyDataType.Text, VocabularyKeyVisiblity.Visible));
                Email = group.Add(new VocabularyKey("email", VocabularyKeyDataType.Text, VocabularyKeyVisiblity.Visible));
                Information = group.Add(new VocabularyKey("information", VocabularyKeyDataType.Text, VocabularyKeyVisiblity.Visible));
            });
        }
        public VocabularyKey Id { get; private set; }
        public VocabularyKey Name { get; private set; }
        public VocabularyKey Address { get; private set; }
        public VocabularyKey Contact { get; private set; }
        public VocabularyKey Revenue { get; private set; }
        public VocabularyKey Employees { get; private set; }
        public VocabularyKey Website { get; private set; }
        public VocabularyKey Email { get; private set; }
        public VocabularyKey Information { get; private set; }
    }
}
