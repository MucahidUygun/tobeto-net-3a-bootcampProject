using Business.Abstract;
using Business.Concretes;
using Core.CrossCuttingConcerns;
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
            //services.AddScoped<IUserService, UserManager>();
            //services.AddScoped<IApplicantService, ApplicantManager>();
            //services.AddScoped<IEmployeeService, EmployeeManager>();
            //services.AddScoped<IInstructorService, InstructorManager>();
            //services.AddScoped<IBlacklistService, BlacklistManager>();
            //services.AddScoped<IApplicationService, ApplicationManager>();
            //services.AddScoped<IBootcampService, BootcampManager>();
            //services.AddScoped<IApplicationStateService, ApplicationStateManager>();
            //services.AddScoped<IBootcampStateService, BootcampStateManager>();
            services.AddSubClassesOfType(Assembly.GetExecutingAssembly(),typeof(BaseBusinessRules));

            services.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t=>t.ServiceType.Name.EndsWith("Manager"));
            
            return services;
        }

        public static IServiceCollection AddSubClassesOfType
            (this IServiceCollection services,Assembly assembly,Type type, Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null) 
        {
            var types = assembly.GetTypes().Where(t=>t.IsSubclassOf(type) && type !=t).ToList();

            foreach (Type? item in types)
            {
                if (addWithLifeCycle == null)
                {
                    services.AddScoped(item);
                }
                else
                {
                    addWithLifeCycle(services,type);
                }
            }
            return services;
        }

        public static IServiceCollection RegisterAssemblyTypes(this IServiceCollection services,Assembly assembly)
        {
            var types = assembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract);
            foreach (Type? item in types)
            {
                var interfaces = item.GetInterfaces();

                foreach (var @interface in interfaces)
                {
                    services.AddScoped(@interface,item); 
                }

            }

            return services;
        }




    }
}
