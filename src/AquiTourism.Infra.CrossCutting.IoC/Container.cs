using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquiTourism.Infra.CrossCutting.IoC
{
    public static class Container
    {
        public static IServiceCollection AddNativeInjectorBootStrapper(this IServiceCollection services)
        {
            return services;
        }

        public static void AddMediatr(this IServiceCollection services)
        {
            services.AddMediatR(AppDomain.CurrentDomain.Load("AquiTourism.Domain"));
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        }
    }
}
