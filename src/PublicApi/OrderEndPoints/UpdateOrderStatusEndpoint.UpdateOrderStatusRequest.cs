namespace Microsoft.eShopWeb.PublicApi.OrderEndPoints;

public class UpdateOrderStatusRequest : BaseRequest
{
    public int OrderNumber { get; init; }
    public string Status { get; set; }

    public UpdateOrderStatusRequest(int orderNumber, string status)
    {
        OrderNumber = orderNumber;
        Status = status;
    }

}
