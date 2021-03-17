using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuickResponse.Core.Interfaces;
using QuickResponse.Data.Contexts;
using QuickResponse.Data.Repositories;
using QuickResponse.Models;
using QuickResponse.Models.ViewModels;
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
            var model = await PagingList.CreateAsync(posts,5,page);
            return View(model);
        }
    }
}
