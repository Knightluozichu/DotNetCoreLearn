using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SportsStore.Controllers;
using SportsStore.Models;
using SportsStore.Models.ViewModels;
using Xunit;

namespace SportsStore.Tests
{
    public class ProductControllerTests
    {
        [Fact]
        public void CanUseRepository()
        {
            //Arrange
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();

            mock.Setup(m => m.Products).Returns((new Product[]{
                new Product{ProductID = 1, Name = "P1" },
                new Product{ProductID = 2, Name = "P2" },
                new Product{ProductID = 3, Name = "P3" },
                new Product{ProductID = 4, Name = "P4" },
                new Product{ProductID = 5, Name = "P5" },
                new Product{ProductID = 6, Name = "P6" },
            }).AsQueryable<Product>());

            HomeController home = new HomeController(mock.Object);
            
            //Act
            ProductsListViewModel result = (home.Index(null,2) as ViewResult).ViewData.Model as ProductsListViewModel;

            //Assert

            Product[] prodArray = result.Products.ToArray();
            Assert.True(prodArray.Length == 2);
            Assert.Equal("P5",prodArray[0].Name);
            Assert.Equal("P6",prodArray[1].Name);
        }

        [Fact]
        public void CanSendPaginationViewModel()
        {
            // Given
                    Mock<IStoreRepository> mock = new Mock<IStoreRepository>();

            mock.Setup(m => m.Products).Returns((new Product[]{
                new Product{ProductID = 1, Name = "P1" , Category = "cat1"},
                new Product{ProductID = 2, Name = "P2" , Category = "cat2"},
                new Product{ProductID = 3, Name = "P3" , Category = "cat1"},
                new Product{ProductID = 4, Name = "P4" , Category = "cat2"},
                new Product{ProductID = 5, Name = "P5" , Category = "cat3"}
            }).AsQueryable<Product>());

            HomeController home = new HomeController(mock.Object){PageSize = 3};

            // When
            ProductsListViewModel result = home.Index(null,2).Model as ProductsListViewModel;
            // Then
            PagingInfo pagingInfo = result.PagingInfo;
            Assert.Equal(2,pagingInfo.CurrentPage);
            Assert.Equal(2,pagingInfo.TotalPage);
            Assert.Equal(3,pagingInfo.ItemsPerPage);
            Assert.Equal(5,pagingInfo.TotalItems);

            Product[] proArray = result.Products.ToArray();
            Assert.True(proArray[0].Name == "P4" && proArray[0].Category == "cat2");
            Assert.True(proArray[1].Name == "P5" && proArray[1].Category == "cat3");
        }
    }
}
