using AutoMapper;
using QuickResponse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Core.Profiles
{
    public class OrderBLToOrderPLProfile:Profile
    {
        public const string ViewModel = "OrderBLToOrderPLProfile";
        public override string ProfileName => ViewModel;
        public OrderBLToOrderPLProfile()
        {
            this.CreateMap<BLL.Models.Order, Order>();
        }
    }
}
