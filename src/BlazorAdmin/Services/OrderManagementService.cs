using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorShared.Interfaces;
using BlazorShared.Models.Order;
using Microsoft.Extensions.Logging;

namespace BlazorAdmin.Services;

public class OrderManagementService : IOrderManagementService
{
    private readonly ILogger<CatalogItemService> _logger;
    private readonly HttpService _httpService;

    public OrderManagementService(ILogger<CatalogItemService> logger,
    HttpService httpService)
    {
        _logger = logger;
        _httpService = httpService;

    }

    public async Task<List<Order>> List()
    {
        _logger.LogInformation("Fetching orders from API.");
        var orderListTask = await _httpService.HttpGet<OrderResponse>($"orders");
        return orderListTask.Orders;
    }
    
    public async Task<OrderDetail> GetById(int id)
    {
        var orderDetailTask = await _httpService.HttpGet<OrderDetailResponse>($"orders/{id}");
        return orderDetailTask.OrderDetail;
    }

    public async Task<string> Confirm(int id)
    {
        var request = new UpdateOrderStatusRequest
        {
            OrderNumber = id,
            Status = "Approved"
        };

        return (await _httpService.HttpPut<UpdateOrderStatusResponse>($"orders/{id}", request)).Status;
    }
}