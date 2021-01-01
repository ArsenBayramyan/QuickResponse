using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuickResponse.BLL;
using QuickResponse.Core.Interfaces;
using QuickResponse.Data.Repositories;
using QuickResponse.Models.ViewModels;
using QuickResponse.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickResponse.Controllers
{
    public class PostController : Controller
    {
        private UnitOfWorkRepository _uow;
        private IMapper _mapper;

        public PostController(IUnitOfWOrkRepositroy unitOfWOrkRepositroy, IMapper mapper)
        {
            this._uow = (UnitOfWorkRepository)unitOfWOrkRepositroy;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult CreatePost() => View(new PostCreateModel { ProductTypes = _uow.ProductTypeRepository.List() });

        [HttpPost]
        public IActionResult CreatePost(PostCreateModel postAdd)
        {
            postAdd.PostDate = DateTime.Now;
            var validator = new PostCreateValidator();
            if (validator.Validate(postAdd).IsValid)
            {
                var postBL = new PostBL(_uow, _mapper);
                Data.Models.User? currentUser = _uow.UserManager.FindByNameAsync(HttpContext.User?.Identity?.Name).Result;
                if (postBL.AddPost(postAdd, currentUser))
                {
                    return RedirectToAction("AccountPage", "Account");
                }
            }
            return RedirectToAction("");
        }

        [HttpGet]
        public IActionResult PostListFilter(int id)
        {
            var postBL = new PostBL(_uow, _mapper);
            IEnumerable<Data.Models.Post> postFilter = postBL.PostListFilter(id);
            return View(postFilter);
        }

        [HttpGet]
        public IActionResult PostView(int id)
        {
            return View(new PostViewModel
            {
                Post = this._uow.PostRepository.List().Where(p => p.PostId == id).FirstOrDefault(),
                Users = this._uow.UserRepository.List(),
                Products = this._uow.ProductRepository.List(),
                ProductTypes = this._uow.ProductTypeRepository.List()
            });
        }

        
        public IActionResult PostDelete(int id)
        {
            if (_uow.PostRepository.DeleteById(id))
            {
                return RedirectToAction("UserPostList");
            }
            return null;
        }
    }
}
