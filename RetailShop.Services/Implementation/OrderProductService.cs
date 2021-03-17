using RetailShop.Models.ViewModel;
using RetailShop.Repository.EntityModels;
using RetailShop.Repository.Interface;
using RetailShop.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RetailShop.Services.Implementation
{
    public class OrderProductService : IOrderProductService
    {
        private readonly IOrderProductRepository _orderProductRepository;

        public OrderProductService(IOrderProductRepository orderProductRepository)
        {
            _orderProductRepository = orderProductRepository;
        }

        public async Task<OrderProduct> GetOrderDetail(Guid id)
        {
            var result = await _orderProductRepository.GetOrderDetail(id);
            return result;

        }

        public async Task<IEnumerable<OrderProduct>> GetOrderDetails()
        {
            var result = await _orderProductRepository.GetOrderDetails();
            return result;
        }

        public async Task<OrderProduct> PlaceOrder(OrderViewModel order)
        {
            var productEntity = new OrderProduct()
            {
                Quantity = order.Quantity,
                InvoiceDate = DateTime.UtcNow,
                CustomerId = Guid.Parse("c443a935-c92b-4745-a925-bef8ad125f65"),
                ProductId = order.ProductId,
            };

            var result = await _orderProductRepository.PlaceOrder(productEntity);
            return result;
        }

        public async Task DeleteOrder(Guid id)
        {
            OrderProduct Order = await _orderProductRepository.GetOrderDetail(id);

            await _orderProductRepository.DeleteOrder(Order);
        }
    }
}
