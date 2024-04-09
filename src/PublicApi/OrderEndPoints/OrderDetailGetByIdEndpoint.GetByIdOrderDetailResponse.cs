using System;

namespace Microsoft.eShopWeb.PublicApi.OrderEndPoints;
public class GetByIdOrderDetailResponse : BaseResponse
{
    public GetByIdOrderDetailResponse(Guid correlationId) : base(correlationId)
    {
    }

    public GetByIdOrderDetailResponse()
    {
    }
    
    public OrderDetailDto OrderDetail { get; set; }
}
