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
        private SignInManager<User> _signInManager;
        private UserManager<User> _userManager;
        
        public UnitOfWorkRepository(UserManager<User> userManager, AppIdentityDBContext context,
            SignInManager<User> signInManager)
        {
            _userRepository = new UserRepository(userManager);
            _postRepository = new PostRepository(context);
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public UserRepository UserRepository => _userRepository;

        public PostRepository PostRepository => _postRepository;
        public SignInManager<User> SignInManager => _signInManager;
        public UserManager<User> UserManager => _userManager;


    }
}
