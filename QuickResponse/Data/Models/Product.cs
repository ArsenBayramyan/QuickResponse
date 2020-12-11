using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Data.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public int ProductTypeId { get; set; }
        public int Count { get; set; }
        public bool IsDeleted { get; set; }
        public ProductType ProductType { get; set; }
    }
}
