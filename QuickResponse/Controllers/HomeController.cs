using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuickResponse.Core.Interfaces;
using QuickResponse.Data.Repositories;
using QuickResponse.Models.ViewModels;
using System.Linq;

namespace QuickResponse.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWorkRepository _uow;
        private IMapper _mapper;
        public int PageSize = 4;
        public HomeController(IUnitOfWOrkRepositroy unitOfWOrkRepositroy, IMapper mapper)
        {
            this._uow = (UnitOfWorkRepository)unitOfWOrkRepositroy;
            this._mapper = mapper;
        }
        public ViewResult Index(int page = 1)
        {
            var index = new IndexViewModel()
            {
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = _uow.PostRepository.List().Count()
                },
                Posts = _uow.PostRepository.List()
                      .OrderBy(p => p.PostId)
                      .Skip((page - 1) * PageSize)
                      .Take(PageSize)
            };
            return View(index);
        }
    }
}
