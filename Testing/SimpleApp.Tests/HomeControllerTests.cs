using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SimpleApp.Controllers;
using SimpleApp.Models;
using Xunit;
using Moq;

namespace SimpleApp.Tests
{
    public class HomeControllerTests
    {
        // class FakeDataSource : IDataSource
        // {
        //     public FakeDataSource(Product[] data) => Products = data;
        //     public IEnumerable<Product> Products { get; }
        // }


        [Fact]
        public void IndexActionModelIsComplete()
        {
            // Given
            Product[] products = new Product[]
            {
                 new Product() {Name="p1", Price = 100M},
                 new Product() {Name="p2", Price = 200M},
                    new Product() {Name="p3", Price = 300M}
            };
            
            var mock = new Mock<IDataSource>();
            mock.SetupGet(m=>m.Products).Returns(products);
            // FakeDataSource fakeDataSource = new FakeDataSource(products);

            SimpleApp.Controllers.HomeController controller = new SimpleApp.Controllers.HomeController();
            controller.DataSource = mock.Object;
            //Product[] products = new Product[]
            //{
            //     new Product() {Name="kakle", Price = 78.95M},
            //        new Product() {Name="jacket", Price = 1000M}
            //};
            // When
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;
            // Then
            Assert.Equal(products, model, Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));

            mock.VerifyGet(m=>m.Products,Times.Once);
        }
    }
}