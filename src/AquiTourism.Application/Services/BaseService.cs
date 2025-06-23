using AquiTourism.Domain.Shared.Transaction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquiTourism.Application.Services
{
    public class BaseService
    {
        protected readonly IUnitOfWork UoW;
        protected readonly IMediator Bus;

        protected BaseService(IUnitOfWork uow, IMediator bus)
        {
            UoW = uow;
            Bus = bus;
        }

        protected bool Commit()
        {
            return UoW.Commit();
        }
    }
}
