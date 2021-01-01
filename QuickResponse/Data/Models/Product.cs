using QuickResponse.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Data.Models
{
    public class Product:IProduct
    {
        public int ProductId { get; set; }
        public int ProductTypeId { get; set; }
        public int Count { get; set; }
        public bool IsDeleted { get; set; }
        public ProductType ProductType { get; set; }
    }
}
