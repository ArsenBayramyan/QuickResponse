using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuickResponse.Core.Interfaces;
using QuickResponse.Data.Contexts;
using QuickResponse.Data.Repositories;
using QuickResponse.Models;
using QuickResponse.Models.ViewModels;
using QuickResponse.Validation;
using ReflectionIT.Mvc.Paging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWorkRepository _uow;
        private IMapper _mapper;
        public HomeController(IUnitOfWOrkRepositroy unitOfWOrkRepositroy, IMapper mapper)
        {
            this._uow = (UnitOfWorkRepository)unitOfWOrkRepositroy;
            this._mapper = mapper;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            var posts = _uow.PostRepository.List().AsQueryable().OrderByDescending(p=>p.PostId);
            var model = await PagingList.CreateAsync(posts,4,page);
            return View(model);
        }
        public IActionResult Contact() => View();
        [HttpPost]
        public IActionResult Contact(ContactViewModel contactViewModel)
        {
            var validator = new ContactMeValidator();
            if (validator.Validate(contactViewModel).IsValid)
            {
                var message =
                    $"Name: - {contactViewModel.Name}\n" +

                    $"Phone: - {contactViewModel.Phone}\n" +

                    $"Email: - {contactViewModel.Email}\n" +

                    $"Answer: - {contactViewModel.Message}";

                Core.EmailSender.SendEmailMessage("arsen1997b@mail.ru", message,$"{contactViewModel.Name} wants to contact me");
                return RedirectToAction("Index");
            }
            else
            {
                return View(contactViewModel);
            }
        }

        public IActionResult About() => View();
    }
}
