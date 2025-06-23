using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AquiTourism.Application.ViewModel;
using AquiTourism.Domain.Entities;

namespace AquiTourism.Application.Interfaces
{
    public interface IAttractionAppService
    {
        Task<AttractionViewModel> AddAsync(AttractionViewModel attraction);
        AttractionViewModel Update(AttractionViewModel attraction);
        void Remove(int id);
        void Remove(Expression<Func<Attraction, bool>> expression);
        Task<bool> DeactivateAsync(int id);
        AttractionViewModel GetById(int id);
        Task<AttractionViewModel> GetByIdAsync(int id);
        IEnumerable<AttractionViewModel> Search(Expression<Func<Attraction, bool>> predicate);
        Task<IEnumerable<AttractionViewModel>> SearchAsync(Expression<Func<Attraction, bool>> predicate);
        IEnumerable<AttractionViewModel> Search(Expression<Func<Attraction, bool>> predicate, int pageNumber, int pageSize);
    }
}