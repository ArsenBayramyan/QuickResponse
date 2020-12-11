using AutoMapper;
using QuickResponse.Data.Models;
using QuickResponse.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Core.Profiles
{
    public class UserLoginProfile:Profile
    {
        public const string ViewModel = "UserLoginProfile";

        public override string ProfileName => ViewModel;
        public UserLoginProfile()
        {
            var t = new UserLoginModel();
            this.CreateMap<UserLoginModel, User>()
                .ForMember(u => u.UserName, src => src.MapFrom(i => i.Email))
                .ForMember(u => u.PasswordHash, src => src.MapFrom(i => i.Password));
        }
    }
}
