using System;

namespace Microsoft.eShopWeb.PublicApi.OrderEndPoints;

public class UpdateOrderStatusResponse : BaseResponse
{
    public UpdateOrderStatusResponse(Guid correlationId) : base(correlationId)
    {
    }

    public UpdateOrderStatusResponse()
    {
    }

    public string Status { get; set; } = "Approved";
}
