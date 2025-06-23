using AquiTourism.Application.Interfaces;
using AquiTourism.Application.Services;
using AquiTourism.Domain.Interfaces;
using AquiTourism.Domain.Shared.Transaction;
using AquiTourism.Infra.Data.Context;
using AquiTourism.Infra.Data.Repositories;
using AquiTourism.Infra.Data.Uow;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace AquiTourism.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddMediatr();
            services.AddRepositories();
            services.AddServices();
        }

        public static void AddMediatr(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.Load("AquiTourism.Domain")));
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<AquiTourismDbContext>();

            services.AddScoped<IAttractionRepository, AttractionRepository>();
            services.AddScoped<IOperatorRepository, OperatorRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAttractionAppService, AttractionAppService>();
            services.AddScoped<IOperatorAppService, OperatorAppService>();
        }
    }
}
