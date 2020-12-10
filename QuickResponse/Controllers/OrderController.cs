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
using System.Threading.Tasks;

namespace QuickResponse.Controllers
{
    public class OrderController:Controller
    {
        private UnitOfWorkRepository _uow;
        private IMapper _mapper;

        public OrderController(IUnitOfWOrkRepositroy unitOfWOrkRepositroy, IMapper mapper)
        {
            this._uow = (UnitOfWorkRepository)unitOfWOrkRepositroy;
            this._mapper = mapper;
        }

        [HttpGet]
        public ViewResult AddOrder()=> View();


        [HttpPost]
        public IActionResult AddOrder(OrderCreateModel orderCreate)
        {
            var validator = new OrderCreateValidator();
            if (validator.Validate(orderCreate).IsValid)
            {
                var orderBL = new OrderBL(_uow, _mapper);
                if (orderBL.AddOrder(orderCreate))
                {
                    return RedirectToAction("");
                }
            }
            return RedirectToAction("AddOrder");
        }
    }
}
