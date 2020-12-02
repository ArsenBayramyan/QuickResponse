using AutoMapper;
using QuickResponse.Data.Models;
using QuickResponse.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Core.Profiles
{
    public class PostProfile:Profile
    {
        public const string ViewModel = "PostProfile";

        public override string ProfileName => ViewModel;
        public PostProfile()
        {
            var t = new PostCreateModel();
            this.CreateMap<PostCreateModel,Post>()
                .ForMember(p => p.PostName, src => src.MapFrom(i =>i.PostName))
                .ForMember(p => p.PostType, src => src.MapFrom(i => i.PostType))
                .ForMember(p=>p.PostDate,src=>src.MapFrom(i=>i.PostDate))
                .ForMember(p=>p.Product.ProductType,src=>src.MapFrom(i=>i.ProductType));
        }
    }
}
