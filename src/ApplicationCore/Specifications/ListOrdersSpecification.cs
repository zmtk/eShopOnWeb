using Ardalis.Specification;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;

namespace Microsoft.eShopWeb.ApplicationCore.Specifications;

public class ListOrdersSpecification : Specification<Order>
{
    public ListOrdersSpecification()
    {
        Query.Include(o => o.OrderItems);
    }
}