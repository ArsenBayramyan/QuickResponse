using AutoMapper;
using QuickResponse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Core.Profiles
{
    public class OrderDAlToOrderPLProfile:Profile
    {
        public const string ViewModel = "OrderDAlToOrderPLProfile";

        public override string ProfileName => ViewModel;
        public OrderDAlToOrderPLProfile()
        {
            var p = new Data.Models.Order();
            this.CreateMap<Data.Models.Order, Order>();
        }
    }
}
