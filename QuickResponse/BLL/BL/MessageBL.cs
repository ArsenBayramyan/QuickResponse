using AutoMapper;
using QuickResponse.Core;
using QuickResponse.Core.Helpers;
using QuickResponse.Data.Models;
using QuickResponse.Data.Repositories;
using QuickResponse.Models.ViewModels;

namespace QuickResponse.BLL.BL
{
    public class MessageBL:BaseBL
    {
        public MessageBL(UnitOfWorkRepository unitOfWorkRepository, IMapper mapper) : base(unitOfWorkRepository, mapper) { }

        public bool SendMessage(MessageViewModel messageViewModel, int postId)
        {
            var message = Mapper.Map<MessageViewModel, Message>(messageViewModel);
            message.Body = message.Body.CodeingCaesar();
            if (UOW.MessageRepository.Save(message))
            {
                var post = UOW.PostRepository.GetByID(postId);
                string subject = $"{post.PostName}";
                messageViewModel.Body += $"   \n post link-{messageViewModel.PostLink}";
                EmailSender.SendEmailMessage(messageViewModel.ToUserEmail, messageViewModel.Body, subject);

                return true;
            }

            return false;
        }

    }
}
