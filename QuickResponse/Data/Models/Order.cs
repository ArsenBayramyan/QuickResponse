using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Data.Models
{
    public class Order
    {
        public string Id { get; set; }
        public string UserFrom { get; set; }
        public string UserTo { get; set; }
        public string PostCategory { get; set; }
        public bool Status { get; set; }
        public int Count { get; set; }
    }
}
