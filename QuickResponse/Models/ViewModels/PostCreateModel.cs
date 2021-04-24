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
        [Display(Name = "Անուն")]
        [Required]
        public string PostName { get; set; }
        [Display(Name = "Ապրանք")]
        [Required]
        public int ProductTypeId { get; set; }
        [Display(Name = "Քանակ")]
        [Required]
        public int Count { get; set; }
        [Display(Name = "Տիպը")]
        [Required]
        public PostType PostType { get; set; }
        [Display(Name = "Արժեքը")]
        [Required]
        public decimal Price { get; set; }
        [Display(Name = "Նկարագրություն")]
        [Required]
        public string Body { get; set; }
        public DateTime? PostDate { get; set; }
        public Product Product { get; set; }
        public IEnumerable<Data.Models.ProductType> ProductTypes { get; set; }

    }
}
