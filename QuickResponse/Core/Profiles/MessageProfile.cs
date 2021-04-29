using AutoMapper;
using QuickResponse.Data.Models;
using QuickResponse.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Core.Profiles
{
    public class MessageProfile:Profile
    {
        public const string ViewModel = "MessageProfile";

        public override string ProfileName => ViewModel;
        public MessageProfile()
        {
            this.CreateMap<MessageViewModel, Message>();
            this.CreateMap<Message, MessageViewModel>();
        }
    }
}
