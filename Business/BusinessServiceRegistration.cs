using Business.Abstract;
using Business.Concretes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services) 
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IApplicantService, ApplicantManager>();
            services.AddScoped<IEmployeeService, EmployeeManager>();
            services.AddScoped<IInstructorService, InstructorManager>();
            services.AddScoped<IBlacklistService, BlacklistManager>();
            services.AddScoped<IApplicationService, ApplicationManager>();
            services.AddScoped<IBootcampService, BootcampManager>();
            services.AddScoped<IApplicationStateService, ApplicationStateManager>();
            services.AddScoped<IBootcampStateService, BootcampStateManager>();
            return services;
        }
    }
}
