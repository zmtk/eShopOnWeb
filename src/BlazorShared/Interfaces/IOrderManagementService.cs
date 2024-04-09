using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorShared.Models.Order;

namespace BlazorShared.Interfaces;

public interface IOrderManagementService
{     
    Task<List<Order>> List();
    Task<OrderDetail> GetById(int id);
    Task<string> Confirm(int id);

}