using Maxishop.Application.Service.Interface;
using Microsoft.Extensions.DependencyInjection;
using Maxishop.Application.Common;
using Maxishop.Application.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Maxishop.Application
{
    public static class ApplicationRegistration
    {
        public static IServiceCollection AddApplicationRegistration(this IServiceCollection services) 
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IBrandService, BrandService>();
            return services;
        }
    }
}
