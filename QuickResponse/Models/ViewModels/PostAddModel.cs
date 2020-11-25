using System;
using System.ComponentModel.DataAnnotations;

namespace QuickResponse.Models.ViewModels
{
    public class PostAddModel
    {
        [Required]
        public string PostName { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string PostType { get; set; }

        [Required]
        public string Body { get; set; }

        public DateTime? PostDate { get; set; }
    }
}
