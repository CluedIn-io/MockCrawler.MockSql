using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CluedIn.Crawling.MockOrganisations.Core.Models
{
    public class MockOrganisation
    {
        public MockOrganisation(SqlDataReader reader)
        {
            Id = reader["Id"].ToString();
            Name = reader["Name"].ToString();
            Address = reader["Address"].ToString();
            Contact = reader["Contact"].ToString();
            Revenue = reader["Revenue"].ToString();
            Employees = reader["Employees"].ToString();
            Website = reader["Website"].ToString();
            Email = reader["Email"].ToString();
            Information = reader["Information"].ToString();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Revenue { get; set; }
        public string Employees { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string Information { get; set; }
    }
}
