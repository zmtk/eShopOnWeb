using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using MinimalApi.Endpoint;

namespace Microsoft.eShopWeb.PublicApi.OrderEndPoints;

/// <summary>
/// Deletes a Catalog Item
/// </summary>
public class UpdateOrderStatusEndpoint : IEndpoint<IResult, UpdateOrderStatusRequest, IRepository<Order>>
{
    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapPut("api/orders/{orderNumber}",
            [Authorize(Roles = BlazorShared.Authorization.Constants.Roles.ADMINISTRATORS, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] 
            async (UpdateOrderStatusRequest request, IRepository<Order> orderRepository) =>
            {
                return await HandleAsync(request, orderRepository);
            })
            .Produces<UpdateOrderStatusResponse>()
            .WithTags("OrderEndpoints");
    }

    public async Task<IResult> HandleAsync(UpdateOrderStatusRequest request, IRepository<Order> orderRepository)
    {
        var response = new UpdateOrderStatusResponse(request.CorrelationId());

        var orderToConfirm = await orderRepository.GetByIdAsync(request.OrderNumber);

        if (orderToConfirm is null)
            return Results.NotFound();
        
        orderToConfirm.UpdateStatus(request.Status);

        await orderRepository.UpdateAsync(orderToConfirm);

        response.Status = orderToConfirm.Status;

        return Results.Ok(response);
    }
}
