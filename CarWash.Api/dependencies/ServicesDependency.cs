using CarWash.Business.Business;
using CarWash.Business.IBusiness;
using CarWash.Data.IRepository;
using CarWash.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWash.Api.dependencies
{
    public static class ServicesDependency
    {
        public static void AddServiceDependency(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGeneralRepository<>), typeof(GeneralRepository<>));
            services.AddScoped<IUsuarioBusiness, UsuarioBusiness>();
            services.AddScoped<IServicioBusiness, ServicioBusiness>();




        }
    }
}
