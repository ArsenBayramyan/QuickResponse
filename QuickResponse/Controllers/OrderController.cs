using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuickResponse.Core.Interfaces;
using QuickResponse.Data.Repositories;
using QuickResponse.Models.ViewModels;
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

        public IActionResult AddOrder(OrderAddModel order)
        {

            return RedirectToAction("");
        }
    }
}
