using AutoMapper;
using QuickResponse.Data.Models;
using QuickResponse.Data.Repositories;
using QuickResponse.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace QuickResponse.BLL.BL
{
    public class AccountBL : BaseBL
    {
        public AccountBL(UnitOfWorkRepository unitOfWorkRepository, IMapper mapper) : base(unitOfWorkRepository, mapper) { }

        public bool Registration(UserCreateModel userCreate)
        {
            var user = this.Mapper.Map<UserCreateModel, User>(userCreate);
            user.RegistrationDate = DateTime.Now;
            if (this.UOW.UserRepository.GetByID(user.Id) is null)
            {
                return this.UOW.UserRepository.Save(user);
            }
            return false;
        }
         
        public bool EditProfile(UserCreateModel userEdit)
        {
            var user = this.Mapper.Map<UserCreateModel, User>(userEdit);
            if (this.UOW.UserRepository.GetByID(user.Id) is null)
            {
                return false;
            }
            return this.UOW.UserRepository.Update(user);
        }

        public bool Login(UserLoginModel userLogin)
        {
            var user = this.Mapper.Map<UserLoginModel, User>(userLogin);
            var findUser = this.UOW.UserRepository.GetByEmail(user.Email);
            bool success = false;
            if (findUser != null && findUser.IsDeleted == false)
            {
                UOW.SignInManager.SignOutAsync();
                var result =
                     UOW.SignInManager.PasswordSignInAsync(findUser, user.PasswordHash, true, false).Result;
                success = result.Succeeded;
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
