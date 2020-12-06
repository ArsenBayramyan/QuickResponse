using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuickResponse.BLL;
using QuickResponse.Core.Interfaces;
using QuickResponse.Data.Repositories;
using QuickResponse.Models.ViewModels;
using QuickResponse.Validation;

namespace QuickResponse.Controllers
{
    public class PostController:Controller
    {
        private UnitOfWorkRepository _uow;
        private IMapper _mapper;
        
        public PostController(IUnitOfWOrkRepositroy unitOfWOrkRepositroy, IMapper mapper)
        {
            this._uow = (UnitOfWorkRepository)unitOfWOrkRepositroy;
            this._mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddPost(PostCreateModel postAdd)
        {
            var validator = new PostCreateValidator();
            if (validator.Validate(postAdd).IsValid)
            {
                var postBL = new PostBL(_uow, _mapper);
                var currentUser = _uow.UserManager.FindByNameAsync(HttpContext.User.Identity.Name).Result;
                if (postBL.AddPost(postAdd,currentUser))
                {
                    return RedirectToAction("");
                }
            }
            return RedirectToAction("AddPost");
        }

        [HttpGet]
        public IActionResult UserPostList(int userId)
        {
            var postBL = new PostBL(_uow, _mapper);
            postBL.UserPostList(userId);
            return View();
        }

        [HttpGet]
        public IActionResult PostListFilter(int postId)
        {
            var postBL = new PostBL(_uow, _mapper);
            postBL.PostListFilter(postId);
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (_uow.PostRepository.DeleteById(id))
            {
                return RedirectToAction("");
            }
            return null;
        }
    }
}
