using AutoMapper;
using QuickResponse.Data.Models;
using QuickResponse.Data.Repositories;

namespace QuickResponse.BLL
{
    public class OrderBL:BaseBL
    {
        public OrderBL(UnitOfWorkRepository unitOfWorkRepository, IMapper mapper) : base(unitOfWorkRepository, mapper) { }
        
        public bool AddOrder()
        {
            var order = new Order();
            order.
        }
    }
}
