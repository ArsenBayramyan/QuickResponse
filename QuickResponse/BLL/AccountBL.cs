using AutoMapper;
using QuickResponse.Data.Models;
using QuickResponse.Data.Repositories;
using QuickResponse.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace QuickResponse.BLL
{
    public class AccountBL:BaseBL
    {
        private IMapper _mapper;
        public AccountBL(UnitOfWorkRepository unitOfWorkRepository, IMapper mapper) : base(unitOfWorkRepository)
        {
            this._mapper = mapper;
        }
        public bool Registration(UserCreateModel userCreate)
        {

            var user = this._mapper.Map<UserCreateModel,User>(userCreate);
            this.UnitOfWorkRepository.UserRepository.Save(user);
            return true;
        } 
        
    }
}
