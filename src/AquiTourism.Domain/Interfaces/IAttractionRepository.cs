using AquiTourism.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AquiTourism.Domain.Interfaces
{
    public interface IAttractionRepository
    {
        Attraction GetById(int id);
        Task<Attraction> GetByIdAsync(int id);
        IEnumerable<Attraction> Search(Expression<Func<Attraction, bool>> predicate);
        Task<IEnumerable<Attraction>> SearchAsync(Expression<Func<Attraction, bool>> predicate);
        IEnumerable<Attraction> Search(Expression<Func<Attraction, bool>> predicate, int page, int pageSize);
        Attraction Add(Attraction entity);
        Task<Attraction> AddAsync(Attraction entity);
        Attraction Update(Attraction entity);
        void Remove(int id);
        void Remove(Expression<Func<Attraction, bool>> predicate);
    }
}
