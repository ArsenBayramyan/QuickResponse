using QuickResponse.Core.Enums;
using QuickResponse.Core.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace QuickResponse.Data.Models
{
    public class Post:IPost
    {
        [Key]
        public int PostId { get; set; }
        public string PostName { get; set; }
        public PostType PostType { get; set; }
        public decimal Price { get; set; }
        public string Body { get; set; }
        public DateTime? PostDate { get; set; }
        public bool? IsDeleted { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
