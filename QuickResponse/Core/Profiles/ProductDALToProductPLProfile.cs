using AutoMapper;
using QuickResponse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Core.Profiles
{
    public class ProductDALToProductPLProfile:Profile
    {
        public const string ViewModel = "ProductDALToProductPLProfile";

        public override string ProfileName => ViewModel;
        public ProductDALToProductPLProfile()
        {
            var p = new Data.Models.Product();
            this.CreateMap<Data.Models.Product, Product>();
        }
    }
}
