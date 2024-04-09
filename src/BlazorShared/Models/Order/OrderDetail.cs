using System.Collections.Generic;

namespace BlazorShared.Models.Order;

public class OrderDetail : Order
{
    public List<OrderItem> OrderItems { get; set; } = new(); 
    public Address? ShippingAddress { get; set; }
    
}
