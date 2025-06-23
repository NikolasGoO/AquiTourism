using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AquiTourism.Application.ViewModel;

namespace AquiTourism.Application.Interfaces
{
    public interface IOperatorAppService
    {
        Task<OperatorViewModel> CreateAsync(OperatorCreateViewModel model);
        Task<OperatorViewModel> UpdateAsync(int id, OperatorViewModel model);
        Task<bool> DeleteAsync(int id);
        Task<OperatorViewModel> GetByIdAsync(int id);
        Task<bool> AuthenticateAsync(OperatorLoginViewModel model);
        Task<bool> DeactivateAsync(int id);
        Task<bool> ResetPasswordAsync(string cpf, string newPassword, string confirmPassword);
    }
}