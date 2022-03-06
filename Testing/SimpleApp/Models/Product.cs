using System.Collections.Generic;
using SimpleApp.Tests;

namespace SimpleApp.Models
{
    public class Product 
    {
        public string Name { get; set; }
        public decimal? Price { get; set; }

        //public static Product[] GetProducts()
        //{
        //    Product kakle = new Product()
        //    {
        //        Name = "kakle",
        //        Price = 78.95M
        //    };

        //    Product jacket = new Product()
        //    {
        //        Name = "jacket",
        //        Price = 1000M
        //    };

        //    return new Product[2] { kakle, jacket };
        //}
    }

    public class ProductDataSource : IDataSource
    {
        public IEnumerable<Product> Products => new Product[]
        {
            new Product()
            {
                Name = "kakle",
                Price = 78.95M
            },

            new Product()
            {
                Name = "jacket",
                Price = 1000M
            }
        };
    }
}