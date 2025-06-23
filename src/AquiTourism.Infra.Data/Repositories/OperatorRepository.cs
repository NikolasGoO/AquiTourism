using AquiTourism.Domain.Entities;
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
    public class OperatorRepository : Repository<Operator>, IOperatorRepository
    {
        public OperatorRepository(AquiTourismDbContext context) : base(context)
        {
        }

        public Operator Add(Operator entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public async Task<Operator> AddAsync(Operator entity)
        {
            await DbSet.AddAsync(entity);
            return entity;
        }

        public Operator GetById(int id)
        {
            var context = DbSet.AsQueryable();
            return context.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Operator> GetByIdAsync(int id)
        {
            var context = DbSet.AsQueryable();
            return await context.FirstOrDefaultAsync(x => x.Id == id); ;
        }

        public void Remove(int id)
        {
            var obj = GetById(id);
            if (obj != null)
            {
                DbSet.Remove(obj);
            }
        }

        public void Remove(Expression<Func<Operator, bool>> predicate)
        {
            var context = DbSet.AsQueryable();
            DbSet.RemoveRange(context.Where(predicate));
        }

        public IEnumerable<Operator> Search(Expression<Func<Operator, bool>> predicate)
        {
            var context = DbSet.AsQueryable();
            return context.Where(predicate).ToList();
        }

        public IEnumerable<Operator> Search(Expression<Func<Operator, bool>> predicate, int page, int pageSize)
        {
            var context = DbSet.AsQueryable();
            var result = context.Where(predicate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
            return result;
        }

        public async Task<IEnumerable<Operator>> SearchAsync(Expression<Func<Operator, bool>> predicate)
        {
            var context = DbSet.AsQueryable();
            return await context.Where(predicate).ToListAsync();
        }

        public async Task<Operator> GetByEmailAsync(string email)
        {
            var context = DbSet.AsQueryable();
            return await context.FirstOrDefaultAsync(x => x.Email == email);
        }

        public Operator Update(Operator entity)
        {
            entity.UpdatedAt = DateTimeOffset.UtcNow;
            DbSet.Update(entity);
            return entity;
        }
    }
}
