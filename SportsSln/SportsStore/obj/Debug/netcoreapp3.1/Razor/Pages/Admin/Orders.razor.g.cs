#pragma checksum "I:\NetCore\DotNetCoreLearn\SportsSln\SportsStore\Pages\Admin\Orders.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6d6e196e92d68c9278d9fcadc51266ca26ec5152"
// <auto-generated/>
#pragma warning disable 1591
namespace SportsStore.Pages.Admin
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
#nullable restore
#line 1 "I:\NetCore\DotNetCoreLearn\SportsSln\SportsStore\Pages\Admin\_Imports.razor"
using Microsoft.AspNetCore.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "I:\NetCore\DotNetCoreLearn\SportsSln\SportsStore\Pages\Admin\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "I:\NetCore\DotNetCoreLearn\SportsSln\SportsStore\Pages\Admin\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "I:\NetCore\DotNetCoreLearn\SportsSln\SportsStore\Pages\Admin\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "I:\NetCore\DotNetCoreLearn\SportsSln\SportsStore\Pages\Admin\_Imports.razor"
using Microsoft.EntityFrameworkCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "I:\NetCore\DotNetCoreLearn\SportsSln\SportsStore\Pages\Admin\_Imports.razor"
using SportsStore.Models;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/admin/orders")]
    public partial class Orders : OwningComponentBase<IOrderRepository>
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<SportsStore.Pages.Admin.OrderTable>(0);
            __builder.AddAttribute(1, "TableTitle", "没发货");
            __builder.AddAttribute(2, "Orders", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.IEnumerable<SportsStore.Models.Order>>(
#nullable restore
#line 3 "I:\NetCore\DotNetCoreLearn\SportsSln\SportsStore\Pages\Admin\Orders.razor"
                                     UnshippedOrders

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(3, "ButtonLabel", "发货");
            __builder.AddAttribute(4, "OrderSelected", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Int32>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Int32>(this, 
#nullable restore
#line 3 "I:\NetCore\DotNetCoreLearn\SportsSln\SportsStore\Pages\Admin\Orders.razor"
                                                                                      ShipOrder

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.AddMarkupContent(5, "\r\n");
            __builder.OpenComponent<SportsStore.Pages.Admin.OrderTable>(6);
            __builder.AddAttribute(7, "TableTitle", "已发货");
            __builder.AddAttribute(8, "Orders", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.IEnumerable<SportsStore.Models.Order>>(
#nullable restore
#line 4 "I:\NetCore\DotNetCoreLearn\SportsSln\SportsStore\Pages\Admin\Orders.razor"
                                     ShippedOrders

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(9, "ButtonLabel", "撤销");
            __builder.AddAttribute(10, "OrderSelected", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Int32>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Int32>(this, 
#nullable restore
#line 4 "I:\NetCore\DotNetCoreLearn\SportsSln\SportsStore\Pages\Admin\Orders.razor"
                                                                                     ResetOrder

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.AddMarkupContent(11, "\r\n");
            __builder.OpenElement(12, "button");
            __builder.AddAttribute(13, "class", "btn btn-info");
            __builder.AddAttribute(14, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 5 "I:\NetCore\DotNetCoreLearn\SportsSln\SportsStore\Pages\Admin\Orders.razor"
                                         e => UpdateData()

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(15, "刷新数据");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 7 "I:\NetCore\DotNetCoreLearn\SportsSln\SportsStore\Pages\Admin\Orders.razor"
       
    public IOrderRepository Repository => Service;

    public IEnumerable<Order> AllOrders { get; set; }
    public IEnumerable<Order> UnshippedOrders { get; set; }
    public IEnumerable<Order> ShippedOrders { get; set; }

    protected async override Task OnInitializedAsync()
    {
        await UpdateData();
    }

    public async Task UpdateData()
    {
        AllOrders = await Repository.Orders.ToListAsync();
        UnshippedOrders = AllOrders.Where(x => !x.Shipped);
        ShippedOrders = AllOrders.Where(x => x.Shipped);
    }

    public void ShipOrder(int id) => UpdateData(id, true);
    public void ResetOrder(int id) => UpdateData(id, false);

    private void UpdateData(int id, bool shipValue)
    {
        Order o = Repository.Orders.FirstOrDefault(o => o.OrderID == id);
        o.Shipped = shipValue;
        Repository.SaveOrder(o);
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
