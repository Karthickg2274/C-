using Microsoft.AspNetCore.Mvc;
using RetailShop.Models.ViewModel;
using RetailShop.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailShop.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderProductService _orderProductService;

        public OrderController(IOrderProductService orderProductService)
        {
            _orderProductService = orderProductService;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _orderProductService.GetOrderDetails();
            if (result == null)
            {
                return NotFound("Cart Empty");
            }
            return Ok(result);
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _orderProductService.GetOrderDetail(id);
            if (result == null)
            {
                return NotFound("Order not Found");
            }
            return Ok(result);
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderViewModel order)
        {
            var newOrder = await _orderProductService.PlaceOrder(order);
            if (newOrder == null)
            {
                return NotFound("Order not Placed");
            }
            return Ok();
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _orderProductService.DeleteOrder(id);
            return Ok();
        }
    }
}
