using AutoMapper;
using QuickResponse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Core.Profiles
{
    public class ProductTypeBLToProductTypePLProfile:Profile
    {
        public const string ViewModel = "ProductTypeBLToProductTypePLProfile";

        public override string ProfileName => ViewModel;
        public ProductTypeBLToProductTypePLProfile()
        {
            this.CreateMap<BLL.Models.ProductType, ProductType>();
        }
    }
}
