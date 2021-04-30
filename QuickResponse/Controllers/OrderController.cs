using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuickResponse.BLL.BL;
using QuickResponse.Core.Interfaces;
using QuickResponse.Data.Repositories;
using QuickResponse.Models;
using QuickResponse.Models.ViewModels;
using QuickResponse.Validation;
using System.Collections.Generic;
using System.Linq;

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
            var product = _uow.ProductRepository.List().Where(p => p.ProductId == _product.ProductId).FirstOrDefault();
            if (orderCreate.ProductCount>product.Count)
            {
                orderCreate.ProductCount = product.Count;
            }
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
        public IActionResult UserOrders(int chechk)
        {
            var postsDAL = this._uow.PostRepository.List();
            var usersDAL = this._uow.UserRepository.List();
            var productsDAL = this._uow.ProductRepository.List();
            var productTypesDAL = this._uow.ProductTypeRepository.List();
            var ordersDAL = this._uow.OrderRepository.List();
            var lists= Core.Mapper.MapperModels(postsDAL, usersDAL, productsDAL, ordersDAL, productTypesDAL, _mapper);
            var currentUserDAL = _uow.UserManager.FindByNameAsync(HttpContext.User?.Identity?.Name).Result;
            var currentUserPL = this._mapper.Map<Data.Models.User, User>(currentUserDAL);
            if (currentUserPL.Email== "quick_response_soft@mail.ru")
            {
                chechk = -1;
            }
            return View(new UserOrderList
            {
                Posts = lists.postsPL,
                Users = lists.usersPL,
                Products = lists.productsPL,
                ProductTypes = lists.productTypesPL,
                Orders = lists.ordersPL,
                CurrentUser=currentUserPL,
                Chechk=chechk
            }); 
        }

        [HttpGet]
        public IActionResult Ordered()
        {
            var postsDAL = this._uow.PostRepository.List();
            var usersDAL = this._uow.UserRepository.List();
            var productsDAL = this._uow.ProductRepository.List();
            var productTypesDAL = this._uow.ProductTypeRepository.List();
            var ordersDAL = this._uow.OrderRepository.List();
            var lists = Core.Mapper.MapperModels(postsDAL, usersDAL, productsDAL, ordersDAL, productTypesDAL, _mapper);
            var currentUserDAL = _uow.UserManager.FindByNameAsync(HttpContext.User?.Identity?.Name).Result;
            var currentUserPL = this._mapper.Map<Data.Models.User, User>(currentUserDAL);
            return View(new UserOrderList
            {
                Posts = lists.postsPL,
                Users = lists.usersPL,
                Products = lists.productsPL,
                ProductTypes = lists.productTypesPL,
                Orders = lists.ordersPL,
                CurrentUser = currentUserPL
            });
        }

        [HttpPost]
        public IActionResult AcceptOrder(int id)
        {
            var orderBL = new OrderBL(_uow, _mapper);
            orderBL.AcceptOrder(id);
            return RedirectToAction("AccountPage","Account");
        }

        [HttpGet]
        public IActionResult CancelOrder(int id)
        {
            var orderBL = new OrderBL(_uow, _mapper);
            orderBL.CancelOrder(id);
            return RedirectToAction("AccountPage", "Account");
        }

    }
}
