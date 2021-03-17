
using System;
using System.Collections.Generic;
using System.Text;
using RetailShop.Repository.EntityModels;
using RetailShop.Models.ViewModel;

namespace RetailShop.Services.Interface
{
    public interface IProductService
    {
        List<Product> Get();
        void AddProduct(ProductViewModel ProductViewModel);

        public Product GetById(Guid id);

        public void UpdateProduct(Product product, ProductViewModel productViewModel);

        public void DeleteProduct(Product product);
    }
}
