using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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

public class OrderListEndpoint : IEndpoint<IResult, IReadRepository<Order>>
{
    private readonly IMapper _mapper;

    public OrderListEndpoint(IMapper mapper)
    {
        _mapper = mapper;
    }
    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapGet("api/orders",
            [Authorize(Roles = BlazorShared.Authorization.Constants.Roles.ADMINISTRATORS, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] 
            async (IReadRepository<Order> orderRepository) =>
            {
                return await HandleAsync(orderRepository);
            })
            .Produces<ListOrderResponse>()
            .WithTags("OrderEndpoints");
    }

    public async Task<IResult> HandleAsync(IReadRepository<Order> orderRepository)
    {
        var response = new ListOrderResponse();

        var specification = new ListOrdersSpecification();
        var orders = await orderRepository.ListAsync(specification);
                
        response.Orders.AddRange(orders.Select(_mapper.Map<OrderDto>));

        return Results.Ok(response);
    }
}