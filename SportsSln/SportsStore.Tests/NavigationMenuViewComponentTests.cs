using Moq;
using SportsStore.Models;
using Xunit;
using System.Linq;
using SportsStore.Components;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Collections.Generic;
using SportsStore.Controllers;
using System;
using SportsStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace SportsStore.Tests
{
    public class NavigationMenuViewComponentTests
    {
        [Fact]
        public void TestType()
        {
            // Given
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
            mock.Setup(p => p.Products).Returns((new Product[]
            {
                new Product{ ProductID = 1,Name = "p1",Category = "Apples"},
                new Product{ ProductID = 2,Name = "p2",Category = "Apples"},
                new Product{ ProductID = 3,Name = "p3",Category = "Plume"},
                new Product{ ProductID = 4,Name = "p4",Category = "Oranges"},
                new Product{ ProductID = 5,Name = "p5",Category = "Plume"}
            }).AsQueryable<Product>());

            NavigationMenuViewComponent navigationMenuViewComponent = new NavigationMenuViewComponent(mock.Object);

            // When
            string[] results = ((IEnumerable<string>)(navigationMenuViewComponent.Invoke() as ViewViewComponentResult).ViewData.Model).ToArray();

            // Then
            Assert.True(Enumerable.SequenceEqual(new string[] { "Apples", "Oranges", "Plume" }, results));
        }

        [Fact]
        public void Indicates_Selected_Category()
        {
            // Given

            string categoryToSelect = "Apples";

            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]{
            new Product{ProductID = 1,Name="p1",Category = "Apples"},
            new Product{ProductID = 2,Name="p2",Category = "Oranges"}
            }).AsQueryable<Product>);

            NavigationMenuViewComponent target = new NavigationMenuViewComponent(mock.Object);
            target.ViewComponentContext = new ViewComponentContext{
                ViewContext = new Microsoft.AspNetCore.Mvc.Rendering.ViewContext{
                    RouteData = new Microsoft.AspNetCore.Routing.RouteData()
                }
            };
            target.RouteData.Values["category"] = categoryToSelect;
            // When

            string result = (string)(target.Invoke() as ViewViewComponentResult).ViewData["SelectedCategory"];

            // Then
            Assert.Equal(categoryToSelect,result);
        }

        [Fact]
        public void Generate_Category_Specific_Product_Count()
        {
            // Given
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
            mock.Setup(m=>m.Products).Returns((new Product[]{
                new Product{ProductID = 1,Name = "p1",Category="cat1"},
                new Product{ProductID = 2,Name = "p2",Category="cat2"},
                new Product{ProductID = 3,Name = "p3",Category="cat1"},
                new Product{ProductID = 4,Name = "p4",Category="cat2"},
                new Product{ProductID = 5,Name = "p5",Category="cat3"}
            }).AsQueryable<Product>());

            HomeController target = new HomeController(mock.Object);
            target.PageSize = 3;
            Func<ViewResult,ProductsListViewModel> GetModel = result =>
                result?.ViewData?.Model as ProductsListViewModel;
            
            // When
            int? res1 = GetModel(target.Index("cat1"))?.PagingInfo.TotalItems;
            int? res2 = GetModel(target.Index("cat2"))?.PagingInfo.TotalItems;
            int? res3 = GetModel(target.Index("cat3"))?.PagingInfo.TotalItems;
            int? resAll = GetModel(target.Index(null))?.PagingInfo.TotalItems;
            
            // Then
            Assert.Equal(2,res1);
            Assert.Equal(2,res2);
            Assert.Equal(1,res3);
            Assert.Equal(5,resAll);
        }
    }
}