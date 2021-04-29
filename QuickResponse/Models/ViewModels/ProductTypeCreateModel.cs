using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Models.ViewModels
{
    public class ProductTypeCreateModel
    {
        [Display(Name = "Ապրանքի տեսակը")]
        public string ProductTypeName { get; set; }
        [Display(Name = "Չափման միավորը")]
        public string Dimensionality { get; set; }
    }
}
