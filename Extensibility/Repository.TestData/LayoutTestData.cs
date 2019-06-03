using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Repository.TestData
{

    public class LayoutTestData
    {
        public static List<Layout> TestData()
        {

            var layout = new List<Layout>() {

                new Layout { RecordName = "MemberID", LengthOfRecord = 10, TypeofRecord = "N" },
                new Layout { RecordName = "FirstName", LengthOfRecord = 20, TypeofRecord = "AN" },
                new Layout { RecordName = "LastName", LengthOfRecord = 20, TypeofRecord = "AN" },
                new Layout { RecordName = "SSN", LengthOfRecord = 5, TypeofRecord = "N" },
                new Layout { RecordName = "BirthDate", LengthOfRecord = 8, TypeofRecord = "N" },
                new Layout { RecordName = "StartDate", LengthOfRecord = 8, TypeofRecord = "N" },
                new Layout { RecordName = "EndDate", LengthOfRecord = 8, TypeofRecord = "N" }
            };
            
            return layout;
        }
    }
}
