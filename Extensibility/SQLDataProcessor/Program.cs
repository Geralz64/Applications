using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.SQL;

namespace SQLDataProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            //LINQ practice
            /*
             Query format practice and lambda expression format
             */
            GroupingQueries();

            GroupingLambdaExpressions();

            LeftJoinQueries();

            SingleTableQueries();

            SingleTableQueriesWithSorting();

            TableJoinQueries();

            LeftJoinQueries();

            InnerJoinLambdaExpression();




        }

        private static void GroupingLambdaExpressions()
        {

            var db = new Repository.SQL.AdventureWorks2012Entities();

            var results1 = db.People
                            .Where(p => p.Password != null)
                            .GroupBy(p => p.BusinessEntityID);

            var results2 = db.People
                           .GroupBy(p => p.ModifiedDate);

            var resutls3 = db.People
                            .Where(p => p.AdditionalContactInfo != null)
                            .GroupBy(p => p.ModifiedDate)
                            .OrderBy(p => p.Key);
        }

        private static void GroupingQueries()
        {

            var db = new Repository.SQL.AdventureWorks2012Entities();


            var results = from people in db.People
                          where people.Password != null
                          group people by people.BusinessEntityID;


            foreach (var record in results)
            {

                Console.WriteLine($"{record.Key}: {record.Count()}");

            }

            var results2 = from people in db.People
                           group people by people.ModifiedDate;

            foreach (var record2 in results2)
            {

                Console.WriteLine($"{record2.Key}: {record2.Count()}");


            }

            var results3 = from people in db.People
                           where people.AdditionalContactInfo != null
                           group people by people.ModifiedDate into p
                           orderby p.Key
                           select p;

            foreach (var record3 in results3)
            {

                Console.WriteLine($"{record3.Key}: {record3.Count()}");


            }


        }

        private static void InnerJoinLambdaExpression()
        {


            var db = new Repository.SQL.AdventureWorks2012Entities();
            //BEFORE
            var addresses = (from address in db.Addresses
                             join province in db.StateProvinces
                             on address.StateProvinceID equals province.StateProvinceID
                             select address);
            //AFTER
            var addressesLambda = db.Addresses.Join(
                                             db.StateProvinces,
                                             a => a.StateProvinceID,
                                             m => m.StateProvinceID,
                                             (a, m) => new
                                             {

                                                 a.StateProvince,
                                                 m.StateProvinceID

                                             })
                                             .OrderBy(a => a.StateProvince);
            //BEFORE
            var persons = (from person in db.People
                           join emails in db.EmailAddresses
                           //on new { person.BusinessEntityID } equals new { emails.BusinessEntityID } into A
                           on person.BusinessEntityID equals emails.BusinessEntityID into A
                           from emails in A.DefaultIfEmpty()
                           where emails == null
                           select person).ToList<Person>();


            //AFTER
            var personsLambda = db.People.Join(
                                                db.EmailAddresses,
                                                p => p.BusinessEntityID,
                                                e => e.BusinessEntityID,
                                                (p, e) => new
                                                {
                                                    p.BusinessEntity,
                                                    p.Demographics,
                                                    e.EmailAddress1,
                                                    e.ModifiedDate
                                                });

            //AFTER V2
            var personsLambda2 = db.People.Join(
                                                db.EmailAddresses,
                                                p => p.BusinessEntityID,
                                                e => e.BusinessEntityID,
                                                (p, e) => new
                                                { p, e }
                                                );
        }

        private static void LeftJoinQueries()
        {


            using (var db = new Repository.SQL.AdventureWorks2012Entities())
            {


                var results = (from person in db.People
                               join emails in db.EmailAddresses
                               //on new { person.BusinessEntityID } equals new { emails.BusinessEntityID } into A
                               on person.BusinessEntityID equals emails.BusinessEntityID into A
                               from emails in A.DefaultIfEmpty()
                               where emails == null
                               select person).ToList<Person>();

            }

        }

        private static void TableJoinQueries()
        {

            var db = new Repository.SQL.AdventureWorks2012Entities();

            var addresses = (from address in db.Addresses
                             join province in db.StateProvinces
                             on address.StateProvinceID equals province.StateProvinceID
                             select address).ToList<Address>();


            var providences = (from address in db.Addresses
                               join province in db.StateProvinces
                               on address.StateProvinceID.ToString() equals province.StateProvinceID.ToString()
                               select province).Distinct().ToList<StateProvince>();


            var addresses2 = (from address in db.Addresses
                              join province in db.StateProvinces
                              on address.StateProvinceID equals province.StateProvinceID
                              where address.AddressID == 1 && address.City == "Bothell" && province.StateProvinceID == 79
                              select address).ToList<Address>();


            var providences2 = (from address in db.Addresses
                                join province in db.StateProvinces
                                on address.StateProvinceID.ToString() equals province.StateProvinceID.ToString()
                                where province.CountryRegionCode == "FR"
                                select province).ToList<StateProvince>();


        }

        private static void SingleTableQueriesWithSorting()
        {

            var db = new Repository.SQL.AdventureWorks2012Entities();


            var countryQuery = (from country in db.CountryRegions
                                where country.CountryRegionCode == "AD"
                                      && country.ModifiedDate <= DateTime.Now
                                      && country.Name.StartsWith("A")
                                orderby country.Name
                                select country).Take(10).ToList<CountryRegion>();
            ShowCountryRecords(countryQuery);

            var countryLambda = db.CountryRegions.Where(c => c.CountryRegionCode == "AD"
                                        && c.ModifiedDate <= DateTime.Now
                                        && c.Name.StartsWith("A"))
                                     .OrderBy(c => c.Name)
                                     .Take(10).ToList<CountryRegion>();

            ShowCountryRecords(countryLambda);


            DateTime date = Convert.ToDateTime("2007-12-20 00:00:00.000");

            var addressQuery = (from address in db.Addresses
                                where address.City == "Tacoma"
                                      && address.ModifiedDate >= date
                                      && address.AddressLine2 != null
                                orderby address.City descending
                                select address
                                ).Take(10).ToList<Address>();
            ShowAddress(addressQuery);


            var addressLambda = db.Addresses.Where(a => a.City == "Tacoma"
                                                    && a.ModifiedDate >= date
                                                    && a.AddressLine2 != null)
                                            .OrderByDescending(a => a.City)
                                            .Take(10)
                                            .Select(a => a).ToList<Address>();
            ShowAddress(addressLambda);
        }

        private static void SingleTableQueries()
        {
            //Simple selects with single table and casted to list
            var db = new Repository.SQL.AdventureWorks2012Entities();

            var peopleQuery = (from people in db.People
                               where people.PersonType == "EM"
                               select people).ToList<Person>();

            ShowRecords(peopleQuery);


            var peopleLambda = db.People.Where(p => p.PersonType == "EM").Select(p => p).ToList<Person>();
            ShowRecords(peopleLambda);


            var peopleQuery2 = (from people in db.People
                                where people.LastName.Contains("Ke")
                                select people).ToList<Person>();
            ShowRecords(peopleQuery2);


            var peopleLambda2 = db.People.Where(p => p.LastName.Contains("Ke")).Select(p => p).ToList<Person>();
            ShowRecords(peopleLambda2);
        }

        public static void ShowRecords(List<Person> persons)
        {

            foreach (var person in persons)
            {

                Console.WriteLine(person.FirstName);

            }
        }


        public static void ShowAddress(List<Address> addresses)
        {

            foreach (var address in addresses)
            {

                Console.WriteLine(address.City);

            }
        }


        public static void ShowCountryRecords(List<CountryRegion> country)
        {

            foreach (var count in country)
            {

                Console.WriteLine(count.Name);

            }
        }



    }
}
