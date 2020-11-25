using QuickResponse.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Models.ViewModels
{
    public class PostsList
    {
        public IEnumerable<Data.Models.Post> Posts { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
