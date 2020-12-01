using QuickResponse.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Data.Models
{
    public class Order
    {
<<<<<<< HEAD
        public string Id { get; set; }
        public string UserFrom { get; set; }
        public string UserTo { get; set; }
        public string PostCategory { get; set; }
        public bool Status { get; set; }
        public int Count { get; set; }
=======
        public int OrderId { get; set; }
        public int UserFrom { get; set; }
        public int UserTo { get; set; }

        public OrderStatus Status;
        public int ProuctCount { get; set; }
        public int PostId { get; set; }
>>>>>>> a415954e956d45bba4039cc74784c63431d0e367
    }
}
