using AquiTourism.Application.Interfaces;
using AquiTourism.Application.ViewModel;
using AquiTourism.Domain.Entities;
using AquiTourism.Domain.Interfaces;
using AquiTourism.Domain.Shared.Transaction;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AquiTourism.Application.Services
{
    public class AttractionAppService : BaseService, IAttractionAppService
    {
        protected readonly IAttractionRepository _repository;
        protected readonly IMapper _mapper;

        public AttractionAppService(IAttractionRepository repository, IMapper mapper, IUnitOfWork uow, IMediator bus)
            : base(uow, bus)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AttractionViewModel> AddAsync(AttractionViewModel viewModel)
        {
            Attraction domain = _mapper.Map<Attraction>(viewModel);
            domain = await _repository.AddAsync(domain);
            Commit();

            AttractionViewModel viewModelReturn = _mapper.Map<AttractionViewModel>(domain);
            return viewModelReturn;
        }

        public AttractionViewModel Update(AttractionViewModel viewModel)
        {
            var domain = _mapper.Map<Attraction>(viewModel);
            domain = _repository.Update(domain);
            Commit();

            AttractionViewModel viewModelReturn = _mapper.Map<AttractionViewModel>(domain);
            return viewModelReturn;
        }

        public async Task<bool> DeactivateAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null || !entity.IsActive)
                return false;

            entity.IsActive = false;
            _repository.Update(entity);
            Commit();
            return true;
        }

        public void Remove(int id)
        {
            _repository.Remove(id);
            Commit();
        }

        public void Remove(Expression<Func<Attraction, bool>> expression)
        {
            _repository.Remove(expression);
            Commit();
        }

        public AttractionViewModel GetById(int id)
        {
            var domain = _repository.GetById(id);
            var viewModel = _mapper.Map<AttractionViewModel>(domain);
            return viewModel;
        }

        public async Task<AttractionViewModel> GetByIdAsync(int id)
        {
            var domain = await _repository.GetByIdAsync(id);
            var viewModel = _mapper.Map<AttractionViewModel>(domain);
            return viewModel;
        }

        public IEnumerable<AttractionViewModel> Search(Expression<Func<Attraction, bool>> predicate)
        {
            var domainList = _repository.Search(predicate);
            var viewModelList = _mapper.Map<IEnumerable<AttractionViewModel>>(domainList);
            return viewModelList;
        }

        public async Task<IEnumerable<AttractionViewModel>> SearchAsync(Expression<Func<Attraction, bool>> predicate)
        {
            var domainList = await _repository.SearchAsync(predicate);
            var viewModelList = _mapper.Map<IEnumerable<AttractionViewModel>>(domainList);
            return viewModelList;
        }

        public IEnumerable<AttractionViewModel> Search(Expression<Func<Attraction, bool>> predicate, int pageNumber, int pageSize)
        {
            var domainList = _repository.Search(predicate, pageNumber, pageSize);
            var viewModelList = _mapper.Map<IEnumerable<AttractionViewModel>>(domainList);
            return viewModelList;
        }
    }
}
