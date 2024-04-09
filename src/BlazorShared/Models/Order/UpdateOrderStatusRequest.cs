namespace BlazorShared.Models.Order;
public class UpdateOrderStatusRequest
{
    public int OrderNumber { get; set; }
    public string Status { get; set; }
}
