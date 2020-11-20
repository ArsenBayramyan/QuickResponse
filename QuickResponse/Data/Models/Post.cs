using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickResponse.Data.Models
{
    [Table("Posts")]
    public class Post
    {
        public int PostID { get; set; }
        public string From { get; set; }
        public string Body { get; set; }
        public DateTime? PostDate { get; set; }
        public bool? IsDeleted { get; set; }
        public int UserId { get; set; }
    }
}
