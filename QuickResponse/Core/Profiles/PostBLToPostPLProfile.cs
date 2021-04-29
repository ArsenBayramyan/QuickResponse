using AutoMapper;
using QuickResponse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Core.Profiles
{
    public class PostBLToPostPLProfile:Profile
    {
        public const string ViewModel = "OrderBLToOrderPLProfile";

        public override string ProfileName => ViewModel;
        public PostBLToPostPLProfile()
        {
            this.CreateMap<BLL.Models.Post, Post>();
        }
    }
}
