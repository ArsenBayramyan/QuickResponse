using AutoMapper;
using QuickResponse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Core.Profiles
{
    public class PostDALToPostPLProfile:Profile
    {
        public const string ViewModel = "PostDALToPostPLProfile";

        public override string ProfileName => ViewModel;
        public PostDALToPostPLProfile()
        {
            var p = new Data.Models.Post();
            this.CreateMap<Data.Models.Post, Post>();
        }
    }
}
