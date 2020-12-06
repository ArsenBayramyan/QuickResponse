using AutoMapper;
using QuickResponse.Data.Repositories;
using QuickResponse.Models.ViewModels;
using QuickResponse.Data.Models;
using System.Collections.Generic;
using System.Linq;



namespace QuickResponse.BLL
{
    public class PostBL : BaseBL
    {
        public PostBL(UnitOfWorkRepository unitOfWorkRepository, IMapper mapper) : base(unitOfWorkRepository, mapper) { }

        public bool AddPost(PostCreateModel postCreate,User currentUser )
        {
            if (postCreate.PostType=="Vajarvum e ")
            {
                var users = UOW.UserRepository.List().Where(u => u.Id != currentUser.Id);
                foreach (var u in users)
                {
                    var message = $"Full Name: - {currentUser.FirstName} {currentUser.LastName}\n" +
                                  $"Phone: - {currentUser.PhoneNumber}\n" +
                                  $"Post description: - I am selling {postCreate.Product.ProductType.ProductTypeName} {postCreate.Product.Count} {postCreate.ProductType.Dimensionality}․\n" +
                                  $"Post Link: - ";
                    BaseBL.SendEmailMessage(u.Email, message);
                }
            }
            if (postCreate.ProductType.ProductTypeId == 0)
            {
                var productType = this.Mapper.Map<QuickResponse.Models.ProductType,ProductType>(postCreate.ProductType);
                this.UOW.ProductTypeRepository.Save(productType);
                postCreate.ProductType.ProductTypeId = productType.ProductTypeId;
            }
            var post = this.Mapper.Map<PostCreateModel, Data.Models.Post>(postCreate);

            return this.UOW.PostRepository.Save(post);
        }

        public IEnumerable<Post> UserPostList(int id) => this.PostsList.Where(p => p.UserId == id);

        public IEnumerable<Post> PostListFilter(int postId)
        {
            var post = this.UOW.PostRepository.GetByID(postId);
            var filterPost = this.PostsList.Where(p =>p.PostType!=post.PostType && p.UserId!=post.UserId &&
                                                  p.Product.ProductType == post.Product.ProductType);
            return filterPost;
        }
        
        public IEnumerable<Post> PostsList => UOW.PostRepository.List();

        public bool DeletePost(int id)
        {
            return this.UOW.PostRepository.DeleteById(id);
        }

    }
}
