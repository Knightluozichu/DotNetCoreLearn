#pragma checksum "i:\NetCore\DotNetCoreLearn\SportsSln\SportsStore\Pages\Admin\Orders.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6d6e196e92d68c9278d9fcadc51266ca26ec5152"
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/admin/orders")]
    public partial class Orders : OwningComponentBase<IOrderRepository>
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 7 "i:\NetCore\DotNetCoreLearn\SportsSln\SportsStore\Pages\Admin\Orders.razor"
       
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