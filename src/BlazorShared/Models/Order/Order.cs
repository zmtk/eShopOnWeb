using System;

namespace BlazorShared.Models.Order;

public class Order
{
    public int OrderNumber { get; set; }
    public string BuyerId { get; set; }
    public DateTimeOffset OrderDate { get; set; }
    public decimal Total { get; set; }
    public string Status { get; set; }
}
