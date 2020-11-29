using Microsoft.AspNetCore.Identity;
using QuickResponse.Core.Interfaces;
using QuickResponse.Data.Contexts;
using QuickResponse.Data.Models;

namespace QuickResponse.Data.Repositories
{
    public class UnitOfWorkRepository : IUnitOfWOrkRepositroy
    {
        private UserRepository _userRepository;
        private PostRepository _postRepository;
        private OrderRepository _orderReposiotry;
        private SignInManager<User> _signInManager;
        private UserManager<User> _userManager;
        
        public UnitOfWorkRepository(UserManager<User> userManager, AppIdentityDBContext context,
            SignInManager<User> signInManager)
        {
            this._userRepository = new UserRepository(userManager);
            this._postRepository = new PostRepository(context);
            this._orderReposiotry = new OrderRepository(context);
            this._signInManager = signInManager;
            this._userManager = userManager;
        }

        public UserRepository UserRepository => _userRepository;

        public PostRepository PostRepository => _postRepository;
        public SignInManager<User> SignInManager => _signInManager;
        public UserManager<User> UserManager => _userManager;


    }
}
