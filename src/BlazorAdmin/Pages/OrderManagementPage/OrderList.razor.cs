using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorAdmin.Helpers;
using BlazorShared.Interfaces;
using BlazorShared.Models.Order;

namespace BlazorAdmin.Pages.OrderManagementPage;

public partial class OrderList : BlazorComponent
{
    [Microsoft.AspNetCore.Components.Inject]
    public IOrderManagementService OrderManagementService { get; set; }
    private List<Order> orders = new List<Order>();
    private OrderDetails OrderDetailsComponent { get; set; }


    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            orders = await OrderManagementService.List();
            CallRequestRefresh();
        }

        await base.OnAfterRenderAsync(firstRender);
    }

    private async void OrderDetailsClick(int orderNumber)
    {
        await OrderDetailsComponent.Open(orderNumber);
    }

    private async Task ConfirmOrderClick(int id)
    {
        await OrderManagementService.Confirm(id);
        await ReloadOrders();
    }

    private async Task ReloadOrders()
    {
        orders = await OrderManagementService.List();
        StateHasChanged();
    }
}
