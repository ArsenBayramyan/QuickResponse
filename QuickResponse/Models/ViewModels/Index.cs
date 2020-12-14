using System.Collections.Generic;

namespace QuickResponse.Models.ViewModels
{
    public class Index
    {
        public IEnumerable<Data.Models.Post> Posts { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
