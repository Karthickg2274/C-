using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RetailShop.Models.ViewModel;
using RetailShop.Repository.EntityModels;
using RetailShop.Services.Interface;
using System;

namespace RetailShop.API.Controllers
{
    [ApiController]
    [Route("/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_productService.Get());
        }

        [HttpPost]
        public IActionResult Add([FromBody] ProductViewModel productViewModel)
        {
            _productService.AddProduct(productViewModel);
            return Ok();
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult GetById(Guid id)
        {
            Product product = _productService.GetById(id);
            if (product == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }
            return Ok(product);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] ProductViewModel productViewModel)
        {
            if (productViewModel == null)
            {
                return BadRequest("Employee is null.");
            }
            Product productToUpdate = _productService.GetById(id);
            if (productToUpdate == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }
            _productService.UpdateProduct(productToUpdate, productViewModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            Product product = _productService.GetById(id);
            if (product == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }
            _productService.DeleteProduct(product);
            return NoContent();
        }

    }
}
