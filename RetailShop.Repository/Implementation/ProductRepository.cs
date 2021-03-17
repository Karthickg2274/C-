using RetailShop.Repository.EntityModels;
using RetailShop.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RetailShop.Repository.Implementation
{
     public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        } 

        public List<Product> Get()
        {
            return _dbContext.Products.ToList();
        }

        public void AddProduct(Product product)
        {

            _dbContext.Add(product);
            _dbContext.SaveChanges();
        }

        public Product GetById(Guid id)
        {
            return _dbContext.Products.FirstOrDefault(e => e.ProductId == id);
        }

        public void UpdateProduct(Product product, Product entity)
        {
            product.ProductName = entity.ProductName;
            product.ProductQuantity = entity.ProductQuantity;
            _dbContext.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
        }
    }
}
