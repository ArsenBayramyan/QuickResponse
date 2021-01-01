using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuickResponse.BLL;
using QuickResponse.Core.Interfaces;
using QuickResponse.Data.Models;
using QuickResponse.Data.Repositories;
using QuickResponse.Models.ViewModels;
using QuickResponse.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Controllers
{
    public class OrderController:Controller
    {
        private UnitOfWorkRepository _uow;
        private IMapper _mapper;
        private IUser _userTo;
        private IProduct _product;
        private IPost _post;

        public OrderController(IUnitOfWOrkRepositroy unitOfWOrkRepositroy, IMapper mapper,IUser userTo,IProduct product,IPost post)
        {
            this._uow = (UnitOfWorkRepository)unitOfWOrkRepositroy;
            this._mapper = mapper;
            this._userTo = userTo;
            this._product = product;
            this._post = post;
        }

        [HttpGet]
        public ViewResult CreateOrder(int id)
        {
            _post.PostId = id;
            var post = _uow.PostRepository.List().Where(p => p.PostId == id).FirstOrDefault();
            _userTo.Id = _uow.UserRepository.List().Where(u => u.Id == post.UserId).FirstOrDefault().Id;
            _product.ProductId = _uow.ProductRepository.List().Where(p => p.ProductId == post.ProductId).FirstOrDefault().ProductId;
            return View();
        }


        [HttpPost]
        public IActionResult CreateOrder(OrderCreateModel orderCreate)
        {
            orderCreate.PostId = _post.PostId;
            orderCreate.ProductId = _product.ProductId;
            orderCreate.UserTo = _userTo.Id;
            orderCreate.UserFrom= _uow.UserManager.FindByNameAsync(HttpContext.User?.Identity?.Name).Result.Id;
            var validator = new OrderCreateValidator();
            if (validator.Validate(orderCreate).IsValid)
            {
                var orderBL = new OrderBL(_uow, _mapper);
                if (orderBL.AddOrder(orderCreate))
                {
                    return RedirectToAction("AccountPage", "Account");
                }
            }
            return RedirectToAction();
        }
        
        [HttpGet]
        public IActionResult UserOrders()
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
