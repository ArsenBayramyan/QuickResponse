using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuickResponse.Data.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string PostName { get; set; }
        public string PostType { get; set; }
        public decimal Price { get; set; }
        public string Body { get; set; }
        public DateTime? PostDate { get; set; }
        public bool? IsDeleted { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
