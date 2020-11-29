using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Data.Models
{
    public class Order
    {
        public string Id { get; set; }
        public string PostNameFrom { get; set; }
        public string PostNameTo { get; set; }
        public string PostCategory { get; set; }
        public bool Success { get; set; }
        public string UserId { get; set; }
        public string PostId { get; set; }
    }
}
