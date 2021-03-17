using AutoMapper;
using QuickResponse.Data.Models;
using QuickResponse.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Core.Profiles
{
    public class UserCreateProfile:Profile
    {
        public const string ViewModel = "UserCreateProfile";

        public override string ProfileName => ViewModel;
        public UserCreateProfile()
        {
            var t = new UserCreateModel();
            this.CreateMap<UserCreateModel, User>()
                .ForMember(u=>u.Id,src=>src.MapFrom(i=>i.UserID))
                .ForMember(u => u.PasswordHash, src => src.MapFrom(i => i.Password))
                .ForMember(u=>u.PhoneNumber,src=>src.MapFrom(i=>i.Phone))
                .ForMember(u=>u.UserName, src => src.MapFrom(i => i.Email));
        }
    }
}
