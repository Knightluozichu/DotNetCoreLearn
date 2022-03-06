using System.Linq;
using Moq;
using SportsStore.Controllers;
using SportsStore.Models;
using SportsStore.Models.ViewModels;
using Xunit;

namespace SportsStore.Tests
{
    public class HomeControllerTests {
        
        [Fact]
        public void Can_Use_Repository()
        {
            // Given
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
            mock.Setup(m=> m.Products).Returns((new Product[]
            {
                new Product{ProductID = 1, Name = "P1"},
                new Product{ProductID = 2, Name = "P2"}
            }).AsQueryable<Product>());

            HomeController controller = new HomeController(mock.Object);
            // When

            ProductsListViewModel result = controller.Index(null).ViewData.Model as ProductsListViewModel;

            // Then

            Product[] proArray = result.Products.ToArray();
            Assert.True(proArray.Length == 2);
            Assert.Equal("P1",proArray[0].Name);
            Assert.Equal("P2",proArray[1].Name);
        }
    }
}