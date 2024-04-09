using System.Collections.Generic;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;

namespace Microsoft.eShopWeb.PublicApi.OrderEndPoints;

public class OrderDetailDto : OrderDto
{
    public List<OrderItemDto> OrderItems { get; set; } = new();
    public Address? ShippingAddress { get; set; }

}
