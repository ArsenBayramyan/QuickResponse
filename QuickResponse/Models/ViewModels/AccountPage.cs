using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Models.ViewModels
{
    public class AccountPage
    {
        public IEnumerable<Data.Models.User> Users { get; set; }
        public IEnumerable<Data.Models.Post> Posts { get; set; }
        public IEnumerable<Data.Models.Order> Orders { get; set; }
        public IEnumerable<Data.Models.Product> Products { get; set; }
        public IEnumerable<Data.Models.ProductType> ProductTypes { get; set; }
        public Data.Models.User CurrentUser { get; set; }
        public Data.Models.User ToUser { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
