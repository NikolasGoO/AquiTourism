using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquiTourism.Domain.Shared.Transaction
{
    public interface IUnitOfWork
    {
        bool Commit();
    }
}
