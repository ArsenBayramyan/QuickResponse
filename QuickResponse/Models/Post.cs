using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Models
{
    public class Post
    {
        public int PostID { get; set; }
        public string PostName { get; set; }
        public string Category { get; set; }
        public string PostType { get; set; }
        public string From { get; set; }
        public string Body { get; set; }
        public DateTime? PostDate { get; set; }
        public bool? IsDeleted { get; set; }
        public int UserId { get; set; }
    }
}
