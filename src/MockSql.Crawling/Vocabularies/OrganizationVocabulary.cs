using CluedIn.Core.Data;
using CluedIn.Core.Data.Vocabularies;

namespace CluedIn.Crawling.MockSql.Vocabularies
{
    class OrganizationVocabulary : SimpleVocabulary
    {
        public OrganizationVocabulary()
        {
            VocabularyName = "MockSql OrganizationVocabulary";
            KeyPrefix = "MockSql.organisationVocabulary"; 
            KeySeparator = ".";
            Grouping = EntityType.Organization;

            AddGroup("MockSql Details", group =>
            {
                Id = group.Add(new VocabularyKey("id", VocabularyKeyDataType.Text, VocabularyKeyVisibility.HiddenInFrontendUI)).WithDescription("");
                Name = group.Add(new VocabularyKey("name", VocabularyKeyDataType.OrganizationName, VocabularyKeyVisibility.Visible));
                Address = group.Add(new VocabularyKey("address", VocabularyKeyDataType.GeographyLocation, VocabularyKeyVisibility.Visible));
                Revenue = group.Add(new VocabularyKey("revenue", VocabularyKeyDataType.Money, VocabularyKeyVisibility.Visible));
                EmployeeNo = group.Add(new VocabularyKey("employeeNo", VocabularyKeyDataType.Integer, VocabularyKeyVisibility.Visible)).WithDisplayName("Number of employees");
                Website = group.Add(new VocabularyKey("website", VocabularyKeyDataType.Uri, VocabularyKeyVisibility.Visible));
                Industry = group.Add(new VocabularyKey("industry", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
            });

            AddMapping(Name, CluedIn.Core.Data.Vocabularies.Vocabularies.CluedInOrganization.OrganizationName);
            AddMapping(Address, CluedIn.Core.Data.Vocabularies.Vocabularies.CluedInOrganization.Address);
            AddMapping(Revenue, CluedIn.Core.Data.Vocabularies.Vocabularies.CluedInOrganization.AnnualRevenue);
            AddMapping(EmployeeNo, CluedIn.Core.Data.Vocabularies.Vocabularies.CluedInOrganization.EmployeeCount);
            AddMapping(Website, CluedIn.Core.Data.Vocabularies.Vocabularies.CluedInOrganization.Website);
            AddMapping(Industry, CluedIn.Core.Data.Vocabularies.Vocabularies.CluedInOrganization.Industry);

        }
        public VocabularyKey Id { get; private set; }
        public VocabularyKey Name { get; private set; }
        public VocabularyKey Address { get; private set; }
        public VocabularyKey Revenue { get; private set; }
        public VocabularyKey EmployeeNo { get; private set; }
        public VocabularyKey Website { get; private set; }
        public VocabularyKey Industry { get; private set; }
    }
}
