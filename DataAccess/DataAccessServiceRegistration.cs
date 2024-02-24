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

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IApplicantRepository,ApplicantRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IInstructorRepository, InstructorRepository>();

            services.AddScoped<IApplicationRepository, ApplicationRepository>();
            services.AddScoped<IApplicationStateRepository, ApplicationStateRepository>();
            services.AddScoped<IBootcampRepository, BootcampRepository>();
            services.AddScoped<IBootcampStateRepository, BootcampStateRepository>();
            return services;
        }
    }
}
