using QuickResponse.Core.Enums;
using QuickResponse.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuickResponse.Models.ViewModels
{
    public class PostCreateModel
    {
        public int PostId { get; set; }
        [Required]
        public string PostName { get; set; }

        [Required]
        public int ProductTypeId { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public PostType PostType { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Body { get; set; }

        public DateTime? PostDate { get; set; }
        public Product Product { get; set; }
        public IEnumerable<Data.Models.ProductType> ProductTypes { get; set; }

    }
}
