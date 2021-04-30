using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickResponse.BLL.BL;
using QuickResponse.Core.Helpers;
using QuickResponse.Core.Interfaces;
using QuickResponse.Data.Models;
using QuickResponse.Data.Repositories;
using QuickResponse.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Controllers
{
    public class MessageController : Controller
    {
        private UnitOfWorkRepository _uow;
        private IMapper _mapper;
        private IUser _userTo;
        private IPost _post;
        private IMessage _message;

        public MessageController(IUnitOfWOrkRepositroy unitOfWOrkRepositroy, IMapper mapper, IUser userTo, IPost post, IMessage message)
        {
            _uow = (UnitOfWorkRepository)unitOfWOrkRepositroy;
            _mapper = mapper;
            _userTo = userTo;
            _post = post;
            _message = message;
        }
        // GET: MessageController
        public ActionResult Index()
        {
            var currentUser = _uow.UserManager.FindByNameAsync(HttpContext.User?.Identity?.Name).Result;
            var messages = _uow.MessageRepository.List().Where(m => m.ToUserEmail == currentUser.Email);
            var messagesViewModels = new List<MessageViewModel>();

            foreach (var ms in messages)
            {
                var message = _mapper.Map<Message, MessageViewModel>(ms);
                message.Body = message.Body.DecodingWithMatrix();
                messagesViewModels.Add(message);
            }
            var users = _uow.UserRepository.List();
            var usersViewModels = _mapper.Map<IEnumerable<User>, IEnumerable<UserCreateModel>>(users);

            return View(new MessageViewModel { Messages = messagesViewModels, Users = usersViewModels });

        }

        // GET: MessageController/Create
        public ActionResult Create(int id, int check)
        {
            if (check == 1)
            {
                _message.MessageId = id;
            }
            else if(check==-1)
            {
                _post.PostId = id;
                var post = _uow.PostRepository.GetByID(id);
                _userTo.Id = post.UserId;
                _message.MessageId = check;
            }
            else
            {
                _post.PostId = id;
                var post = _uow.PostRepository.GetByID(id);
                _userTo.Id = post.UserId;
                _message.MessageId = check;
            }

            return View(new MessageViewModel { MessageId = check });
        }

        // POST: MessageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MessageViewModel messageViewModel)
        {
            var currentUser = _uow.UserManager.FindByNameAsync(HttpContext.User?.Identity?.Name).Result;
            messageViewModel.FromUserEmail = currentUser.Email;
            MessageBL messageBL = new MessageBL(_uow, _mapper);
            Post post = null;

            if (_userTo.Id == 0)
            {
                var message = _uow.MessageRepository.GetByID(_message.MessageId);
                messageViewModel.ToUserEmail = message.FromUserEmail;
                messageViewModel.MessageSentDate = DateTime.Now;
                messageViewModel.PostLink = message.PostLink;
                var postId = int.Parse(message.PostLink.Substring(message.PostLink.LastIndexOf("/") + 1));
                post = _uow.PostRepository.GetByID(postId);
                if (messageBL.SendMessage(messageViewModel, post))
                {
                    return RedirectToAction("Delete", new { id = message.MessageId });
                }
            }
            else
            {
                if (_message.MessageId == -1)
                {
                    messageViewModel.ToUserEmail = "quick_response_soft@mail.ru";
                }
                else
                {
                    messageViewModel.ToUserEmail = _uow.UserRepository.GetByID(_userTo.Id).Email;
                }

                messageViewModel.MessageSentDate = DateTime.Now;
                post = _uow.PostRepository.GetByID(_post.PostId);
                messageViewModel.PostLink = $"https://localhost:44372/Post/PostView/{post.PostId}";

                if (messageBL.SendMessage(messageViewModel, post))
                {
                    return RedirectToAction("AccountPage", "Account");
                }

            }

            return RedirectToAction("Create");
        }


        public IActionResult Delete(int id)
        {
            _uow.MessageRepository.DeleteById(id);

            return RedirectToAction("AccountPage", "Account");

        }


    }
}
