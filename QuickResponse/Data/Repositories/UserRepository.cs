using Microsoft.AspNetCore.Identity;
using QuickResponse.Core.Interfaces;
using QuickResponse.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Data.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private UserManager<User> _userManager;

        public UserRepository(UserManager<User> userManager)
        {
            this._userManager = userManager;
        }

        public bool Delete(User entity)
        {
            return this._userManager.DeleteAsync(entity).Result.Succeeded;
        }

        public bool DeleteById(int id)
        {
            var user = this._userManager.FindByIdAsync(id.ToString()).Result;
            user.IsDeleted = true;
            return Update(user); 
        }

        public User GetByID(int id)
        {
            var user = this._userManager.FindByIdAsync(id.ToString()).Result;
            return user;
        }

        public IEnumerable<User> List()
        {
            var users = this._userManager.Users;
            return users;
        }

        public bool Save(User entity)
        {
            var result = this._userManager.CreateAsync(entity, entity.PasswordHash).Result;

            return result.Succeeded;
        }

        public bool Update(User entity)
        {
            return this._userManager.UpdateAsync(entity).Result.Succeeded;
        }

    }
}
