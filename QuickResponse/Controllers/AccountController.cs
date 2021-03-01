﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuickResponse.BLL;
using QuickResponse.Core.Interfaces;
using QuickResponse.Data.Repositories;
using QuickResponse.Models;
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
        public IActionResult AccountPage()
        {
            var currentUserDAL = _uow.UserManager.FindByNameAsync(HttpContext.User?.Identity?.Name).Result;
            var currentUserPL = this._mapper.Map<Data.Models.User, User>(currentUserDAL);
            var postsDAL = this._uow.PostRepository.List();
            var usersDAL = this._uow.UserRepository.List();
            var productsDAL = this._uow.ProductRepository.List();
            var productTypesDAL = this._uow.ProductTypeRepository.List();
            var ordersDAL = this._uow.OrderRepository.List();
            var lists = Core.Mapper.MapperModels(postsDAL, usersDAL, productsDAL, ordersDAL, productTypesDAL, _mapper);
            return View(new AccountPage
            {
                Orders =lists.ordersPL,
                Posts = lists.postsPL,
                Products=lists.productsPL,
                ProductTypes = lists.productTypesPL,
                CurrentUser = currentUserPL
            });
        }

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

       

       
    }
}

