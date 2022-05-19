#pragma checksum "i:\NetCore\DotNetCoreLearn\SportsSln\SportsStore\Pages\Admin\Editor.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ac61e403d1f2ed0e24128e63846f10b5a23f8e09"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace SportsStore.Pages.Admin
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
#nullable restore
#line 1 "i:\NetCore\DotNetCoreLearn\SportsSln\SportsStore\Pages\Admin\_Imports.razor"
using Microsoft.AspNetCore.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "i:\NetCore\DotNetCoreLearn\SportsSln\SportsStore\Pages\Admin\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "i:\NetCore\DotNetCoreLearn\SportsSln\SportsStore\Pages\Admin\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "i:\NetCore\DotNetCoreLearn\SportsSln\SportsStore\Pages\Admin\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "i:\NetCore\DotNetCoreLearn\SportsSln\SportsStore\Pages\Admin\_Imports.razor"
using Microsoft.EntityFrameworkCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "i:\NetCore\DotNetCoreLearn\SportsSln\SportsStore\Pages\Admin\_Imports.razor"
using SportsStore.Models;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/admin/products/edit/{id:long}")]
    [Microsoft.AspNetCore.Components.RouteAttribute("/admin/products/create")]
    public partial class Editor : OwningComponentBase<IStoreRepository>
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 43 "i:\NetCore\DotNetCoreLearn\SportsSln\SportsStore\Pages\Admin\Editor.razor"
          
        public IStoreRepository Repository => Service;

        [Inject]
        public NavigationManager NavManager{get;set;}
        [Parameter]
        public long Id { get; set; }

        public Product Product { get; set; }=new();

        protected override void OnParametersSet()
        {
            if(Id != 0)
            {
                Product = Repository.Products.FirstOrDefault(p=>p.ProductID == Id);
            }
        }

        public void SaveProduct()
        {
            if(Id == 0){
                Repository.CreateProduct(Product);
            }
            else{
                Repository.SaveProduct(Product);
            }
            NavManager.NavigateTo("/admin/products");
        }

        public string ThemeColor => Id == 0 ?"primary":"warning";
        public string TitleText=> Id == 0 ?"Create":"Edit";
    

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591