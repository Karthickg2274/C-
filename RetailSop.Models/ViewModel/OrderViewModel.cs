using System;
using System.Collections.Generic;
using System.Text;

namespace RetailShop.Models.ViewModel
{
    public class OrderViewModel
    {
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
