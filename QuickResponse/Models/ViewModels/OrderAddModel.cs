using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Models.ViewModels
{
    public class OrderAddModel
    {
        public int UserTo { get; set; }
        public int ProductId { get; set; }
        public int ProductCount { get; set; }
    }
}
