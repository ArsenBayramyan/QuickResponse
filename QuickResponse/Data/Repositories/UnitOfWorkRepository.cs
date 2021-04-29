using Microsoft.AspNetCore.Identity;
using QuickResponse.Core.Interfaces;
using QuickResponse.Data.Contexts;
using QuickResponse.Data.Models;
using System;

namespace QuickResponse.Data.Repositories
{
    public class UnitOfWorkRepository : IUnitOfWOrkRepositroy/*,IDisposable*/
    {
        private UserRepository _userRepository;
        private PostRepository _postRepository;
        private OrderRepository _orderReposiotry;
        private ProductRepository _productRepository;
        private ProductTypeRepository _productTypeRepository;
        private SignInManager<User> _signInManager;
        private UserManager<User> _userManager;
        private MessageRepository _messageRepository;
        
        public UnitOfWorkRepository(UserManager<User> userManager, AppIdentityDBContext context,
            SignInManager<User> signInManager)
        {
            this._userRepository = new UserRepository(userManager);
            this._postRepository = new PostRepository(context);
            this._orderReposiotry = new OrderRepository(context);
            this._productRepository = new ProductRepository(context);
            this._productTypeRepository = new ProductTypeRepository(context);
            this._messageRepository = new MessageRepository(context);
            this._signInManager = signInManager;
            this._userManager = userManager;
        }

        public UserRepository UserRepository => _userRepository;

        public PostRepository PostRepository => _postRepository;

        public OrderRepository OrderRepository => _orderReposiotry;

        public ProductRepository ProductRepository => _productRepository;

        public ProductTypeRepository ProductTypeRepository => _productTypeRepository;

        public SignInManager<User> SignInManager => _signInManager;

        public UserManager<User> UserManager => _userManager;

        public MessageRepository MessageRepository => _messageRepository;

    }
}
