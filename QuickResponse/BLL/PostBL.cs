﻿using AutoMapper;
using QuickResponse.Data.Repositories;
using QuickResponse.Models.ViewModels;
using QuickResponse.Data.Models;
using System.Collections.Generic;
using System.Linq;
using QuickResponse.Core.Enums;


namespace QuickResponse.BLL
{
    public class PostBL : BaseBL
    {
        public PostBL(UnitOfWorkRepository unitOfWorkRepository, IMapper mapper) : base(unitOfWorkRepository, mapper) { }

        public bool AddPost(PostCreateModel postCreate,User currentUser)
        {
            var product = this.UOW.ProductRepository.List().Where(p => p.ProductTypeId == postCreate.ProductTypeId).FirstOrDefault();
            if (product is null)
            {
                product = new Product
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
                var postList = this.UOW.PostRepository.List().Where(p => p.PostType !=PostType.ForSale  && p.UserId!=post.UserId);
                if (post.PostId!=0)
                {
                    foreach (var p in postList)
                    {
                        var message = $"{post.PostName} postum popoxutyun e katarvel\n" +
                                      $"Full Name: - Ars\n" +
                                      $"Phone: - 094940708\n" +
                                      $"Post Name: - {postCreate.PostName}\n" +
                                      $"Price: - {postCreate.Price}\n" +
                                      $"Post description: - I am selling {postCreate.Product.ProductType.ProductTypeName} {postCreate.Product.Count} " +
                                      $"Post Link: - ";
                        var userTo = UOW.UserRepository.GetByID(p.UserId);
                        BaseBL.SendEmailMessage(userTo.Email, message);
                    }
                    return this.UOW.PostRepository.Update(post);
                }
                foreach (var p in postList)
                {
                    var message = $"Full Name: - {currentUser.FirstName} {currentUser.LastName}\n" +
                                  $"Phone: - {currentUser.PhoneNumber}\n" +
                                  $"Post Name: - {postCreate.PostName}\n" +
                                  $"Price: - {postCreate.Price}\n" +
                                  $"Post description: - I am selling {postCreate.Body} {postCreate.Count}";
                    var user = this.UOW.UserRepository.GetByID(p.UserId);
                    BaseBL.SendEmailMessage(user.Email, message);
                }
                
            }
            return this.UOW.PostRepository.Save(post);
        }

        public IEnumerable<Post> UserPostList(int id) => this.PostList.Where(p => p.UserId == id);

        public IEnumerable<Post> PostListFilter(int postId)
        {
            var post = this.UOW.PostRepository.GetByID(postId);
            var filterPost = this.PostList.Where(p => p.PostType != post.PostType && p.UserId != post.UserId &&
                                                  p.Product.ProductType == post.Product.ProductType);
            return filterPost;
        }

        public IEnumerable<Post> PostList => UOW.PostRepository.List();

        public bool DeletePost(int id)
        {
            return this.UOW.PostRepository.DeleteById(id);
        }

    }
}
