using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Models.ViewModels
{
    public class PostViewModel
    {
        public Post Post { get; set; }
        public User User { get; set; }
        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ProductType> ProductTypes { get; set; }
    }
}
