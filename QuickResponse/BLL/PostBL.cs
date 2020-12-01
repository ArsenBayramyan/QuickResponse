using AutoMapper;
using QuickResponse;
using QuickResponse.Data.Repositories;
using QuickResponse.Models.ViewModels;
using QuickResponse.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;

namespace QuickResponse.BLL
{
    public class PostBL : BaseBL
    {
        public PostBL(UnitOfWorkRepository unitOfWorkRepository, IMapper mapper) : base(unitOfWorkRepository, mapper) { }

        public bool AddPost(PostCreateModel postCreate)
        {
            if (postCreate.ProductType.ProductTypeId == 0)
            {
                var productType = this.Mapper.Map<ProductType, Data.Models.ProductType>(postCreate.ProductType);
                this.UOW.ProductTypeRepository.Save(productType);
                postCreate.ProductType.ProductTypeId = productType.ProductTypeId;
            }
            var post = this.Mapper.Map<PostCreateModel, Data.Models.Post>(postCreate);

            return this.UOW.PostRepository.Save(post);
        }

        public IEnumerable<Data.Models.Post> UserPostList(int id) => this.PostsList.Where(p => p.UserId == id);

        public IEnumerable<Data.Models.Post> PostListFilter(int postId)
        {
            var post = this.UOW.PostRepository.GetByID(postId);
            var filterPost = this.PostsList.Where(p => p.PostType != post.PostType && p.UserId!=post.UserId &&
                                                  p.Product.ProductType == post.Product.ProductType);
            return filterPost;
        }
        
        public IEnumerable<Data.Models.Post> PostsList => UOW.PostRepository.List();

        public bool DeletePost(int id)
        {
            return this.UOW.PostRepository.DeleteById(id);
        }
    }
}
