using SimpleApp.Models;
using Xunit;

namespace SimpleApp.Tests
{
    public class ProductTest
    {

        [Fact]
        public void CanChangeProductName()
        {
            // Given
            var p = new Product()
            {
                Name = "as",
                Price = 1000M
            };

            // When
            p.Name = "hellsing";

            // Then
            Assert.Equal<string>("hellsing", p.Name);
        }

        [Fact]
        public void CanChangeProductPrice()
        {
            // Given
            var p = new Product{
                Name = "google",
                Price = 200M
            };
            
            // When
            p.Price = 100M;

            // Then

            Assert.Equal<decimal?>(100, p.Price);
        }
    }
}