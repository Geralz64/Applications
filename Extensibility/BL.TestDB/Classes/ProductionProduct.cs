using Repository.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.TestDB
{
    public class ProductionProduct
    {

        public static List<Product> GetProducts()
        {

            var db = new Repository.SQL.AdventureWorks2012Entities();

            var products = (from prod in db.Products
                            select prod).ToList<Product>();

            return products;

        }

        public static Product GetProduct(int productID)
        {

            var db = new AdventureWorks2012Entities();

            var product = (from prod in db.Products
                           where prod.ProductID == productID
                           select prod).FirstOrDefault();

            return product;

        }


        public static void UpdateProduct(int productID, string newName)
        {
            var db = new AdventureWorks2012Entities();

            var product = db.Products.Where(d => d.ProductID == productID).FirstOrDefault();

            product.Name = newName;

            db.SaveChanges();
        }

        public static void DeleteProduct(int productID)
        {
            var db = new AdventureWorks2012Entities();

            var product = db.Products.Where(d => d.ProductID == productID).FirstOrDefault();

            db.Products.Remove(product);

        }


        public static void InsertProduct(Product product)
        {
            var db = new AdventureWorks2012Entities();

            db.Products.Add(product);
            db.SaveChanges();
        }




    }
}
