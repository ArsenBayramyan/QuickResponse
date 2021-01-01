﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuickResponse.BLL;
using QuickResponse.Core.Interfaces;
using QuickResponse.Data.Repositories;
using QuickResponse.Models.ViewModels;
using QuickResponse.Validation;
using System.Collections.Generic;

namespace QuickResponse.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UnitOfWorkRepository _uow;
        private IMapper _mapper;
        public AccountController(IUnitOfWOrkRepositroy unitOfWOrkRepositroy, IMapper mapper)
        {
            this._uow = (UnitOfWorkRepository)unitOfWOrkRepositroy;
            this._mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public ViewResult Registration() => View();

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Registration(UserCreateModel userCreateModel)
        {
            var validator = new UserCreateValidator();
            if (validator.Validate(userCreateModel).IsValid)
            {
                var accountBL = new AccountBL(_uow, _mapper);
                if (accountBL.Registration(userCreateModel))
                {
                    return RedirectToAction("Login", new UserLoginModel
                    {
                        Email = userCreateModel.Email,
                        Password = userCreateModel.Password
                    });
                }
            }
            return View(userCreateModel);
        }

        [HttpGet]
        [AllowAnonymous]
        public ViewResult Login() => View();

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(UserLoginModel userLoginModel)
        {
            var validator = new UserLoginValidator();
            if (validator.Validate(userLoginModel).IsValid)
            {
                var accountBL = new AccountBL(_uow, _mapper);
                if (accountBL.Login(userLoginModel))
                {
                    return RedirectToAction("AccountPage");
                }
            }
            ModelState.AddModelError(nameof(userLoginModel.Email), "Invalid user or password");
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult AccountPage() => View(new AccountPage
        {
            Orders = _uow.OrderRepository.List(),
            Posts = _uow.PostRepository.List(),
            Products = _uow.ProductRepository.List(),
            ProductTypes = _uow.ProductTypeRepository.List(),
            CurrentUser = _uow.UserManager.FindByNameAsync(HttpContext.User.Identity.Name).Result
        });

        [HttpGet]
        public IActionResult LogOut() => RedirectToAction("Login");

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (_uow.UserRepository.DeleteById(id))
            {
                return RedirectToAction("Login");
            }
            return null; 
        }

        [HttpGet]
        public IActionResult UserPostList()
        {
            var currentUser = _uow.UserManager.FindByNameAsync(HttpContext.User?.Identity?.Name).Result;
            var postBL = new PostBL(_uow, _mapper);
            IEnumerable<Data.Models.Post> posts = postBL.UserPostList(currentUser.Id);

            IEnumerable<Data.Models.User> users = this._uow.UserRepository.List();
            IEnumerable<Data.Models.Product> products = this._uow.ProductRepository.List();
            IEnumerable<Data.Models.ProductType> productTypes = this._uow.ProductTypeRepository.List();

            return View(new PostViewModel
            {
                Posts = posts,
                Users = users,
                Products = products,
                ProductTypes = productTypes
            });
        }

        [HttpGet]
        public IActionResult UserOrderList()
        {
            IEnumerable<Data.Models.Post> posts = this._uow.PostRepository.List();
            IEnumerable<Data.Models.User> users = this._uow.UserRepository.List();
            IEnumerable<Data.Models.Product> products = this._uow.ProductRepository.List();
            IEnumerable<Data.Models.ProductType> productTypes = this._uow.ProductTypeRepository.List();
            IEnumerable<Data.Models.Order> orders = this._uow.OrderRepository.List();
            return View(new UserOrderList
            {
                Posts = posts,
                Users = users,
                Products = products,
                ProductTypes = productTypes,
                Orders = orders
            });
        }
    }
}

