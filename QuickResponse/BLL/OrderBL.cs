using AutoMapper;
using QuickResponse.Data.Models;
using QuickResponse.Data.Repositories;
using QuickResponse.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using QuickResponse.Core.Enums;

namespace QuickResponse.BLL
{
    public class OrderBL:BaseBL
    {
        public OrderBL(UnitOfWorkRepository unitOfWorkRepository, IMapper mapper) : base(unitOfWorkRepository, mapper) { }
        
        public bool AddOrder(OrderCreateModel orderCreate)
        {
            var order = this.Mapper.Map<OrderCreateModel, Order>(orderCreate);
            order.PostTo = orderCreate.PostId;
            var postTo = this.UOW.PostRepository.List().Where(p => p.PostId == orderCreate.PostId).FirstOrDefault();
            var userFrom = this.UOW.UserRepository.List().Where(u => u.Id == order.UserFrom).FirstOrDefault();
            var userTo = this.UOW.UserRepository.List().Where(u => u.Id == order.UserTo).FirstOrDefault();
            var product = this.UOW.ProductRepository.List().Where(p => p.ProductId == order.ProductId).FirstOrDefault();
            var productType = this.UOW.ProductTypeRepository.List().Where(t => t.ProductTypeId == product.ProductTypeId).FirstOrDefault();
            order.Status=OrderStatus.AwaitingApproval;
            var message=  $"Full Name: - {userFrom.FirstName} {userFrom.LastName}" + Environment.NewLine +
                          $"Phone: - {userFrom.PhoneNumber}" + Environment.NewLine +
                          $"Օrder description: - I want {productType.ProductTypeName} {order.ProuctCount} {productType.Dimensionality}․" +
                                                 $"Please confirm" + Environment.NewLine +
                          $"{postTo.Body}"+Environment.NewLine+
                          $"Post Link: - https://localhost:44372/Post/PostView/{orderCreate.PostId}";
            BaseBL.SendEmailMessage(userTo.Email, message);
            return this.UOW.OrderRepository.Save(order);
        }

        public IEnumerable<Order> OrderList => UOW.OrderRepository.List();

        public IEnumerable<Order> UserOrderList(int userId)
        {
            var userOrderList = this.OrderList.Where(o => o.UserFrom == userId);
            return userOrderList;
        }
       
    }
}
