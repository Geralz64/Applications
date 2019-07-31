using Repository.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebAPI.Models
{
    public class Product
    {

        public static Task<List<ProductTestData>> GetProducts()
        {

            Task<List<ProductTestData>> task = null;

            task = Task.Run(() =>
            {

                var products = ProductTestData.GetProductTestData();

                return products;
            });

            return task;

        }

        public static Task<ProductTestData> GetProduct(string productID)
        {

            Task<ProductTestData> task = null;

            task = Task.Run(() =>
            {
                var product = ProductTestData.GetProductTestData().Where(p => p.ProductID == Convert.ToInt32(productID)).FirstOrDefault();

                return product;
            });

            return task;

        }

        public static Task<string> UpdateProduct(string productID)
        {

            Task<string> task = null;

            task = Task.Run(() =>

            {

                var product = ProductTestData.GetProductTestData().Where(p => p.ProductID == Convert.ToInt32(productID)).FirstOrDefault();

                product.Name = "Arc Reactor - Updated Product";

                return product.Name;

            });


            return task;

        }

        public static Task<ProductTestData> InsertProduct()
        {

            Task<ProductTestData> task = null;

            task = Task.Run(() => {

                var products = ProductTestData.GetProductTestData();

                var newProduct = new ProductTestData { ProductID = 500, Name = "Iron Man Armor MK3", ExpirationDate = 20880101, Inventory = 1 , Price = "100000.00", PriorityLevel = "5"};

                products.Add(newProduct);

                return newProduct;

            });

            return task;
        }


        public static Task<ProductTestData> DeleteProduct(string productID)
        {

            Task<ProductTestData> task = null;

            task = Task.Run(() => {


                var products = ProductTestData.GetProductTestData();
                var product = ProductTestData.GetProductTestData().Where(p => p.ProductID == Convert.ToInt32(productID)).FirstOrDefault();

                products.Remove(product);

                return product;


            });

            return task;

        }




    }
}