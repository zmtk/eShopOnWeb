using System;
using System.Collections.Generic;

namespace Microsoft.eShopWeb.PublicApi.OrderEndPoints;

public class ListOrderResponse : BaseResponse
{
    public ListOrderResponse(Guid correlationId): base(correlationId)
    {
    }

    public ListOrderResponse()
    {
    }

    public List<OrderDto> Orders { get; set; } = new List<OrderDto>();

}