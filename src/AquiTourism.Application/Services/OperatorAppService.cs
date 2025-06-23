using AquiTourism.Application.Interfaces;
using AquiTourism.Application.ViewModel;
using AquiTourism.Core.DomainObjects;
using AquiTourism.Domain.Entities;
using AquiTourism.Domain.Interfaces;
using AquiTourism.Domain.Shared.Transaction;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AquiTourism.Application.Services
{
    public class OperatorAppService : BaseService, IOperatorAppService
    {
        private readonly IOperatorRepository _operatorRepository;
        private readonly IMapper _mapper;

        public OperatorAppService(
            IOperatorRepository operatorRepository,
            IMapper mapper,
            IUnitOfWork uow,
            IMediator bus
        ) : base(uow, bus)
        {
            _operatorRepository = operatorRepository;
            _mapper = mapper;
        }

        public async Task<OperatorViewModel> CreateAsync(OperatorCreateViewModel model)
        {
            var existing = await _operatorRepository.GetByEmailAsync(model.Email);
            if (existing != null)
                throw new DomainException("Já existe um operador com este e-mail.");
            var existingByCpf = (await _operatorRepository.SearchAsync(o => o.CPF == model.Cpf && o.IsActive))?.FirstOrDefault();
            if (existingByCpf != null)
                throw new DomainException("Já existe um operador com este CPF ou o usuário não está ativo.");

            var password = new Password(model.Password, model.ConfirmPassword);
            var operatorEntity = new Operator(
                model.Name,
                new Email(model.Email),
                password,
                new Cpf(model.Cpf)
            );

            _operatorRepository.Add(operatorEntity);
            Commit();

            return _mapper.Map<OperatorViewModel>(operatorEntity);
        }

        public async Task<bool> DeactivateAsync(int id)
        {
            var entity = await _operatorRepository.GetByIdAsync(id);
            if (entity == null || !entity.IsActive)
                return false;

            entity.IsActive = false;
            _operatorRepository.Update(entity);
            Commit();
            return true;
        }

        public async Task<OperatorViewModel> UpdateAsync(int id, OperatorViewModel model)
        {
            var entity = await _operatorRepository.GetByIdAsync(id);
            if (entity == null || !entity.IsActive)
                return null;

            entity.Name = model.Name;
            entity.Email = model.Email;
            entity.CPF = model.Cpf;

            _operatorRepository.Update(entity);
            Commit();

            return _mapper.Map<OperatorViewModel>(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _operatorRepository.GetByIdAsync(id);
            if (entity == null || !entity.IsActive)
                return false;

            entity.IsActive = false;
            _operatorRepository.Update(entity);
            Commit();
            return true;
        }

        public async Task<OperatorViewModel> GetByIdAsync(int id)
        {
            var entity = await _operatorRepository.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<OperatorViewModel>(entity);
        }

        public async Task<bool> AuthenticateAsync(OperatorLoginViewModel model)
        {
            var entity = await _operatorRepository.GetByEmailAsync(model.Email);
            if (entity == null || !entity.IsActive)
                throw new DomainException("O usuário foi desativado ou não existe");

            bool isValid = Password.Verify(model.Password, entity.PasswordHash, entity.PasswordSalt);
            return isValid;
        }

        public async Task<bool> ResetPasswordAsync(string cpf, string newPassword, string confirmPassword)
        {
            var entity = await _operatorRepository
                .SearchAsync(o => o.CPF == cpf && o.IsActive);

            var operatorToUpdate = entity?.FirstOrDefault();
            if (operatorToUpdate == null)
                return false;

            var password = new Password(newPassword, confirmPassword);
            operatorToUpdate.UpdatePassword(password.Hash, password.Salt);

            _operatorRepository.Update(operatorToUpdate);
            Commit();

            return true;
        }
    }
}