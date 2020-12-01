using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Data.Models
{
    public class ProductType
    {
        public int Id { get; set; }
        public string ProductTypeName { get; set; }
        public string Dimensionality { get; set; }
        public bool IsDeleted { get; set; }

    }
}
