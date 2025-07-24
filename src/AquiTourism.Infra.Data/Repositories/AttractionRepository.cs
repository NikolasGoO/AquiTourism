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
    public class AttractionRepository : Repository<Attraction>, IAttractionRepository
    {
        public AttractionRepository(AquiTourismDbContext context) : base(context)
        {
        }

        public Attraction GetById(int id)
        {
            var context = DbSet.AsQueryable();
            var attraction = context.FirstOrDefault(x => x.Id == id);
            return attraction;
        }

        public async Task<Attraction> GetByIdAsync(int id)
        {
            var context = DbSet.AsQueryable();
            var attraction = await context.FirstOrDefaultAsync(x => x.Id == id);
            return attraction;
        }

        public IEnumerable<Attraction> Search(Expression<Func<Attraction, bool>> predicate)
        {
            var context = DbSet.AsQueryable();
            return context.Where(predicate).ToList();
        }

        public async Task<IEnumerable<Attraction>> SearchAsync(Expression<Func<Attraction, bool>> predicate)
        {
            var context = DbSet.AsQueryable();
            return await context.Where(predicate).ToListAsync();
        }

        public IEnumerable<Attraction> Search(Expression<Func<Attraction, bool>> predicate, int page, int pageSize)
        {
            var context = DbSet.AsQueryable();
            return context.Where(predicate).Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public Attraction Add(Attraction entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            DbSet.Add(entity);
            Db.SaveChanges();
            return entity;
        }

        public async Task<Attraction> AddAsync(Attraction entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await DbSet.AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<Attraction>> GetAll()
        {
            var context = DbSet.AsQueryable();
            return await context.ToListAsync();
        }

        public Attraction Update(Attraction entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            entity.UpdatedAt = DateTime.UtcNow;
            DbSet.Update(entity);
            return entity;
        }

        public void Remove(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                DbSet.Remove(entity);
            }
        }

        public void Remove(Expression<Func<Attraction, bool>> predicate)
        {
            var context = DbSet.AsQueryable();
            var entities = context.Where(predicate);
            DbSet.RemoveRange(entities);
        }
    }
}
