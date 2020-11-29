using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Models.ViewModels
{
    public class OrderAddModel
    {
        public string PostNameFrom { get; set; }
        public string PostNameTo { get; set; }
        public string PostCategory { get; set; }
        public bool Success { get; set; }
    }
}
