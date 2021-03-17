using RetailShop.Repository.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RetailShop.Repository.Interface
{
    public interface IProductRepository
    {
        List<Product> Get();

        public Product GetById(Guid id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        void AddProduct(Product user);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <param name="entity"></param>
        public void UpdateProduct(Product product, Product entity);

        public void DeleteProduct(Product product);


    }
}
