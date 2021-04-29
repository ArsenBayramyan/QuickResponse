using AutoMapper;
using QuickResponse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Core.Profiles
{
    public class UserBLToUserPLProfile:Profile
    {
        public const string ViewModel = "UserBLToUserPLProfile";

        public override string ProfileName => ViewModel;
        public UserBLToUserPLProfile()
        {
            this.CreateMap<BLL.Models.User, User>();
        }
    }
}
