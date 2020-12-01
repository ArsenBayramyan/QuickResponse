using QuickResponse.Core.Enums;
using QuickResponse.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserFrom { get; set; }
        public int UserTo { get; set; }
        public int ProductId { get; set; }
        public int ProuctCount { get; set; }
        public OrderStatus Status;
    }
}
