using AutoMapper;
using QuickResponse.Core;
using QuickResponse.Core.Helpers;
using QuickResponse.Data.Models;
using QuickResponse.Data.Repositories;
using QuickResponse.Models.ViewModels;

namespace QuickResponse.BLL.BL
{
    public class MessageBL : BaseBL
    {
        public MessageBL(UnitOfWorkRepository unitOfWorkRepository, IMapper mapper) : base(unitOfWorkRepository, mapper) { }

        public bool SendMessage(MessageViewModel messageViewModel, Post post)
        {
            var message = Mapper.Map<MessageViewModel, Message>(messageViewModel);
            message.Body = message.Body.CodeingCaesar();
            if (UOW.MessageRepository.Save(message))
            {
                string subject = $"{post.PostName}";
                messageViewModel.Body += $"   \npost link- {messageViewModel.PostLink}";

                if (messageViewModel.FromUserEmail == "quick_response_soft@mail.ru")
                {
                    EmailSender.SendEmailMessage("quick_response_soft@mail.ru", "Quick Response Soft", messageViewModel.ToUserEmail, messageViewModel.Body, subject);
                }
                else
                {
                    EmailSender.SendEmailMessage("quick_response_user@mail.ru", "Quick Response User", messageViewModel.ToUserEmail, messageViewModel.Body, subject);
                }

                return true;
            }

            return false;
        }

    }
}
