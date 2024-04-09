using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.ApplicationCore.Specifications;
using MinimalApi.Endpoint;

namespace Microsoft.eShopWeb.PublicApi.OrderEndPoints;

/// <summary>
/// Get a Catalog Item by Id
/// </summary>
public class OrderDetailGetByIdEndpoint : IEndpoint<IResult, GetByIdOrderDetailRequest, IRepository<Order>>
{
    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapGet("api/orders/{orderNumber}",
            [Authorize(Roles = BlazorShared.Authorization.Constants.Roles.ADMINISTRATORS, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] 
            async (int orderNumber, IRepository<Order> orderRepository) =>
            {
                return await HandleAsync(new GetByIdOrderDetailRequest(orderNumber), orderRepository);
            })
            .Produces<GetByIdOrderDetailResponse>()
            .WithTags("OrderDetailEndpoints");
    }

    public async Task<IResult> HandleAsync(GetByIdOrderDetailRequest request, IRepository<Order> orderRepository)
    {
        var response = new GetByIdOrderDetailResponse(request.CorrelationId());

        var specification = new OrderWithItemsByIdSpec(request.OrderNumber);
        var order = await orderRepository.FirstOrDefaultAsync(specification);

        if (order is null)
            return Results.NotFound();

        response.OrderDetail = new OrderDetailDto
        {
            OrderDate = order.OrderDate,
            OrderItems = order.OrderItems.Select(oi => new OrderItemDto
            {
                PictureUri = oi.ItemOrdered.PictureUri,
                ProductId = oi.ItemOrdered.CatalogItemId,
                ProductName = oi.ItemOrdered.ProductName,
                UnitPrice = oi.UnitPrice,
                Units = oi.Units
            }).ToList(),
            BuyerId = order.BuyerId,
            OrderNumber = order.Id,
            ShippingAddress = order.ShipToAddress,
            Status = order.Status,
            Total = order.Total()
        };

        
        return Results.Ok(response);
    }

}
