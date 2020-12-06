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
        public AccountBL(UnitOfWorkRepository unitOfWorkRepository, IMapper mapper) : base(unitOfWorkRepository, mapper) { }

        public bool Registration(UserCreateModel userCreate)
        {
            var user = this.Mapper.Map<UserCreateModel,User>(userCreate);
            return this.UOW.UserRepository.Save(user);
        } 

        public bool Login(UserLoginModel userLogin)
        {
            var user = this.Mapper.Map<UserLoginModel, User>(userLogin);
            var FindUser = this.UOW.UserRepository.GetByID(user.Id);
            bool success=false;
            if (FindUser != null && FindUser.IsDeleted == false)
            {
                UOW.SignInManager.SignOutAsync();
                var result =
                     UOW.SignInManager.PasswordSignInAsync(FindUser, user.PasswordHash, true, false).Result;
                success=result.Succeeded;
            }
            return success;
        }

        public IEnumerable<User> UsersList() => UOW.UserRepository.List();


        /*public bool DeleteAccount(string id)
          {
              return this.UOW.UserRepository.DeleteById(id);
          }
        */
    }
}
