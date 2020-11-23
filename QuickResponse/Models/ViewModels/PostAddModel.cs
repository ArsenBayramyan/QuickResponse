using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Models.ViewModels
{
    public class PostAddModel
    {
        [Required]
        public string PostName { get; set; }
        public string Category { get; set; }
        public string PostType { get; set; }
        public string Body { get; set; }
        public DateTime? PostDate { get; set; }
    }
}
