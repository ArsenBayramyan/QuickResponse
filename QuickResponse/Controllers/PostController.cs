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
using System.Threading.Tasks;

namespace QuickResponse.Controllers
{
    public class PostController:Controller
    {
        private UnitOfWorkRepository _uow;
        private IMapper _mapper;
        public int PageSize = 4;
        public PostController(IUnitOfWOrkRepositroy unitOfWOrkRepositroy, IMapper mapper)
        {
            this._uow = (UnitOfWorkRepository)unitOfWOrkRepositroy;
            this._mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddPost(PostAddModel postAdd)
        {
            var validator = new PostAddValidator();
            if (validator.Validate(postAdd).IsValid)
            {
                var postBL = new PostBL(_uow, _mapper);
                if (postBL.AddPost(postAdd))
                {
                    return RedirectToAction("");
                }
            }
            return RedirectToAction("");
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            if (_uow.PostRepository.DeleteById(id))
            {
                return RedirectToAction("");
            }
            return null;
        }
    }
}
