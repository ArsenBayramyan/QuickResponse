using QuickResponse.Core.Interfaces;
using QuickResponse.Data.Contexts;
using QuickResponse.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Data.Repositories
{
    public class ProductTypeRepository : IRepository<ProductType>
    {
        private AppIdentityDBContext _context;

        public ProductTypeRepository(AppIdentityDBContext context)
        {
            this._context = context;
        }
        public bool Delete(ProductType entity)
        {
            this._context.Find<ProductType>(entity).IsDeleted = true;
            this._context.SaveChanges();
            return true;
        }

        public bool DeleteById(int id)
        {
            GetByID(id).IsDeleted = true;
            this._context.SaveChanges();
            return true;
        }

        public ProductType GetByID(int id)
        {
            return this._context.Find<ProductType>(id);
        }

        public IEnumerable<ProductType> List()
        {
            return this._context.ProductTypes;
        }

        public bool Save(ProductType entity)
        {
            var productType = this.List().FirstOrDefault(p => p.ProductTypeName == entity.ProductTypeName);
            if (productType is null)
            {
                this._context.ProductTypes.Add(entity);
                this._context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Update(ProductType entity)
        {
            this._context.Update(entity);
            return true;
        }
    }
}
