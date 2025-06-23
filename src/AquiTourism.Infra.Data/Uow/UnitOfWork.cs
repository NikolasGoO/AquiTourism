using AquiTourism.Domain.Shared.Transaction;
using AquiTourism.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquiTourism.Infra.Data.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AquiTourismDbContext _context;
        public UnitOfWork(AquiTourismDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
