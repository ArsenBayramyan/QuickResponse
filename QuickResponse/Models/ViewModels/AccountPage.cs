using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Models.ViewModels
{
    public class AccountPage
    {
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ProductType> ProductTypes { get; set; }
        public User CurrentUser { get; set; }
        public User ToUser { get; set; }
    }
}
