using System.Collections.Generic;

namespace BlazorShared.Models.Order;

public class OrderResponse
{
    public List<Order> Orders { get; set; } = new List<Order>();
    // public int PageCount { get; set; } = 0;
}
