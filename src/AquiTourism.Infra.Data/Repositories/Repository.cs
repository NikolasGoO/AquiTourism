using AquiTourism.Core.DomainObjects;
using AquiTourism.Domain.Interfaces;
using AquiTourism.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AquiTourism.Infra.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly AquiTourismDbContext Db;
        protected readonly DbSet<T> DbSet;

        public Repository(AquiTourismDbContext context)
        {
            Db = context ?? throw new ArgumentNullException(nameof(context));
            DbSet = Db.Set<T>();
        }

        protected IQueryable<T> Querry()
        {
            return DbSet;
        }

        public void Dispose()
        {
            Db?.Dispose();
            GC.SuppressFinalize(this);
        }

        public long Count()
        {
            return DbSet.LongCount();
        }

        public long Count(Expression<Func<T, bool>> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            return DbSet.LongCount(predicate);
        }
    }
}
