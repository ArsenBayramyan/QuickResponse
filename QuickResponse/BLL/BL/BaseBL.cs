using AutoMapper;
using QuickResponse.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace QuickResponse.BLL.BL
{
    public abstract class BaseBL
    {
        protected UnitOfWorkRepository UOW { get; private set; }
        protected IMapper Mapper { get; private set; }
        public BaseBL(UnitOfWorkRepository unitOfWorkRepository,IMapper mapper)
        {
            this.UOW = unitOfWorkRepository;
            this.Mapper = mapper;
        }

    }
}
