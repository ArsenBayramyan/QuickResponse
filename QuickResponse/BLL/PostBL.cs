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
            if (postCreate.ProductType.Id == 0)
            {
                var productType = new QuickResponse.Data.Models.ProductType();
                this.UOW.ProductTypeRepository.Save(productType);//   this.Mapper.Map<ProductType,Data.Models.ProductType>();
                postCreate.ProductType.Id = productType.Id;
            }
            var post = this.Mapper.Map<PostCreateModel, Post>(postcreate);

            return this.UnitOfWorkRepository.PostRepository.Save(post);
        }

        private void SendPostMessage(Post post)
        {
            var posts = PostsList.Where(p => p.Category == post.Category && p.PostType != post.PostType);
            List<User> users = new List<User>();
            foreach (var p in posts)
            {
                users.Add(UnitOfWorkRepository.UserRepository.GetByID(p.UserId));
            }
            var user = UnitOfWorkRepository.UserRepository.GetByID(post.UserId);
            var senderEmail = new MailAddress(user.Email, user.FirstName);
            List<MailAddress> receiverEmails = new List<MailAddress>();
            foreach (var email in users)
            {
                var receiverEmail = new MailAddress(user.Email, "Receiver");
                receiverEmails.Add(receiverEmail);
            }
            var password = $"";
            var subject = $"{post.PostName}";
            var message = $"Full Name - {user.FirstName} {user.LastName}\n" +
                          $"Phone - {user.PhoneNumber}\n" +
                          $"Email - {user.Email}\n" +
                          $"Post Name - {post.PostName}\n" +
                          $"Post Description - {post.Body}";
            var smtp = new SmtpClient
            {

                Host = "smtp.mail.ru",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address, password)
            };
            foreach (var email in receiverEmails)
            {
                using (var mess = new MailMessage(senderEmail, email)
                {
                    Subject = subject,
                    Body = message
                })
                {
                    smtp.Send(mess);
                }
            }
        }

        public IEnumerable<Post> PostsList => UnitOfWorkRepository.PostRepository.List();

        /*public bool DeletePost(string id)
        {
            return this.UnitOfWorkRepository.PostRepository.DeleteById(id);
        }*/
    }
}
