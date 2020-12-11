using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        public ViewResult PostList(int page = 1)
        => View(new PostList
        {
            Posts =   _uow.PostRepository.List()
                      .OrderBy(p => p.PostId)
                      .Skip((page - 1) * PageSize)
                      .Take(PageSize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = _uow.PostRepository.List().Count()
            }
        });

    }
}
