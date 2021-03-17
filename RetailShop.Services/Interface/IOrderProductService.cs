using RetailShop.Models.ViewModel;
using RetailShop.Repository.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RetailShop.Services.Interface
{
    public interface IOrderProductService
    {
        Task<IEnumerable<OrderProduct>> GetOrderDetails();
        Task<OrderProduct> GetOrderDetail(Guid id);
        Task<OrderProduct> PlaceOrder(OrderViewModel Order);
       
        Task DeleteOrder(Guid id);
    }
}
