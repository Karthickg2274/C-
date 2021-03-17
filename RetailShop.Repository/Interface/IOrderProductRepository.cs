using RetailShop.Repository.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RetailShop.Repository.Interface
{
    public interface IOrderProductRepository
    {
        Task<IEnumerable<OrderProduct>> GetOrderDetails();
        Task<OrderProduct> GetOrderDetail(Guid id);
        Task<OrderProduct> PlaceOrder(OrderProduct Order);
  
        Task DeleteOrder(OrderProduct Order);
    }
}
