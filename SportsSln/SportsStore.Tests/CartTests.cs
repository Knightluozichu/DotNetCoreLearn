using System.Linq;
using SportsStore.Models;
using Xunit;

namespace SportsStore.Tests
{
    public class CartTests
    {
        [Fact]
        public void Can_Add_New_Lines()
        {
            // Given
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };
            Cart target = new Cart();
            // When
            target.AddItem(p1,1);
            target.AddItem(p2,1);
            CartLine[] results = target.Lines.ToArray();
            // Then
            Assert.Equal(2,results.Length);
            Assert.Equal(p1.ProductID,results[0].Product.ProductID);
            Assert.Equal(p2.ProductID,results[1].Product.ProductID);
        }

        [Fact]
        public void Can_Add_Quantity_For_Existing_Lines()
        {
              // Given
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };
            Cart target = new Cart();
            // When
            target.AddItem(p1,1);
            target.AddItem(p2,1);
            target.AddItem(p1,10);
            CartLine[] results = target.Lines.ToArray();
            // Then
            Assert.Equal(11,results[0].Quantity);
        }

        [Fact]
        public void Can_Remove_Line()
        {
            // Given
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };
            Cart target = new Cart();
            // When
            target.AddItem(p1,1);
            target.AddItem(p2,1);
            target.RemoveLine(p1);            
            CartLine[] results = target.Lines.ToArray();
            // Then
            Assert.Empty(results.Where(x=>x.Product == p1));
            Assert.Equal(1,results.Length);
        }

        [Fact]
        public void Calculate_Cart_Total()
        {
           // Given
            Product p1 = new Product { ProductID = 1, Name = "P1" ,Price = 110M};
            Product p2 = new Product { ProductID = 2, Name = "P2" ,Price = 120M};
            Cart target = new Cart();
            // When
            target.AddItem(p1,1);
            target.AddItem(p2,1);
            target.AddItem(p1,5);
            target.AddItem(p2,-1);
            CartLine[] results = target.Lines.ToArray();
            // Then
            Assert.Equal(660M,target.ComputeTotalValue());
        }

        [Fact]
        public void Can_Clear_Contents()
        {
              Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };
            Cart target = new Cart();
            // When
            target.AddItem(p1,1);
            target.AddItem(p2,1);
            target.RemoveLine(p1);            
            CartLine[] results = target.Lines.ToArray();
            target.Clear();
            // Then
            Assert.Empty(target.Lines);
        }
    }

}