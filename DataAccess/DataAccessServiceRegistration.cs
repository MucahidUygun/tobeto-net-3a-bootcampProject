﻿using Core.Extensions;
using DataAccess.Abstract;
using DataAccess.Concretes.EntityFramework.Contexts;
using DataAccess.Concretes.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class DataAccessServiceRegistration
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services,IConfiguration configuration) 
        {
            services.AddDbContext<BaseDbContext>(
                options => options.UseSqlServer(
                    configuration.GetConnectionString("TobetoDotNet3AConnectionString")));


            services.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t => t.ServiceType.Name.EndsWith("Repository"));

            return services;
        }
    }
}
