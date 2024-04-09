namespace Microsoft.eShopWeb.PublicApi.OrderEndPoints;

public class OrderItemDto
{
    public string PictureUri { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public int Units { get; set; }

}