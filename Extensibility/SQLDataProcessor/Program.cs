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


            SingleTableQueries();

            SingleTableQueriesWithSorting();

            TableJoinQueries();


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
