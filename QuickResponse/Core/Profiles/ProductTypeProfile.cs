using AutoMapper;
using QuickResponse.Models;

namespace QuickResponse.Core.Profiles
{
    public class ProductTypeProfile : Profile
    {
        public const string ViewModel = "ProductTypeProfile";

        public override string ProfileName => ViewModel;

        public ProductTypeProfile()
        {
            var t = new ProductType();
            this.CreateMap<ProductType, Data.Models.ProductType>();
        }
    }
}
