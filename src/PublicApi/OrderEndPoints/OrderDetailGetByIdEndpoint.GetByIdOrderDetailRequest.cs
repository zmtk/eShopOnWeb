namespace Microsoft.eShopWeb.PublicApi.OrderEndPoints;

public class GetByIdOrderDetailRequest : BaseRequest
{
    public int OrderNumber { get; init; }

    public GetByIdOrderDetailRequest(int orderNumber)
    {
        OrderNumber = orderNumber;
    }
}
