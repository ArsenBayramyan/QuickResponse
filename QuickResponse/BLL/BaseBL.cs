using AutoMapper;
using QuickResponse.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.BLL
{
    public abstract class BaseBL
    {
        protected UnitOfWorkRepository UnitOfWorkRepository { get; private set; }
        protected IMapper Mapper { get; private set; }
        public BaseBL(UnitOfWorkRepository unitOfWorkRepository)
        {
            this.UnitOfWorkRepository = unitOfWorkRepository;
        }

    }
}
