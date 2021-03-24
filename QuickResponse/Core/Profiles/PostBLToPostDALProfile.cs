using AutoMapper;
using QuickResponse.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Core.Profiles
{
    public class PostBLToPostDALProfile:Profile
    {
        public const string ViewModel = "PostBLToPostDALProfile";

        public override string ProfileName => ViewModel;
        public PostBLToPostDALProfile()
        {
            var p = new BLL.Models.Post();
            this.CreateMap<BLL.Models.Post, Post>();
        }
    }
}
