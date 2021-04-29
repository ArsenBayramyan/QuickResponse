using Microsoft.EntityFrameworkCore;
using QuickResponse.Core.Interfaces;
using QuickResponse.Data.Contexts;
using QuickResponse.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Data.Repositories
{
    public class MessageRepository : IRepository<Message>
    {
        private AppIdentityDBContext _context;
        public MessageRepository(AppIdentityDBContext context)
        {
            _context = context;
        }

        public bool Delete(Message entity)
        {
            this._context.Find<Message>(entity).IsDeleted = true;
            this._context.SaveChanges();
            return true;
        }

        public bool DeleteById(int id)
        {
            var entity = GetByID(id);
            entity.IsDeleted = true;
            this._context.SaveChanges();
            return true;
        }

        public Message GetByID(int id)
        {
            return this._context.Find<Message>(id);
        }

        public IEnumerable<Message> List()
        {
            return this._context.Messages.Where(m=>m.IsDeleted==false);
        }

        public bool Save(Message entity)
        {
            this._context.Messages.Add(entity);
            this._context.SaveChanges();
            return true;
        }

        public bool Update(Message entity)
        {

            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;

            }
        }
    }
}
