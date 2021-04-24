using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Models.ViewModels
{
    public class OrderCreateModel
    {
        public int PostId { get; set; }
        [Display(Name = "Հայտարարություն տեղադրողը")]
        public int UserFrom { get; set; }
        [Display(Name = "Հայտարարություն տեղադրողը")]
        public int UserTo { get; set; }
        [Display(Name = "Ապրանքը")]
        public int ProductId { get; set; }
        [Display(Name = "Քանակը")]
        public int ProductCount { get; set; }
    }
}
