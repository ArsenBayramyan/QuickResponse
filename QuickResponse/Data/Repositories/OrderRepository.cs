using QuickResponse.Core.Interfaces;
using QuickResponse.Data.Contexts;
using QuickResponse.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Data.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private AppIdentityDBContext _context;

        public OrderRepository(AppIdentityDBContext context)
        {
            this._context = context;
        }

        public Order GetByID(int id)
        {
            return this._context.Find<Order>(id);
        }

        public IEnumerable<Order> List()
        {
            return this._context.Orders;
        }

        public bool Save(Order entity)
        {
            entity.IsDeleted = false;
            this._context.Orders.Add(entity);
            this._context.SaveChanges();
            return true;
        }

        public bool Update(Order entity)
        {
            var order = this._context.Orders.Find(entity.OrderId);
            order.Status = entity.Status;
            order.ProductCount = entity.ProductCount;
            //if (order.Status == Core.Enums.OrderStatus.Canceled)
            //{
            //    this.Delete(order);
            //}
            this._context.SaveChanges();
            return true;
        }

        public bool Delete(Order entity)
        {
            this._context.Find<Order>(entity).IsDeleted = true;
            this._context.SaveChanges();
            return true;
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
