using AutoMapper;
using QuickResponse.Data.Repositories;
using QuickResponse.Models.ViewModels;
using QuickResponse.BLL.Models;
using System.Collections.Generic;
using System.Linq;
using QuickResponse.Core.Enums;
using QuickResponse.Core;
using System;

namespace QuickResponse.BLL.BL
{
    public class PostBL : BaseBL
    {
        public PostBL(UnitOfWorkRepository unitOfWorkRepository, IMapper mapper) : base(unitOfWorkRepository, mapper) { }

        public bool AddPost(PostCreateModel postCreate, string currentUserName)
        {
            var product = this.UOW.ProductRepository.List().Where(p => p.ProductTypeId == postCreate.ProductTypeId).FirstOrDefault();
            var currentUser = this.UOW.UserManager.FindByNameAsync(currentUserName).Result;
            if (product is null)
            {
                product = new Data.Models.Product
                {
                    ProductTypeId = postCreate.ProductTypeId,
                    Count = postCreate.Count
                };
                this.UOW.ProductRepository.Save(product);
            }
            var post = this.Mapper.Map<PostCreateModel, Data.Models.Post>(postCreate);
            post.Product = product;
            post.ProductId = product.ProductId;
            post.UserId = currentUser.Id;
            if (post.PostType == PostType.ForSale)
            {
                var postList = this.UOW.PostRepository.List().Where(p => p.PostType != PostType.ForSale && p.UserId != post.UserId);
                if (post.PostId != 0)
                {
                    foreach (var p in postList)
                    {
                        var productType = this.UOW.ProductTypeRepository.List().Where(t => t.ProductTypeId == post.Product.ProductTypeId).FirstOrDefault();
                        var message = $"{post.PostName} postum popoxutyun e katarvel\n" +
                                      $"Full Name: - Ars\n" +
                                      $"Phone: - 094940708\n" +
                                      $"Post Name: - {postCreate.PostName}\n" +
                                      $"Price: - {postCreate.Price}\n" +
                                      $"Post description: - I am selling {productType.ProductTypeName} {post.Product.Count}\n" +
                                      $"Post Link: - https://localhost:44372/Post/PostView/{post.PostId}";
                        var userTo = UOW.UserRepository.GetByID(p.UserId);
                        EmailSender.SendEmailMessage(userTo.Email, message,"Post updated");
                    }
                    return this.UOW.PostRepository.Update(post);
                }
                foreach (var p in postList)
                {
                    var message = $"Full Name: - {currentUser.FirstName} {currentUser.LastName}\n" +
                              $"Phone: - {currentUser.PhoneNumber}\n" +
                              $"Post Name: - {postCreate.PostName}\n" +
                              $"Price: - {postCreate.Price}\n" +
                              $"Post description: - I am selling {postCreate.Body} {postCreate.Count}\n" +
                              $"Post Link: - https://localhost:44372/Post/PostView/{post.PostId}"; ;
                    var user = this.UOW.UserRepository.GetByID(p.UserId);
                    EmailSender.SendEmailMessage(user.Email, message,"New post");
                }
            }
            else if(post.PostId != 0)
            {
                return this.UOW.PostRepository.Update(post);
            }
            return this.UOW.PostRepository.Save(post);
        }

        public IEnumerable<Data.Models.Post> UserPostList(int id) => this.PostList.Where(p => p.UserId == id);

        public IEnumerable<Data.Models.Post> PostListFilter(int postId)
        {
            var post = this.UOW.PostRepository.GetByID(postId);
            var product = this.UOW.ProductRepository.List().Where(p => p.ProductId == post.ProductId).FirstOrDefault();
            var filterPost = this.PostList.FirstOrDefault(p => p.PostType != post.PostType && p.UserId != post.UserId &&
                                                  p.Product.ProductTypeId == product.ProductTypeId);
            yield return filterPost;
        }

        public IEnumerable<Data.Models.Post> PostList => UOW.PostRepository.List();

        public bool DeletePost(int id)
        {
            return this.UOW.PostRepository.DeleteById(id);
        }

    }
}
