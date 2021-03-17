using RetailShop.Models.ViewModel;
using RetailShop.Repository.EntityModels;
using RetailShop.Repository.Interface;
using RetailShop.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RetailShop.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;

        }

        public void AddProduct(ProductViewModel ProductViewModel)
        {
            var product = new Product()
            {
                ProductName = ProductViewModel.ProductName,
                ProductQuantity = ProductViewModel.ProductQuantity
            };

            _productRepository.AddProduct(product);
        }

        public List<Product> Get()
        {
            return _productRepository.Get();
        }

        public Product GetById(Guid id)
        {
            return _productRepository.GetById(id);
        }

        public void UpdateProduct(Product product, ProductViewModel productViewModel)
        {
            var updateproduct = new Product()
            {
                ProductName = productViewModel.ProductName,
                ProductQuantity = productViewModel.ProductQuantity
            };


            _productRepository.UpdateProduct(product, updateproduct);
        }

        public void DeleteProduct(Product product)
        {
            _productRepository.DeleteProduct(product);
        }

    }
}
