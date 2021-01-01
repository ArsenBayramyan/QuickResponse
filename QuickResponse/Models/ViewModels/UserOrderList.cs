using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Models.ViewModels
{
    public class UserOrderList
    {
        public Data.Models.Order Order { get; set; }
        public IEnumerable<Data.Models.Post> Posts { get; set; }
        public IEnumerable<Data.Models.User> Users { get; set; }
        public IEnumerable<Data.Models.Product> Products { get; set; }
        public IEnumerable<Data.Models.ProductType> ProductTypes { get; set; }
        public IEnumerable<Data.Models.Order> Orders { get; set; }
    }
}
