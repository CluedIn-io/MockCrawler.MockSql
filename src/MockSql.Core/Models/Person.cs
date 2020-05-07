using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CluedIn.Crawling.MockSql.Core.Models
{
    public class Person
    {
        public Person(IDataReader reader)
        {
            Id = reader.GetStringValue("id");
            FirstName = reader.GetStringValue("FirstName");
            LastName = reader.GetStringValue("LastName");
            Email = reader.GetStringValue("Email");
            Gender = reader.GetStringValue("Gender");
            CompanyId = reader.GetStringValue("CompanyId");
            CompanyRelationship = reader.GetStringValue("RelationshipName");
            JobTitle = reader.GetStringValue("JobTitle");
            Department = reader.GetStringValue("Department");
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string CompanyId { get; set; }
        public string CompanyRelationship { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
    }
}
