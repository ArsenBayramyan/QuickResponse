using QuickResponse.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Data.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserFrom { get; set; }
        public int UserTo { get; set; }

        public OrderStatus Status;
        public int ProuctCount { get; set; }
        public int PostId { get; set; }
    }
}
