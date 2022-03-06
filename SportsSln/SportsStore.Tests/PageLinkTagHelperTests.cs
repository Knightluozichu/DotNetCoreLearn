using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Moq;
using SportsStore.Infrastructure;
using Xunit;

namespace SportsStore.Tests{
    public class PageLinkTagHelperTests {
        [Fact]
        public void CanGeneratePageLink()
        {
            // Given
            var urlHelper = new Mock<IUrlHelper>();
            urlHelper.SetupSequence(x=>x.Action(It.IsAny<UrlActionContext>())).Returns("Test/Page1").Returns("Test/Page2").Returns("Test/Page3");
            var urlHelperFactory = new Mock<IUrlHelperFactory>();
            urlHelperFactory.Setup(f=>f.GetUrlHelper(It.IsAny<ActionContext>())).Returns(urlHelper.Object);
            PageLinkTagHelper helper = new PageLinkTagHelper(urlHelperFactory.Object){
                PageModel = new Models.ViewModels.PagingInfo(){
                    ItemsPerPage = 10,
                    TotalItems = 28,
                    CurrentPage = 2
                },
                PageAction = "Test"
            };
            
            System.Console.WriteLine("helper.PageModel.TotalPage:{0}",helper.PageModel.TotalPage);
            TagHelperContext ctx = new TagHelperContext(new TagHelperAttributeList(), new Dictionary<object,object>(),"");
            var content = new Mock<TagHelperContent>();
            TagHelperOutput output = new TagHelperOutput("div",new TagHelperAttributeList(),(b,htmlencoder)=>Task.FromResult(content.Object));
            // When
            helper.Process(ctx,output);
            // Then
            Assert.Equal(@"<a href=""Test/Page1"">1</a>"+ @"<a href=""Test/Page2"">2</a>"+ @"<a href=""Test/Page3"">3</a>",output.Content.GetContent());

        }

        
    }
}