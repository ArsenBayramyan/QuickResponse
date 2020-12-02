using AutoMapper;
using QuickResponse.Data.Models;
using QuickResponse.Data.Repositories;
using QuickResponse.Models.ViewModels;
using System;
using System.Net;
using System.Net.Mail;

namespace QuickResponse.BLL
{
    public class OrderBL:BaseBL
    {
        public OrderBL(UnitOfWorkRepository unitOfWorkRepository, IMapper mapper) : base(unitOfWorkRepository, mapper) { }
        
        public bool AddOrder(OrderCreateModel orderCreate)
        {
            var order = this.Mapper.Map<OrderCreateModel, Order>(orderCreate);
            //order.Status="";
            SendEmail(order);
            return this.UOW.OrderRepository.Save(order);
        }

        public void SendEmail(Order order)
        {
            var userFrom = UOW.UserRepository.GetByID(order.UserFrom);
            var userTo = UOW.UserRepository.GetByID(order.UserTo);
            var product = UOW.ProductRepository.GetByID(order.ProductId);
            var senderEmail = new MailAddress("order@mail.ru", "I want this product");
            var receiverEmail = new MailAddress($"{userTo.Email}", "Answer of Order");
            var password = "orderPassword";
            var subject = "Order";
            var message = $"Full Name: - {userFrom.FirstName} {userFrom.LastName}" + Environment.NewLine +
                          $"Phone: - {userFrom.PhoneNumber}" + Environment.NewLine +
                          $"Օrder description: - I want {product.ProductType.ProductTypeName} {order.ProuctCount} {product.ProductType.Dimensionality}․" +
                                                 $"Please confirm"+
                          $"Post Link: -";
            var smtp = new SmtpClient
            {

                Host = "smtp.mail.ru",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address, password)
            };
            using (var mess = new MailMessage(senderEmail, receiverEmail)
            {
                Subject = subject,
                Body = message
            })
            {
                smtp.Send(mess);
            }
        }
    }
}
