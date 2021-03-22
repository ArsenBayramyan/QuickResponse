using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuickResponse.BLL;
using QuickResponse.Core.Interfaces;
using QuickResponse.Data.Repositories;
using QuickResponse.Models;
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
                var currentUser = _uow.UserManager.FindByNameAsync(HttpContext.User?.Identity?.Name).Result;
                if (postBL.AddPost(postAdd, currentUser))
                {

                    return RedirectToAction("AccountPage", "Account");
                }
            }
            return RedirectToAction("");
        }

        [HttpGet]
        public IActionResult EditPost(int Id)
        {
            var post = this._uow.PostRepository.GetByID(Id);
            var product = this._uow.ProductRepository.GetByID(post.ProductId);
            //var productType = this._uow.ProductTypeRepository.GetByID(product.ProductTypeId);
            var p1 = new PostCreateModel { 
                PostId = post.PostId,
                PostDate=post.PostDate,
                PostName=post.PostName,
                Price=post.Price,
                Body=post.Body,
                Count=product.Count,
                PostType=post.PostType,
                ProductTypeId=product.ProductTypeId,
            };
            return View(p1);
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
            var postDAL = this._uow.PostRepository.List().Where(p => p.PostId == id).FirstOrDefault();
            var postPL = this._mapper.Map<Data.Models.Post, Post>(postDAL);
            var userDAL = this._uow.UserRepository.List().FirstOrDefault(u => u.Id == postPL.UserId);
            var userPL = this._mapper.Map<Data.Models.User, User>(userDAL);
            var usersDAL = this._uow.UserRepository.List();
            var postsDAL = this._uow.PostRepository.List();
            var ordersDAL = this._uow.OrderRepository.List();
            var productsDAL = this._uow.ProductRepository.List();
            var productTypesDAL = this._uow.ProductTypeRepository.List();
            var lists= Core.Mapper.MapperModels(postsDAL, usersDAL, productsDAL, ordersDAL, productTypesDAL, _mapper);
            return View(new PostViewModel
            {
                Post = postPL,
                User=userPL,
                Users = lists.usersPL,
                Products = lists.productsPL,
                ProductTypes = lists.productTypesPL
            });
        }

        
        public IActionResult PostDelete(int id)
        {
            if (_uow.PostRepository.DeleteById(id))
            {
                return RedirectToAction("UserPosts");
            }
            return null;
        }

        [HttpGet]
        public IActionResult UserPosts()
        {
            var currentUser = _uow.UserManager.FindByNameAsync(HttpContext.User?.Identity?.Name).Result;
            var postBL = new PostBL(_uow, _mapper);
            IEnumerable<Data.Models.Post> postsDAL = postBL.UserPostList(currentUser.Id);
            IEnumerable<Data.Models.User> usersDAL = this._uow.UserRepository.List();
            IEnumerable<Data.Models.Product> productsDAL = this._uow.ProductRepository.List();
            IEnumerable<Data.Models.ProductType> productTypesDAL = this._uow.ProductTypeRepository.List();
            IEnumerable<Data.Models.Order> ordersDAL = this._uow.OrderRepository.List();
            var lists=Core.Mapper.MapperModels(postsDAL, usersDAL, productsDAL, ordersDAL, productTypesDAL, _mapper);

            return View(new PostViewModel
            {
                Posts = lists.postsPL,
                Users = lists.usersPL,
                Products = lists.productsPL,
                ProductTypes = lists.productTypesPL
            });
        }

       
    }
}
