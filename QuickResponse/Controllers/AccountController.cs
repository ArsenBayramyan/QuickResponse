using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuickResponse.BLL;
using QuickResponse.Core.Interfaces;
using QuickResponse.Data.Contexts;
using QuickResponse.Data.Models;
using QuickResponse.Data.Repositories;
using QuickResponse.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UnitOfWorkRepository _uow;
        public AccountController(IUnitOfWOrkRepositroy unitOfWOrkRepositroy)
        {
            this._uow = (UnitOfWorkRepository)unitOfWOrkRepositroy;
        }
        [HttpGet]
        [AllowAnonymous]
        public ViewResult Registration() => View();

        [HttpGet]
        [AllowAnonymous]
        public ViewResult Login() => View();


    }
}
