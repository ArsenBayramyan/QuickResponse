using AutoMapper;
using QuickResponse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Core.Profiles
{
    public class ProductDALToProductBLProfile:Profile
    {
        public const string ViewModel = "ProductDALToProductPLProfile";

        public override string ProfileName => ViewModel;
        public ProductDALToProductBLProfile()
        {
            this.CreateMap<Data.Models.Product, Product>();
        }
    }
}
