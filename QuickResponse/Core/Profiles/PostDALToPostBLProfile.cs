using AutoMapper;
using QuickResponse.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Core.Profiles
{
    public class PostDALToPostBLProfile:Profile
    {
        public const string ViewModel = "PostDALToPostBLProfile";

        public override string ProfileName => ViewModel;
        public PostDALToPostBLProfile()
        {
            var p = new Data.Models.Post();
            this.CreateMap<Data.Models.Post, Post>();
        }
    }
}
