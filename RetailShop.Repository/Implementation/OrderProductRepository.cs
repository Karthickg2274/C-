using Microsoft.EntityFrameworkCore;
using RetailShop.Repository.EntityModels;
using RetailShop.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RetailShop.Repository.Implementation
{
    public class OrderProductRepository : IOrderProductRepository
    {
        private readonly AppDbContext _dbContext;
        public OrderProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<OrderProduct>> GetOrderDetails()
        {
            var result = await _dbContext.OrderProducts.Include(obj => obj.Product).ToListAsync();
            return result;
        }
        public async Task<OrderProduct> GetOrderDetail(Guid id)
        {
            var result = await _dbContext.OrderProducts.FindAsync(id);
            return result;

        }
        public async Task<OrderProduct> PlaceOrder(OrderProduct Order)
        {
            var product = await _dbContext.Products.FindAsync(Order.ProductId);
            if (Order.Quantity <= product.ProductQuantity)
            {
                _dbContext.OrderProducts.Add(Order);
                product.ProductQuantity -= Order.Quantity;
                await _dbContext.SaveChangesAsync();
                return Order;

            }
            return null;
        }

        public async Task DeleteOrder(OrderProduct Order)
        {
            _dbContext.OrderProducts.Remove(Order);
            await _dbContext.SaveChangesAsync();
        }
    }
}
