using QuickResponse.Core.Interfaces;
using QuickResponse.Data.Contexts;
using QuickResponse.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Data.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private AppIdentityDBContext _context;

        public ProductRepository(AppIdentityDBContext context)
        {
            this._context = context;
        }
        public bool Delete(Product entity)
        {
            this._context.Find<Product>(entity).IsDeleted = true;
            this._context.SaveChanges();
            return false;
        }

        public bool DeleteById(string id)
        {
            GetByID(id).IsDeleted = true;
            this._context.SaveChanges();
            return true;
        }

        public Product GetByID(string id)
        {
            return _context.Find<Product>(id);
        }

        public IEnumerable<Product> List()
        {
            return this._context.Products;
        }

        public bool Save(Product entity)
        {
            this._context.Products.Add(entity);
            this._context.SaveChanges();
            return true;
        }

        public bool Update(Product entity)
        {
            this._context.Update(entity);
            return true;
        }
    }
}
