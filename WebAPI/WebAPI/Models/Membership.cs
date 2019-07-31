using Repository.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebAPI.Models
{
    public class Membership
    {

        public static Task<List<MembershipTestData>> GetMembership()
        {

            Task<List<MembershipTestData>> task = null;

            var membership = MembershipTestData.TestData();

            task = Task.Run(() =>
            {
                var results = membership;
                return results;

            });

            return task;

        }

        public static Task<List<MembershipTestData>> GetMember(string memberID)
        {

            Task<List<MembershipTestData>> task = null;

            task = Task.Run(() =>
            {
                var results = MembershipTestData.TestData().Where(t => t.MemberID == memberID).ToList<MembershipTestData>();
                return results;

            });

            return task;

        }



        public static Task<bool> UpdateMember(string memberID)
        {

            Task<bool> task = null;

            task = Task.Run(() =>
            {
                var result = MembershipTestData.TestData().Where(t => t.MemberID == memberID).ToList().FirstOrDefault();


                result.FirstName = "JOKE_NAME";

                return true;
                //Save changes to db 

            });

            return task;
        }

        public static Task<bool> InsertMember(string memberID)
        {

            Task<bool> task = null;

            var newMember = new MembershipTestData()
            {
                MemberID = memberID,
                FirstName = "Jack",
                LastName = "Comano",
                SSN = 14985,
                BirthDate = 18180317,
                StartDate = 20200907,
                EndDate = 20240211

            };

            var membership = MembershipTestData.TestData();


            task = Task.Run(() =>
            {

                membership.Add(newMember);

                return true;
            });

            return task;
        }

        public static Task<bool> DeleteMember(string memberID)
        {

            Task<bool> task = null;

            task = Task.Run(() =>
            {

                var membership = MembershipTestData.TestData();

                var member = membership.Where(m => m.MemberID == memberID).FirstOrDefault();

                membership.Remove(member);

                return true;
            });

            return task;


        }

    }
}