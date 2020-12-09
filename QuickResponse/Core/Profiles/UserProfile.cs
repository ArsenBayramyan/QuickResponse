using AutoMapper;
using QuickResponse.Data.Models;
using QuickResponse.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Core.Profiles
{
    public class UserProfile:Profile
    {
        public const string ViewModel = "UserProfile";

        public override string ProfileName => ViewModel;
        public UserProfile()
        {
            var t = new UserCreateModel();
            this.CreateMap<OrderCreateModel, User>();
        }
    }
}
