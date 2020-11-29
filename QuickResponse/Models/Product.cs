using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Models
{
    public class Product
    {
        public string ProductId { get; set; }
        public string ProductTypeId { get; set; }
        public string Count { get; set; }
        public bool IsDeleted { get; set; }
        public ProductType ProductType { get; set; }
    }
}
