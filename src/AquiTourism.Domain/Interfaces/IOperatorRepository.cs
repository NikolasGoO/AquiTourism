using AquiTourism.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AquiTourism.Domain.Interfaces
{
    public interface IOperatorRepository
    {
        Operator GetById(int id);
        Task<Operator> GetByIdAsync(int id);
        IEnumerable<Operator> Search(Expression<Func<Operator, bool>> predicate);
        Task<IEnumerable<Operator>> SearchAsync(Expression<Func<Operator, bool>> predicate);
        IEnumerable<Operator> Search(Expression<Func<Operator, bool>> predicate, int page, int pageSize);
        Operator Add(Operator entity);
        Task<Operator> GetByEmailAsync(string email);
        Task<Operator> AddAsync(Operator entity);
        Operator Update(Operator entity);
        void Remove(int id);
        void Remove(Expression<Func<Operator, bool>> predicate);
    }
}
