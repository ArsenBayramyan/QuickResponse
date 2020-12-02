using AutoMapper;
using QuickResponse.Data.Models;
using QuickResponse.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Core.Profiles
{
    public class OrderProfile:Profile
    {
        public const string ViewModel = "PostProfile";

        public override string ProfileName => ViewModel;
        public OrderProfile()
        {
            var t = new OrderCreateModel();
            this.CreateMap<OrderCreateModel, Order>()
                .ForMember(o => o.UserTo, src => src.MapFrom(i => i.UserTo))
                .ForMember(o => o.ProductId, src => src.MapFrom(i => i.ProductId))
                .ForMember(o => o.ProuctCount, src => src.MapFrom(i => i.ProductCount));
        }
    }
}
