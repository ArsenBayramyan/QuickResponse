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

        public Order GetByID(string id)
        {
            return this._context.Find<Order>(id);
        }

        public IEnumerable<Order> List()
        {
            return this._context.Orders;
        }

        public bool Save(Order entity)
        {
            this._context.Orders.Add(entity);
            this._context.SaveChanges();
            return true;
        }

        public bool Update(Order entity)
        {
            entity.Success = true;
            this._context.Update(entity);
            return true;
        }

        public bool Delete(Order entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
