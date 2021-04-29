using AutoMapper;
using QuickResponse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Core.Profiles
{
    public class ProductBLToProductPLProfile:Profile
    {
        public const string ViewModel = "ProductBLToProductPLProfile";

        public override string ProfileName => ViewModel;
        public ProductBLToProductPLProfile()
        {
            this.CreateMap<BLL.Models.Product, Product>();
        }
    }
}
