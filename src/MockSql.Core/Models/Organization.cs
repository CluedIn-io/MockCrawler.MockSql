using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CluedIn.Crawling.MockSql.Core.Models
{
    public class Organization
    {
        public Organization(IDataReader reader)
        {
            Id = reader.GetStringValue("id");
            Name = reader.GetStringValue("name");
            Address = reader.GetStringValue("address");
            EmployeeNo = reader.GetNullableValue<int?>("employeeno");
            Revenue = reader.GetNullableValue<int?>("revenue");
            Website = reader.GetStringValue("website");
            Industry = reader.GetStringValue("industry");
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? Revenue { get; set; }
        public int? EmployeeNo { get; set; }
        public string Website { get; set; }
        public string Industry { get; set; }
    }
}
