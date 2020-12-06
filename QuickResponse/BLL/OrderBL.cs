using AutoMapper;
using QuickResponse.Data.Models;
using QuickResponse.Data.Repositories;
using QuickResponse.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickResponse.BLL
{
    public class OrderBL:BaseBL
    {
        public OrderBL(UnitOfWorkRepository unitOfWorkRepository, IMapper mapper) : base(unitOfWorkRepository, mapper) { }
        
        public bool AddOrder(OrderCreateModel orderCreate)
        {
            var order = this.Mapper.Map<OrderCreateModel, Order>(orderCreate);
            //order.Status="";
            var userFrom = UOW.UserRepository.GetByID(order.UserFrom);
            var userTo = UOW.UserRepository.GetByID(order.UserTo);
            var product = UOW.ProductRepository.GetByID(order.ProductId);
            var message=  $"Full Name: - {userFrom.FirstName} {userFrom.LastName}" + Environment.NewLine +
                          $"Phone: - {userFrom.PhoneNumber}" + Environment.NewLine +
                          $"Օrder description: - I want {product.ProductType.ProductTypeName} {order.ProuctCount} {product.ProductType.Dimensionality}․" +
                                                 $"Please confirm" + Environment.NewLine +
                          $"Post Link: -";
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
