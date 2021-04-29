using AutoMapper;
using QuickResponse.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Core.Profiles
{
    public class OrderDALToOrderBLProfile:Profile
    {
        public const string ViewModel = "OrderDAlToOrderBLProfile";

        public override string ProfileName => ViewModel;
        public OrderDALToOrderBLProfile()
        {
            var p = new Data.Models.Order();
            this.CreateMap<Data.Models.Order, Order>();
        }
    }
}
