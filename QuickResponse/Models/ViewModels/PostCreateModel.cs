using QuickResponse.Data.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace QuickResponse.Models.ViewModels
{
    public class PostCreateModel
    {
        [Required]
        public string PostName { get; set; }

        [Required]
        public ProductType ProductType { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public string PostType { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Body { get; set; }

        public DateTime? PostDate { get; set; }
        public Product Product;

    }
}
