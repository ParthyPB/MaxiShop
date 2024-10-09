using Maxishop.Domain.Contracts;
using Maxishop.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxishop.Infrastructure
{
    public static class InfrastructureRegistrations
    {

        public static IServiceCollection AddInfrastructureService(this IServiceCollection services) 
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<CategoryRepository>();
            services.AddScoped<IProductRepository,BrandRepository>();
            services.AddScoped<BrandRepository>();

            return services;
        
        }
    }
}
