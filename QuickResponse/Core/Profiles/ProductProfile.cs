using AutoMapper;
using QuickResponse.Data.Models;
using QuickResponse.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Core.Profiles
{
    public class ProductProfile:Profile
    {
        public const string ViewModel = "PostProfile";

        public override string ProfileName => ViewModel;
        public ProductProfile()
        {
            var t = new ProductTypeCreateModel();
            this.CreateMap<ProductTypeCreateModel, ProductType>();
        }
    }
}
